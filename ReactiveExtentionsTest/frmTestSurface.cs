using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive;

namespace ReactiveExtentionsTest
{
    public partial class frmTestSurface : Form
    {
        public frmTestSurface()
        {
            InitializeComponent();

            //wire up the events as an obeservable stream
            IObservable<EventPattern<MouseEventArgs>> move =
                Observable.FromEventPattern<MouseEventArgs>(picInput, "MouseMove");

            //filter only the points inside our rectangle and when mouse is pressed
            IObservable<System.Drawing.Point> points = from evt in move
                                                       where ((evt.EventArgs.Location.X >= picInput.Width * 0.1 &&
                                                       evt.EventArgs.Location.X <= picInput.Width * 0.9) &&
                                                            (evt.EventArgs.Location.Y >= picInput.Height * 0.1 &&
                                                       evt.EventArgs.Location.Y <= picInput.Height * 0.9)) &&
                                                       evt.EventArgs.Button == MouseButtons.Left
                                                       select evt.EventArgs.Location;
            points.Subscribe(o => DrawOutput(o));
        }

        private void picInput_Paint(object sender, PaintEventArgs e)
        {

            //draw a rectangle 80% of the size of the picture box asour input area
            e.Graphics.DrawRectangle(Pens.Red, new Rectangle(
                (int)(picInput.Width * 0.1), (int)(picInput.Height * 0.1),
                            (int)(picInput.Width * 0.8), (int)(picInput.Height * 0.8)));
        }

        private void DrawOutput(Point pos)
        {
            lstPoints.Items.Add($"Point X({pos.X}) Y({pos.Y})");
            lstPoints.SelectedIndex = lstPoints.Items.Count - 1;

            if (picInput.Image == null)//if no available bitmap exists on the picturebox to draw on
            {
                //create a new bitmap
                Bitmap bmp = new Bitmap(picInput.Width, picInput.Height);

                picInput.Image = bmp; //assign the picturebox.Image property to the bitmap created
            }

            using (Graphics g = Graphics.FromImage(picInput.Image))
            {//we need to create a Graphics object to draw on the picture box, its our main tool

                //when making a Pen object, you can just give it color only or give it color and pen size

                g.DrawEllipse(new Pen(Color.Black, 2), pos.X, pos.Y, 1, 1);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //this is to give the drawing a more smoother, less sharper look

                picInput.Invalidate();//refreshes the picturebox
            }
        }
    }
}

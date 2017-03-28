using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace ReactiveExtentionsTest
{
    public partial class frmTestSurface : Form
    {
        public frmTestSurface()
        {
            InitializeComponent();

            //initilize the picture box and paint a red boxinsideto indicate input filter area
            InitializePictureBox();

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
            //draw point

            //uncomment to add a delay
            //points.Delay(TimeSpan.FromSeconds(1)).Subscribe(o => DrawPoint(o));

            points.Subscribe(o => DrawPoint(o));
        }

        private void InitializePictureBox()
        {
            //create a new bitmap
            Bitmap bmp = new Bitmap(picInput.Width, picInput.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                DrawRectangle(g);

                picInput.Image = bmp; //assign the picturebox.Image property to the bitmap created
            }
        }

        private void DrawRectangle(Graphics g)
        {
            g.DrawRectangle(Pens.Red, new Rectangle((int)(picInput.Width * 0.1), (int)(picInput.Height * 0.1),
                (int)(picInput.Width * 0.8), (int)(picInput.Height * 0.8)));
        }

        private void DrawPoint(Point pos)
        {
            this.Invoke((MethodInvoker)delegate {
                LogPoint(pos);
            });

            using (Graphics g = Graphics.FromImage(picInput.Image))
            {//we need to create a Graphics object to draw on the picture box, its our main tool

                //when making a Pen object, you can just give it color only or give it color and pen size

                g.DrawEllipse(new Pen(Color.Black, 2), pos.X, pos.Y, 1, 1);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //this is to give the drawing a more smoother, less sharper look

                picInput.Invalidate();//refreshes the picturebox
            }
        }

        private void LogPoint(Point pos)
        {
            lstPoints.Items.Add($"Point X({pos.X}) Y({pos.Y})");
            lstPoints.SelectedIndex = lstPoints.Items.Count - 1;
        }
    }
}

﻿namespace ReactiveExtentionsTest
{
    partial class frmTestSurface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picInput = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstPoints = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            this.SuspendLayout();
            // 
            // picInput
            // 
            this.picInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picInput.Location = new System.Drawing.Point(32, 47);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(481, 384);
            this.picInput.TabIndex = 0;
            this.picInput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(526, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Draw Here: Press left button and move mouse inside and outside red box.";
            // 
            // lstPoints
            // 
            this.lstPoints.FormattingEnabled = true;
            this.lstPoints.ItemHeight = 20;
            this.lstPoints.Location = new System.Drawing.Point(541, 47);
            this.lstPoints.Name = "lstPoints";
            this.lstPoints.Size = new System.Drawing.Size(258, 384);
            this.lstPoints.TabIndex = 4;
            // 
            // frmTestSurface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 466);
            this.Controls.Add(this.lstPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTestSurface";
            this.Text = "Test Surface";
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstPoints;
    }
}


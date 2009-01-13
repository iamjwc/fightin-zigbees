using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lps_program
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Button exitButton = new Button();
            exitButton.Height = 20;
            exitButton.Width = 30;
            exitButton.Enabled = true;
            exitButton.Visible = true;
            exitButton.Name = "btnExit";
            exitButton.Text = "Exit";
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            //Create pen for drawing room layout.
            Pen mapDrawingPen = new Pen(Color.Black);

            //Draw top room wall
            e.Graphics.DrawLine(mapDrawingPen, 20, 30, 40, 30);

            //Draw the door

            e.Graphics.DrawLine(mapDrawingPen, 60, 10, 60, 30);
            e.Graphics.DrawLine(mapDrawingPen, 60, 30, 80, 30);

            //first bump            
            e.Graphics.DrawLine(mapDrawingPen, 80, 10, 80, 30);
            e.Graphics.DrawLine(mapDrawingPen, 80, 10, 140, 10);
            e.Graphics.DrawLine(mapDrawingPen, 140, 10, 140, 20);

            //whiteboard area
            e.Graphics.DrawLine(mapDrawingPen, 140, 20, 540, 20);

            //second bump
            e.Graphics.DrawLine(mapDrawingPen, 540, 10, 540, 20);
            e.Graphics.DrawLine(mapDrawingPen, 540, 10, 620, 10);
            e.Graphics.DrawLine(mapDrawingPen, 620, 10, 620, 20);
            e.Graphics.DrawLine(mapDrawingPen, 620, 20, 630, 20);

            //Draw left room wall
            e.Graphics.DrawLine(mapDrawingPen, 20, 30, 20, 400);

            //Draw right room wall
            e.Graphics.DrawLine(mapDrawingPen, 630, 20, 630, 400);

            //Draw bottom room wall
            e.Graphics.DrawLine(mapDrawingPen, 20, 400, 630, 400);
        }
    }
}
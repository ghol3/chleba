using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace chleby
{
    public partial class Form1 : Form
    {
        bool pohyb = false;
        private int a = 50;
        private int b = 50;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Location = new Point(a, b);
            if (pohyb)
                pictureBox1.Location = new Point(MousePosition.X - a, MousePosition.Y - b);
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            a = this.Location.X;
            b = this.Location.Y;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pohyb = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pohyb = false;
            //testovani rohu
            if (pictureBox1.Location.X < 2 && pictureBox1.Location.Y > 277 - pictureBox1.Height)
                pictureBox1.Location = new Point(2, 277 - pictureBox1.Height);
            if(pictureBox1.Location.X < 2 && pictureBox1.Location.Y < 27)
                pictureBox1.Location = new Point(2, 27);
            if(pictureBox1.Location.X > 439 - pictureBox1.Width && pictureBox1.Location.Y < 27)
                pictureBox1.Location = new Point(439 - pictureBox1.Width, 27);
            if(pictureBox1.Location.X > 439 - pictureBox1.Width && pictureBox1.Location.Y > 277 - pictureBox1.Height)
                pictureBox1.Location = new Point(439 - pictureBox1.Width, 277 - pictureBox1.Height);
            //testovani jen stran
            if (pictureBox1.Location.X < 2)
                pictureBox1.Location = new Point(2, MousePosition.Y - b);
            if (pictureBox1.Location.X > 439 - pictureBox1.Width)
                pictureBox1.Location = new Point(439 - pictureBox1.Width, MousePosition.Y - b);
            if (pictureBox1.Location.Y > 277 - pictureBox1.Height)
                pictureBox1.Location = new Point(MousePosition.X - a, 277 - pictureBox1.Height);
            if (pictureBox1.Location.Y < 27)
                pictureBox1.Location = new Point(MousePosition.X - a, 27);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = MousePosition.X.ToString();
            label2.Text = MousePosition.Y.ToString();
            
        }

        //pohybovani s oknem
        int WindowMove, WindowMoveX, WindowMoveY;
        private void BGforMOVE_MouseMove(object sender, MouseEventArgs e)
        {
            if (WindowMove == 1)
                this.SetDesktopLocation(MousePosition.X - WindowMoveX - 230, MousePosition.Y - WindowMoveY);
        }

        private void BGforMOVE_MouseDown(object sender, MouseEventArgs e)
        {
            WindowMove = 1;
            WindowMoveX = e.X;
            WindowMoveY = e.Y;
        }

        private void BGforMOVE_MouseUp(object sender, MouseEventArgs e)
        {
            WindowMove = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {   
            Brush brush = new SolidBrush(Color.FromArgb(49, 48, 48));
            Rectangle horni = new Rectangle(0, 25, 441, 2);
            Rectangle leva = new Rectangle(0,25, 2, 279);
            Rectangle spodni = new Rectangle(0, 277, 441, 2);
            Rectangle prava = new Rectangle(439, 25, 2, 279);
            e.Graphics.FillRectangle(brush, horni);
            e.Graphics.FillRectangle(brush, leva);
            e.Graphics.FillRectangle(brush, spodni);
            e.Graphics.FillRectangle(brush, prava);
        }
    }
}

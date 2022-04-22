using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace PuzzleCraftGame
{
    class Arrow
    {
        //Arrow token image holders -- this causes a lot of lag
        private static Image arrowUp = Image.FromFile("arrowUp.png");
        private static Image arrowDown = Image.FromFile("arrowDown.png");
        private static Image arrowLeft = Image.FromFile("arrowLeft.png");
        private static Image arrowRight = Image.FromFile("arrowRight.png");

        //Thanks for covering classes, Steve!
        public string shootDirection;
        public int arrowLeftSide;
        public int arrowTopSide;

        private int arrowSpeed = 20;

        //Create the image for arrows
        private PictureBox arrow = new PictureBox();
        private Timer arrowTime = new Timer();

        //Needed for arrows to spawn
        public void arrowCreate(Form form)
        {
            //Image set up - getting the arrow to shoot in the right direction was rough to do!
            arrow.Tag = "arrow";
            Size arrowSize = new Size(15, 15);
            arrow.Size = arrowSize;
            arrow.SizeMode = PictureBoxSizeMode.StretchImage;
            arrow.BackColor = Color.Transparent;
            arrow.Top = arrowTopSide;
            arrow.Left = arrowLeftSide;
            arrow.BringToFront();

            form.Controls.Add(arrow);

            arrowTime.Tick += new EventHandler(ArrowShootEvent);
            arrowTime.Interval = arrowSpeed;
            arrowTime.Start();
        }

        private void ArrowShootEvent(object sender, EventArgs e)
        {
            if (shootDirection == "up")
            {
                arrow.Top -= arrowSpeed;
                arrow.Image = arrowUp;
            }
            if (shootDirection == "down")
            {
                arrow.Top += arrowSpeed;
                arrow.Image = arrowDown;
            }
            if (shootDirection == "left")
            {
                arrow.Left -= arrowSpeed;
                arrow.Image = arrowLeft;
            }
            if (shootDirection == "right")
            {
                arrow.Left += arrowSpeed;
                arrow.Image = arrowRight;
            }

            //DO NOT LET THEM RUN FOREVER!! (Thanks Stack - this took forever to figure out)
            if (arrow.Left < 10 || arrow.Left > 790 || arrow.Top < 10 || arrow.Top > 590)
            {
                arrowTime.Stop();
                arrowTime.Dispose();
                arrow.Dispose();
                arrow = null;
                arrowTime = null;
            }
        }
    }
}

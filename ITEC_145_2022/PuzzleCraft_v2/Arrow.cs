using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    class Arrow
    {
        //Variables for quick editing
        private const int TOKEN_SIZE = 50;  //the ratio sizes for the token
        private const int TOKEN_DIRECTIONS = 4; //number of images that are in list, inclding original and flips/rotated
        private const int _MOVESPEED = 20;    //For arrow movement speed

        /* Revamped from original game version */
        private static List<Image> arrowImages = new List<Image>(TOKEN_DIRECTIONS);  //0 = Up; 1 = Right; 2 = Down; 3 = Left
        static Form gameForm;  //Holds the information from the Form calling in a arrow

        private readonly Timer arrowTimer = new Timer();
        private PictureBox arrow = new PictureBox();    //Creates a picturebox for the new arrow
        private int _SizeW; //Form width
        private int _SizeH; //Form height
        private int _direction = 0;

        public int X { get { return arrow.Left; } }
        public int Y { get { return arrow.Top; } }

        public int Width { get { return arrow.Width; } }
        public int Height { get { return arrow.Height; } }

        public Arrow(Form callForm, int fWidth, int fHeight, string direction, int pcLeft, int pcTop)
        {
            if (arrowImages.Count < TOKEN_DIRECTIONS)   //Checks if a arrowImages list is already made
            {
                for (int i = 0; i < TOKEN_DIRECTIONS; i++) //Adds eight arrow tokens to arrowImages List
                    arrowImages.Add(new Bitmap(Resource1.arrow));
                MoveToks(); //Adjusts images to complete arrows laying in all four directions (plus flipped versions)
            }
            gameForm = callForm;
            _SizeW = fWidth;
            _SizeH = fHeight;
            arrow.Top = pcTop;
            arrow.Left = pcLeft;
            _direction = int.Parse(direction.Substring(0));

            Size arrowSize = new Size(TOKEN_SIZE, TOKEN_SIZE);  //Sets the size for each picturebox, making sure they fit
            arrow.Size = arrowSize;
            arrow.SizeMode = PictureBoxSizeMode.StretchImage;
            arrow.BackColor = Color.Transparent;
            arrow.Tag = _direction.ToString();
            arrow.Image = arrowImages[_direction];
            arrowTimer.Interval = 20;
            arrowTimer.Tick += TickTimer_Tick;
            arrowTimer.Enabled = true;
            gameForm.Controls.Add(arrow);
        }

        private void MoveToks()
        {
            arrowImages[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            arrowImages[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            arrowImages[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void TickTimer_Tick(object sender, EventArgs e)  //Determines the direction of the flying arrow
        {
            if ((string)arrow.Tag == "0")
                arrow.Top -= _MOVESPEED;
            if ((string)arrow.Tag == "1")
                arrow.Left += _MOVESPEED;
            if ((string)arrow.Tag == "2")
                arrow.Top += _MOVESPEED;
            if ((string)arrow.Tag == "3")
                arrow.Left -= _MOVESPEED;
        }

        public void Die()
        {
            arrowTimer.Stop();
            arrowTimer.Dispose();
            arrow.Dispose();
            GC.Collect();
        }
    }
}

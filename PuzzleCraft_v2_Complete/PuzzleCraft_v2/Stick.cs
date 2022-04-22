using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    internal class Stick
    {
        //Variables for quick editing
        private const int TOKEN_SIZE = 25;  //the ratio sizes for the token
        private const int TOKEN_DIRECTIONS = 8; //number of images that are in list, inclding original and flips/rotated

        /* Revamped from original game version */
        private static List<Image> stickImages = new List<Image>(TOKEN_DIRECTIONS);  //0 = Up; 1 = Right; 2 = Down; 3 = Left
        private static Form gameForm;  //Holds the information from the Form calling in a stick

        private Random rnd = new Random();
        private PictureBox stick = new PictureBox(); //Creates a picturebox for the new stick
        private int _SizeW; //Form width
        private int _SizeH; //Form height
        public int X { get { return stick.Left; } }
        public int Y { get { return stick.Top; } }
        public int Width { get { return stick.Width; } }
        public int Height { get { return stick.Height; } }

        public Stick(Form callForm, int fWidth, int fHeight)
        {
            if (stickImages.Count < TOKEN_DIRECTIONS)   //Checks if a stickImages list is already made
            {
                for (int i = 0; i < TOKEN_DIRECTIONS; i++) //Adds eight stick tokens to stickImages List
                    stickImages.Add(new Bitmap(Resource1.stick));
                MoveToks(); //Adjusts images to complete sticks laying in all directions
            }
            gameForm = callForm;
            _SizeW = fWidth;
            _SizeH = fHeight;
            Size stickSize = new Size(TOKEN_SIZE, TOKEN_SIZE);  //Sets the size for each picturebox, making sure they fit
            stick.Size = stickSize;
            stick.SizeMode = PictureBoxSizeMode.StretchImage;
            stick.BackColor = Color.Transparent;
            stick.Tag = "stick";
            stick.Image = stickImages[rnd.Next(0, TOKEN_DIRECTIONS)];
            stick.Left = rnd.Next(0, _SizeW - TOKEN_SIZE);
            stick.Top = rnd.Next(0, _SizeH - TOKEN_SIZE);
            gameForm.Controls.Add(stick);
        }

        private void MoveToks()
        {
            stickImages[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            stickImages[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            stickImages[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
            stickImages[4].RotateFlip(RotateFlipType.RotateNoneFlipY);
            stickImages[5].RotateFlip(RotateFlipType.Rotate90FlipY);
            stickImages[6].RotateFlip(RotateFlipType.Rotate180FlipY);
            stickImages[7].RotateFlip(RotateFlipType.Rotate270FlipY);
        }

        public void Pickup()
        {
            stick.Dispose();
            GC.Collect();
        }
    }
}

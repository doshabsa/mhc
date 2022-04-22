using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    internal class Stone
    {
        //Variables for quick editing
        private const int TOKEN_SIZE = 25;  //the ratio sizes for the token
        private const int TOKEN_DIRECTIONS = 8; //number of images that are in list, inclding original and flips/rotated

        /* Revamped from original game version */
        private static List<Image> stoneImages = new List<Image>(TOKEN_DIRECTIONS);  //0 = Up; 1 = Right; 2 = Down; 3 = Left
        private static Form gameForm;  //Holds the information from the Form calling in a stone

        private Random rnd = new Random();
        private PictureBox stone = new PictureBox();    //Creates a picturebox for the new stone
        private int _SizeW; //Form width
        private int _SizeH; //Form height

        public int X { get { return stone.Left; } }
        public int Y { get { return stone.Top; } }
        public int Width { get { return stone.Width; } }
        public int Height { get { return stone.Height; } }

        public Stone(Form callForm, int fWidth, int fHeight)
        {
            if (stoneImages.Count < TOKEN_DIRECTIONS)   //Checks if a stoneImages list is already made
            {
                for (int i = 0; i < TOKEN_DIRECTIONS; i++) //Adds eight stone tokens to stoneImages List
                    stoneImages.Add(new Bitmap(Resource1.stone));
                MoveToks(); //Adjusts images to complete stones laying in all directions
            }
            gameForm = callForm;
            _SizeW = fWidth;
            _SizeH = fHeight;
            Size stoneSize = new Size(TOKEN_SIZE, TOKEN_SIZE);  //Sets the size for each picturebox, making sure they fit
            stone.Size = stoneSize;
            stone.SizeMode = PictureBoxSizeMode.StretchImage;
            stone.BackColor = Color.Transparent;
            stone.Tag = "stone";
            stone.Image = stoneImages[rnd.Next(0, TOKEN_DIRECTIONS)];
            stone.Left = rnd.Next(0, _SizeW - TOKEN_SIZE);
            stone.Top = rnd.Next(0, _SizeH- TOKEN_SIZE);
            gameForm.Controls.Add(stone);
        }

        private void MoveToks()
        {
            stoneImages[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            stoneImages[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            stoneImages[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
            stoneImages[4].RotateFlip(RotateFlipType.RotateNoneFlipY);
            stoneImages[5].RotateFlip(RotateFlipType.Rotate90FlipY);
            stoneImages[6].RotateFlip(RotateFlipType.Rotate180FlipY);
            stoneImages[7].RotateFlip(RotateFlipType.Rotate270FlipY);
        }

        public void Pickup()
        {
            stone.Dispose();
            GC.Collect();
        }
    }
}

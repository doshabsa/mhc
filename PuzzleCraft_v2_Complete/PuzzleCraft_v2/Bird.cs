using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    class Bird
    {
        //Variables for quick editing
        private const int TOKEN_SIZE = 50;  //the ratio sizes for the token
        private const int TOKEN_DIRECTIONS = 4; //number of images that are in list, inclding original and flips/rotated
        private int _MoveSpeed;    //For bird movement speed

        /* Revamped from original game version */
        private static List<Image> birdImages = new List<Image>(TOKEN_DIRECTIONS);  //0 = Up; 1 = Right; 2 = Down; 3 = Left
        private static Form gameForm;  //Holds the information from the Form calling in a bird

        private Timer birdTimer = new Timer();
        private PictureBox bird = new PictureBox();    //Creates a picturebox for the new bird
        private Random rnd = new Random();
        private int _SizeW; //Form width
        private int _SizeH; //Form height

        public int X { get { return bird.Left; } }
        public int Y { get { return bird.Top; } }

        public int Width { get { return bird.Width; } }
        public int Height { get { return bird.Height; } }

        public Bird(Form callForm, int fWidth, int fHeight)
        {
            if (birdImages.Count < TOKEN_DIRECTIONS)   //Checks if a birdImages list is already made
            {
                for (int i = 0; i < TOKEN_DIRECTIONS; i++) //Adds eight bird tokens to birdImages List
                    birdImages.Add(new Bitmap(Resource1.raven));
                MoveToks(); //Adjusts images to complete birds laying in all four directions (plus flipped versions)
            }
            _SizeW = fWidth;
            _SizeH = fHeight;
            gameForm = callForm;
            Size birdSize = new Size(TOKEN_SIZE, TOKEN_SIZE);  //Sets the size for each picturebox, making sure they fit
            bird.Size = birdSize;
            bird.SizeMode = PictureBoxSizeMode.StretchImage;
            bird.BackColor = Color.Transparent;
            birdTimer.Interval = 20;
            birdTimer.Tick += TickTimer_Tick;
            birdTimer.Enabled = true;
            SpawnBird();
            gameForm.Controls.Add(bird);
            bird.BringToFront();   //Ensures birds at the top-most layer, even if player picks up items
        }

        private static void MoveToks()
        {
            birdImages[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            birdImages[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            birdImages[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
        }

        private void TickTimer_Tick(object sender, EventArgs e)  //Determines the direction of the flying bird
        {
            if (bird != null)
            {
                if ((string)bird.Tag == "0bird")
                    bird.Top -= _MoveSpeed;
                if ((string)bird.Tag == "1bird")
                    bird.Left += _MoveSpeed;
                if ((string)bird.Tag == "2bird")
                    bird.Top += _MoveSpeed;
                if ((string)bird.Tag == "3bird")
                    bird.Left -= _MoveSpeed;
            }
        }

        public void Die()
        {
            birdTimer.Stop();
            birdTimer.Dispose();
            bird.Dispose();
            GC.Collect();
        }

        private void SpawnBird()
        {
            int random = rnd.Next(0, 4); //Determines bird flight direction
            _MoveSpeed = rnd.Next(3, 12);  //Determines bird flight speed
            if (random == 0)
            {
                bird.Image = birdImages[0]; //Sets image to appear flying up
                bird.Tag = "0bird";
                bird.Left = rnd.Next(0, _SizeW - bird.Width);    //Spawn on bottom, move up
                bird.Top = _SizeH;
            }
            if (random == 1)
            {
                bird.Image = birdImages[1]; //Sets image to appear flying to right
                bird.Tag = "1bird";
                bird.Left = 0; //Spawn on left, move right
                bird.Top = rnd.Next(0, _SizeH - bird.Height);
            }
            if (random == 2)
            {
                bird.Image = birdImages[2]; //Sets image to appear flying down
                bird.Tag = "2bird";
                bird.Left = rnd.Next(0, _SizeW - bird.Width);    //Spawn on top, move down
                bird.Top = 0;
            }
            if (random == 3)
            {
                bird.Image = birdImages[3]; //Sets image to appear flying to left
                bird.Tag = "3bird";
                bird.Left = _SizeW;    //Spawn on right, move left
                bird.Top = rnd.Next(0, _SizeH - bird.Height);
            }
        }
    }
}
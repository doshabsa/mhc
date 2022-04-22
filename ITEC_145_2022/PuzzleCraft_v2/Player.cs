using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    class Player
    {
        //Variables for quick editing
        private const int TOKEN_SIZE = 45;  //the ratio sizes for the token
        private const int TOKEN_DIRECTIONS = 4; //number of images that are in list, inclding original and flips/rotated
        private const int _MOVESPEED = 15;    //For player movement speed

        /* Revamped from original game version */
        private static List<Image> playerImages = new List<Image>(TOKEN_DIRECTIONS);  //0 = Up; 1 = Right; 2 = Down; 3 = Left
        static Form gameForm;  //Holds the information from the Form calling in a player
        private Random rnd = new Random();
        private PictureBox player = new PictureBox();    //Creates a picturebox for the new player
        private int _SizeW; //Form width
        private int _SizeH; //Form height
        private string _Tag;

        public string pcTag { get { return _Tag; } }
        public int X { get { return player.Left; } }
        public int Y { get { return player.Top; } }
        public int Width { get { return player.Width; } }
        public int Height { get { return player.Height; } }

        public Player(Form callForm, Image token, int fWidth, int fHeight)
        {
            player.Image = token;
            gameForm = callForm;
            if (playerImages.Count < TOKEN_DIRECTIONS)   //Checks if a playerImages list is already made
            {
                for (int i = 0; i < TOKEN_DIRECTIONS; i++) //Adds eight player tokens to playerImages List
                    playerImages.Add(new Bitmap(token));
                MoveToks(); //Adjusts images to complete players laying in all four directions (plus flipped versions)
            }

            _SizeW = fWidth;
            _SizeH = fHeight;
            player.Tag = "0player";
            player.Top = rnd.Next(0, _SizeH - player.Height);
            player.Left = rnd.Next(0, _SizeW - player.Width);
            Size playerSize = new Size(TOKEN_SIZE, TOKEN_SIZE);  //Sets the size for each picturebox, making sure they fit
            player.Size = playerSize;
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.BackColor = Color.Transparent;
            gameForm.Controls.Add(player);
        }

        private void MoveToks()
        {
            playerImages[1].RotateFlip(RotateFlipType.Rotate90FlipNone);
            playerImages[2].RotateFlip(RotateFlipType.Rotate180FlipNone);
            playerImages[3].RotateFlip(RotateFlipType.Rotate270FlipNone);
            playerImages.Add(Resource1._Dead);
        }

        public void FormResize(int fWidth, int fHeight)
        {
            _SizeW = fWidth;
            _SizeH = fHeight;
        }

        public void MoveTop(bool dir)  //For movement of the item up/down
        {
            if (dir)
                player.Top -= _MOVESPEED;
            else
                player.Top += _MOVESPEED;
            if (player.Top < 0) player.Top = 0;
            if (player.Top + Height > _SizeH) player.Top = _SizeH - Height;
        }

        public void MoveLeft(bool dir) //For movement of the item left/right
        {
            if (dir)
                player.Left -= _MOVESPEED;
            else
                player.Left += _MOVESPEED;
            if (player.Left < 0) player.Left = 0;
            if (player.Left + Width > _SizeW) player.Left = _SizeW - Width;
        }

        public Image TokenDir(int i)  //Adjust token to match the direction of movement
         {
            if (i == 0) //Up
            {
                player.Image = playerImages[0];
                player.Tag = "0player";
            }
            if (i == 1) //Right
            {
                player.Image = playerImages[1];
                player.Tag = "1player";
            }
            if (i == 2) //Down
            {
                player.Image = playerImages[2];
                player.Tag = "2player";
            }
            if (i == 3) //Left
            {
                player.Image = playerImages[3];
                player.Tag = "3player";
            }
            _Tag = i.ToString();
            return player.Image;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    public partial class Form1 : Form
    {
        private const int NUMTOKENS = 32;   //Change for however many player tokens options there are

        /* Credits found in FormManager.cs */
        private Random rnd = new Random();
        private static List<Image> pcTokens = new List<Image>(NUMTOKENS);

        //Once I figured out you can make an array of almost anything...
        private PictureBox[] boxes = new PictureBox[6];
        private Panel[] backings = new Panel[6];
        private PictureBox selected;

        public Form1()
        {
            InitializeComponent();

            ResourceManager rm = Resource1.ResourceManager;
            //Enters each possible player token into an array
            for (int i = 0; i < NUMTOKENS; i++)
            {
                pcTokens.Add((Bitmap)rm.GetObject("_" + i));
            }

            boxes[0] = pictureBox0; //These did not want to initialize in one line
            boxes[1] = pictureBox1; //Maybe try again later, since it is ugly
            boxes[2] = pictureBox2;
            boxes[3] = pictureBox3;
            boxes[4] = pictureBox4;
            boxes[5] = pictureBox5;

            backings[0] = panel0;
            backings[1] = panel1;
            backings[2] = panel2;
            backings[3] = panel3;
            backings[4] = panel4;
            backings[5] = panel5;

            RandomizeTok();
        }

        private void RandomizeTok()
        {
            List<Image> tokCopy = new List<Image>();        //Creates a duplicate image list, since I do not want to remove the images permanently
            foreach (Image pic in pcTokens)                 //in case the user wants to click the randomize button a lot
                tokCopy.Add(pic);

            for (int pb = 0; pb < boxes.Length; pb++)            //Adds an image to a pictureboxes, 
            {                                                    //then removes it from the copy so it cannot be selected again
                int selectImage = rnd.Next(0, tokCopy.Count);
                boxes[pb].Image = tokCopy[selectImage];
                tokCopy.RemoveAt(selectImage);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                Form2 GameForm = new Form2(selected.Image);
                GameForm.Show();
                FormManager.MainMenu.Hide();  //Reference in FormManager.cs
            }
            else
            {
                MessageBox.Show("Please select your character before starting the game.");
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            selected = null;    //signifies the chosen token; if not selected then
            UpdateTokens();     //prompt user to pick one before continuing
            RandomizeTok();
        }

        private void PictureBox_Select(object sender, EventArgs e)
        {
            selected = (PictureBox)sender;
            UpdateTokens();
        }

        private void UpdateTokens()
        {
            for (int i = 0; i < 6; i++)
            {
                backings[i].BackColor = SystemColors.Control;       //Not really able to add the borders (since they are drawn) so I put the transparent tokens
                if (selected == boxes[i])                           //on top of panels, which can more easily be recolored
                    backings[i].BackColor = Color.White;
            }
        }
    }
}

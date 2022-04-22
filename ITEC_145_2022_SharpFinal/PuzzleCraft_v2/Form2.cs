using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PuzzleCraft_v2
{
    public partial class Form2 : Form
    {
        /* Credits found in FormManager.cs */
        Audio audio;
        Player player;
        Inventory inventory = new Inventory();
        Random rnd = new Random();

        List<Stick> stickList = new List<Stick>();
        List<Stone> stoneList = new List<Stone>();
        List<Bird> ravenList = new List<Bird>();
        List<Arrow> arrowList = new List<Arrow>();

        public enum KeyMove { none, up, down, left, right, space }  //For player movement
        KeyMove playerKey = KeyMove.none;

        public Form2(Image token)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            Map gameMap = new Map(ClientSize.Width, ClientSize.Height, rnd.Next(0, 3)); //Fetches the random map
            this.BackgroundImage = Map.gameMaps[0]; //Applies the first (daytime) map to Form2
            audio = new Audio(this); //Prepares background music
            audio.PlayMusic(0);

            player = new Player(this, token, ClientSize.Width, ClientSize.Height);   //Spawns in the player token
            gameTime.Enabled = true; //Game timer start
        }

        private void NoFocus()
        {
            this.ActiveControl = null;  //If any controls are displayed onto the Form2; then this will deselect them so that
            return;                     //key movement will continue to work (currently not needed)
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e) //If the Form2 is closed (by X corner) then trigger CloseGame()
        {
            CloseGame();
        }

        private void CloseGame()    //The method to close Form2 and reopen the main form
        {
            inventory.Reset();
            audio.StopMusic();
            FormManager.MainMenu.Show();    //Reference in FormManager.cs
        }


        private void Form2_Resize(object sender, EventArgs e)
        {
            player.FormResize(ClientSize.Width, ClientSize.Height); //Adjusts the new map boundaries to accomidate new map size
        }

        private void lblInventory_Click(object sender, EventArgs e) //Toggles the inventory inventory panel
        {
            if (pnlInventory.Visible == true)
                pnlInventory.Visible = false;
            else
                pnlInventory.Visible = true;
        }

        private void lblSettings_Click(object sender, EventArgs e) //Toggles the inventory inventory panel
        {
            if (pnlSettings.Visible == true)
                pnlSettings.Visible = false;
            else
                pnlSettings.Visible = true;
        }

        private void lblDay_Click(object sender, EventArgs e) //Changes to daytime map/music
        {
            this.BackgroundImage = Map.gameMaps[0];
            audio.PlayMusic(0);
        }

        private void lblNight_Click(object sender, EventArgs e) //Changes to nightttime map/music
        {
            this.BackgroundImage = Map.gameMaps[1];
            audio.PlayMusic(1);
        }

        private void lblMute_Click(object sender, EventArgs e) //Mutes any playing BGM
        {
            audio.StopMusic();
        }

        private void gameTime_Tick(object sender, EventArgs e) //Game timer to trigger various required game methods
        {
            NoFocus(); //Removes focus from any displayed control (currently redundant)

            while (inventory.SpawnedBird < 2) //Controls for bird spawning
            {
                ravenList.Add(new Bird(this, ClientSize.Width, ClientSize.Height));
                inventory.ChangeSpawn(true, 2);
            }

            while (inventory.SpawnedSticks < 5) //Controls stick spawning
            {
                stickList.Add(new Stick(this, ClientSize.Width, ClientSize.Height));
                inventory.ChangeSpawn(true, 0);
            }

            while (inventory.SpawnedStones < 5) //Controls stick spawning
            {
                stoneList.Add(new Stone(this, ClientSize.Width, ClientSize.Height));
                inventory.ChangeSpawn(true, 1);
            }

            lblPackOpen.BringToFront(); //This block keeps birds from flying over the 
            lblOpenSettings.BringToFront(); //menus or menu buttons
            pnlInventory.BringToFront();
            pnlSettings.BringToFront();


            if (playerKey == KeyMove.up) { player.MoveTop(true); player.TokenDir(0); } //This section updates the
            if (playerKey == KeyMove.right) { player.MoveLeft(false); player.TokenDir(1); } //tag of which way the player
            if (playerKey == KeyMove.down) { player.MoveTop(false); player.TokenDir(2); } //is facing -- required to know to
            if (playerKey == KeyMove.left) { player.MoveLeft(true); player.TokenDir(3); } //determine which way an arrow travels

            ArrowSpawn(); //Uses sticks and stones to craft arrows
            StoneController(); //Detects stone pickup
            StickController(); //Detects stick pickup
            BirdController(); //Detects bird collisions

            lblSticks.Text = "Sticks: " + inventory.InvStick.ToString();   //Displays # sticks in inventory
            lblStones.Text = "Stones: " + inventory.InvStone.ToString();   //Displays # stone in backback
            lblArrows.Text = "Arrows: " + inventory.InvArrow.ToString();   //Displays # arrows in backback
            lblScore.Text = "Score: " + inventory.Score.ToString();   //Displays the players score
        }

        private void StoneController() //Detects if a stone and player collide
        {
            for (int s = 0; s < stoneList.Count; s++)
            {
                if (stoneList[s].X + stoneList[s].Width < player.X)
                    continue;
                if (player.X + player.Width < stoneList[s].X)
                    continue;
                if (stoneList[s].Y + stoneList[s].Height < player.Y)
                    continue;
                if (player.Y + player.Height < stoneList[s].Y)
                    continue;
                else
                {
                    stoneList[s].Pickup(); //Triggers stone class method; which disposes the stone
                    stoneList.RemoveAt(s); //Remove the stone reference from stoneList
                    inventory.ChangeInv(true, 1); //Updates inventory value
                    inventory.ChangeSpawn(false, 1); //Updates the spawn trigger
                }
            }
        }

        private void StickController() //Detects if a stick and player collide
        {
            for (int i = 0; i < stickList.Count; i++)
            {
                if (stickList[i].X + stickList[i].Width < player.X)
                    continue;
                if (player.X + player.Width < stickList[i].X)
                    continue;
                if (stickList[i].Y + stickList[i].Height < player.Y)
                    continue;
                if (player.Y + player.Height < stickList[i].Y)
                    continue;
                else
                {
                    stickList[i].Pickup(); //Triggers stick class method; which disposes the stick
                    stickList.RemoveAt(i); //Remove the stone reference from stickList
                    inventory.ChangeInv(true, 0); //Updates inventory value
                    inventory.ChangeSpawn(false, 0); //Updates the spawn trigger
                }
            }
        }

        private void ArrowSpawn() //Manages arrows in inventory OR arrow destory
        {
            if (inventory.InvArrow < 12) //Only craft new arrows if the quiver is not full
                if (inventory.InvStick > 3 && inventory.InvStone > 3) //Checks collected sticks and stones
                {
                    inventory.ChangeInv(false, 0); //Remove stick
                    inventory.ChangeInv(false, 1); //Remove stone
                    inventory.ChangeInv(true, 2); //Craft arrow
                }

            if (arrowList.Count != 0) //Check for arrow and wall collision
            {
                for (int i = 0; i < arrowList.Count; i++)
                {
                    if (arrowList[i].X < 0 - arrowList[i].Width || arrowList[i].X > ClientSize.Width || arrowList[i].Y < 0 - arrowList[i].Y || arrowList[i].Y > ClientSize.Height)
                    {
                        {
                            arrowList[i].Die();
                            arrowList.RemoveAt(i);
                        }
                    }
                }
            }
        }

        public void BirdController()  //Detects if a stick and arrow collide OR if bird dies
        {
            if (arrowList.Count != 0)
                for (int i = 0; i < arrowList.Count; i++)
                {
                    for (int j = 0; j < ravenList.Count; j++)
                    {
                        if (ravenList[j].X + ravenList[j].Width < arrowList[i].X)
                            continue;
                        if (arrowList[i].X + arrowList[i].Width < ravenList[j].X)
                            continue;
                        if (ravenList[j].Y + ravenList[j].Height < arrowList[i].Y)
                            continue;
                        if (arrowList[i].Y + arrowList[i].Height < ravenList[j].Y)
                            continue;
                        else //if there is a collision:
                        {
                            arrowList[i].Die(); //Destroy arrow object
                            arrowList.RemoveAt(i); //Remove arrow from arrowList
                            ravenList[j].Die(); //Destroy bird objecy
                            ravenList.RemoveAt(j); //Remove bird from birdList
                            inventory.ChangeSpawn(false, 2); //Update bird spawning
                            inventory.ChangeScore(); //Update player kill score
                        }
                    }
                }

            for (int i = 0; i < ravenList.Count; i++) //Check for bird and wall collision
            {
                if (ravenList[i].X < 0 - ravenList[i].Width || ravenList[i].X > ClientSize.Width || ravenList[i].Y < 0 - ravenList[i].Y || ravenList[i].Y > ClientSize.Height)
                {
                    {
                        ravenList[i].Die();
                        ravenList.RemoveAt(i);
                        inventory.ChangeSpawn(false, 2);
                    }
                }
            }
        }

        private void moveKeyDown(object sender, KeyEventArgs e)  //For movement when a key is pressed down
        {
            if (e.KeyCode == Keys.Up) { playerKey = KeyMove.up; }
            if (e.KeyCode == Keys.Left) { playerKey = KeyMove.left; }
            if (e.KeyCode == Keys.Down) { playerKey = KeyMove.down; }
            if (e.KeyCode == Keys.Right) { playerKey = KeyMove.right; }
            if (e.KeyCode == Keys.Space)
            {
                playerKey = KeyMove.space;
                if (inventory.InvArrow != 0)
                {
                    arrowList.Add(new Arrow(this, ClientSize.Width, ClientSize.Height, player.pcTag, player.X, player.Y));
                    inventory.ChangeInv(false, 2); //Remove 1 arrow
                }
            }
        }

        private void moveKeyUp(object sender, KeyEventArgs e)   //For movement when a key is NOT pressed
        {
            if (e.KeyCode == Keys.Up) playerKey = KeyMove.none;
            if (e.KeyCode == Keys.Right) playerKey = KeyMove.none;
            if (e.KeyCode == Keys.Down) playerKey = KeyMove.none;
            if (e.KeyCode == Keys.Left) playerKey = KeyMove.none;
            if (e.KeyCode == Keys.Space) playerKey = KeyMove.none;
        }

        private void label1_Click(object sender, EventArgs e) //Cheat spawns in arrows
        {
            inventory.ChangeInv(true, 2); //Craft 3 arrows without other resources
        }
    }
}

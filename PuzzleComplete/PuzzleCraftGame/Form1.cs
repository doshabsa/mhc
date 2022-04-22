using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace PuzzleCraftGame
{
    public partial class Form1 : Form
    {
        //Some variables that will be used:
        Random rnd = new Random();
        Stopwatch stopWatch = new Stopwatch();
        double currentTime = 0;
        double lastShotTime = 0;
        string strFaceing = "up";
        int killScore = 0;
        int intHealth = 100;
        int intMoveSpeed = 10;
        int rabbitSpeed = 4;
        int wolfSpeed = 8;
        int wolfSpawnResult = 0;
        int intQuestTrack = 0;
        int equipmentTrack = 0;
        int spawnOnce = 0;
        int intCollector = 0;

        //Determines the size of the Form boundary (though, background will tile if expanded
        int boundLeft = 5;
        int boundRight = 780;
        int boundTop = 100;
        int boundBottom = 500;

        //Spawn item counters
        int StickSpawn = 0;
        int StoneSpawn = 0;

        //Inventory item counters
        int intStickPC = 0;
        int intStonePC = 0;
        int intArrowsPC = 0;
        int intMeatPC = 0;
        int intPeltPC = 0;
        int intCookedMeatPC = 0;

        //Token image holders----------------------------------------------Images
        Image PCTokenUp = Image.FromFile("PCtoken1Up.png");
        Image PCTokenDown = Image.FromFile("PCtoken1Down.png");
        Image PCTokenRight = Image.FromFile("PCtoken1Right.png");
        Image PCTokenLeft = Image.FromFile("PCtoken1Left.png");
        Image PCTokenDead = Image.FromFile("PCtoken1Dead.png");
        //Originally I wanted to add a selection tool so users could choose
        //between a couple different player tokens but I ran out of time before
        //implementing it

        //Map image variable holders
        Image area1 = Image.FromFile("area1.png");

        //Game sounds
        SoundPlayer craftSound = new SoundPlayer("Craft.wav");
        SoundPlayer arrowSound = new SoundPlayer("ArrowSound.wav");
        SoundPlayer bellSound = new SoundPlayer("bell.wav");
        SoundPlayer howlSound = new SoundPlayer("howl.wav");
        SoundPlayer tentSound = new SoundPlayer("tent.wav");
        SoundPlayer cookSound = new SoundPlayer("cook.wav");

        //For movement
        bool blMoveLeft, blMoveRight, blMoveUp, blMoveDown, blArrowShoot, blGameOver;

        //For item drops--------------------------------------------------------------------------------Item Spawns (fix if time)
        List<PictureBox> itemList = new List<PictureBox>();
        List<PictureBox> creatureList = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            //This portion was from Steve, helps with the PCtoken not image tearing
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //Title
            this.Text = "ITEC 140 - Simple Survival";

            //For game restarts on death, refreshes the game
            restartGame();
        }

        //This allows objects to become visible but not focus them; code from Steve caused issues but 
        //hunting online for a similar code brought me to this one. It originall did not have "null" 
        //but it worked when I tested it out - thank goodness!
        private void Form1_Load()
        {
            this.ActiveControl = null;
            return;
        }

        private void timeTrack(object sender, EventArgs e)
        {
            //Tracks health
            if (intHealth > 1)
            {
                if(intHealth < 60 && intCookedMeatPC > 0)
                {
                    intCookedMeatPC = intCookedMeatPC - 1;
                    intHealth = intHealth + 30;
                }
                prgHealthBar.Value = intHealth;
            }
            else
            {
                //Stops trackers in case of death, will start again when game restarts
                blGameOver = true;
                stopWatch.Stop();
                gameTime.Stop();
                craftSound.Stop();
                arrowSound.Stop();
                btnRestart.Visible = true;
                picPC.Image = PCTokenDead;
            }

            //Tracks inventory
            lblSticks.Text = intStickPC.ToString();
            lblStones.Text = intStonePC.ToString();
            lblMeat.Text = intMeatPC.ToString();
            lblCookedMeat.Text = intCookedMeatPC.ToString();
            lblPelt.Text = intPeltPC.ToString();
            lblArrowCounter.Text = intArrowsPC.ToString();
            lblKillScore.Text = "Kill Score: " + killScore.ToString();

            //Updates quest status
            updateQuest();
            craftArrows();

            //Sets boundaries around edges of the map
            if (blMoveLeft == true && picPC.Left > boundLeft)
            {
                picPC.Left -= intMoveSpeed;
            }
            if (blMoveRight == true && picPC.Right < boundRight)
            {
                picPC.Left += intMoveSpeed;
            }
            if (blMoveUp == true && picPC.Top > boundTop)
            {
                picPC.Top -= intMoveSpeed;
            }
            if (blMoveDown == true && picPC.Top + picPC.Height < boundBottom)
            {
                picPC.Top += intMoveSpeed;
            }

            //Updates and maintains the currently elapsed time -- for shot cooldowns
            currentTime = stopWatch.ElapsedMilliseconds;

            //Thank you Jason for the loop idea and Richard for his coin collection!
            foreach (Control x in this.Controls)
            {
                //Triggers stick spawns on map
                if (x is PictureBox && (string)x.Tag == "stick")
                {
                    if (picPC.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        intStickPC += 1;
                        StickSpawn -= 1;
                    }
                }
                //Trigges stone spawns on the map
                if (x is PictureBox && (string)x.Tag == "stone")
                {
                    if (picPC.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        intStonePC += 1;
                        StoneSpawn -= 1;
                    }
                }

                //The rabbit control box - Image from file did now allow left/right image positioning
                if (x is PictureBox && (string)x.Tag == "rabbit")
                {
                    if (x.Left > picPC.Left)
                    {
                        x.Left -= rabbitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rabbitLeft;
                    }
                    if (x.Left < picPC.Left)
                    {
                        x.Left += rabbitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rabbitRight;
                    }
                    if (x.Top > picPC.Top)
                    {
                        x.Top -= rabbitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rabbitUp;
                    }
                    if (x.Top < picPC.Top)
                    {
                        x.Top += rabbitSpeed;
                        ((PictureBox)x).Image = Properties.Resources.rabbitDown;
                    }
                }

                //Rabbit kill checker
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "arrow" && x is PictureBox && (string)x.Tag == "rabbit")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            killScore = killScore +1;

                            //Award item based on selection
                            if (intCollector == 1)
                            {
                                if (rdoPeltGather.Checked)
                                {
                                    intPeltPC = intPeltPC + 1;
                                }
                                if (rdoMeatGather.Checked)
                                {
                                    intMeatPC++;
                                }
                            }

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            creatureList.Remove(((PictureBox)x));
                            rabbitSpawn();
                        }
                    }
                }

                //The EXTRA wolf controls box
                if (x is PictureBox && (string)x.Tag == "wolf")
                {
                    if (picPC.Bounds.IntersectsWith(x.Bounds))
                    {
                        intHealth -= 5;
                    }

                    if (x.Left > picPC.Left)
                    {
                        x.Left -= wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolfLeft;
                    }
                    if (x.Left < picPC.Left)
                    {
                        x.Left += wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolfRight;
                    }
                    if (x.Top > picPC.Top)
                    {
                        x.Top -= wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolfUp;
                    }
                    if (x.Top < picPC.Top)
                    {
                        x.Top += wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolfDown;
                    }
                }

                //Wolf kill checker
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "arrow" && x is PictureBox && (string)x.Tag == "wolf")
                    {
                        if (picPC.Bounds.IntersectsWith(x.Bounds))
                        {
                            intHealth -= 5;
                        }

                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            killScore++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            creatureList.Remove(((PictureBox)x));

                            //Spawn amount generator
                            int wolfChance = rnd.Next(0, 1001);
                            if (wolfChance < 800)
                            {
                                wolfSpawnResult = 1;
                            }
                            if (wolfChance > 800 && wolfChance < 950)
                            {
                                wolfSpawnResult = 2;
                            }
                            if (wolfChance > 950)
                            {
                                wolfSpawnResult = 3;
                            }

                            switch (wolfSpawnResult)
                            {
                                case 1:
                                    wolfSpawn();
                                    break;
                                case 2:
                                    wolfSpawn();
                                    wolfSpawnExtra();
                                    break;
                                case 3:
                                    wolfSpawn();
                                    wolfSpawnExtra();
                                    wolfSpawnExtra();
                                    break;
                            }
                        }
                    }
                }
                //The EXTRA wolf controls box
                if (x is PictureBox && (string)x.Tag == "Ewolf")
                {
                    if (picPC.Bounds.IntersectsWith(x.Bounds))
                    {
                        intHealth -= 5;
                    }

                    if (x.Left > picPC.Left)
                    {
                        x.Left -= wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolf2Left;
                    }
                    if (x.Left < picPC.Left)
                    {
                        x.Left += wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolf2Right;
                    }
                    if (x.Top > picPC.Top)
                    {
                        x.Top -= wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolf2Up;
                    }
                    if (x.Top < picPC.Top)
                    {
                        x.Top += wolfSpeed;
                        ((PictureBox)x).Image = Properties.Resources.wolf2Down;
                    }
                }

                //Extra wolf kill checker
                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "arrow" && x is PictureBox && (string)x.Tag == "Ewolf")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            killScore++;

                            this.Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            this.Controls.Remove(x);
                            ((PictureBox)x).Dispose();
                            creatureList.Remove(((PictureBox)x));
                        }
                    }
                }
            }


        }

        private void spawnItems(object sender, EventArgs e)
        {
            //Spawns sticks
            if (intStickPC < 5)
            {
                if (StickSpawn < 1)
                {
                    StickSpawn = StickSpawn + 1;
                    spawnSticks();
                }
            }

            //Dependant of level of the equipment level unlocked
            if (equipmentTrack >= 1)
            {
                //Spawn stones
                if (intStonePC < 5)
                {
                    if (StoneSpawn < 1)
                    {
                        StoneSpawn = StoneSpawn + 1;
                        spawnStones();
                    }
                }
            }
            if (equipmentTrack == 2)
            {
                while (spawnOnce == 0)
                {
                    spawnOnce = 1;
                    rabbitSpawn();
                }
            }
            if (intQuestTrack == 6)
            {
                intQuestTrack = 7;
                wolfSpawn();
            }
        }

        private void moveKeyDown(object sender, KeyEventArgs e)
        {
            //If dead, will stop all movement
            if (blGameOver == true)
            {
                return;
            }    

            //For movement when a key is pressed down
            if (e.KeyCode == Keys.Left && picPC.Left > boundLeft)
            {
                picPC.Left -= intMoveSpeed;
                blMoveLeft = true;
                strFaceing = "left";
                picPC.Image = PCTokenLeft;
            }
            if (e.KeyCode == Keys.Right && picPC.Right < boundRight)
            {
                picPC.Left += intMoveSpeed;
                blMoveRight = true;
                strFaceing = "right";
                picPC.Image = PCTokenRight;
            }
            if (e.KeyCode == Keys.Up && picPC.Top > boundTop)
            {
                picPC.Top -= intMoveSpeed;
                blMoveUp = true;
                strFaceing = "up";
                picPC.Image = PCTokenUp;
            }
            if (e.KeyCode == Keys.Down && picPC.Top < boundBottom)
            {
                picPC.Top += intMoveSpeed;
                blMoveDown = true;
                strFaceing = "down";
                picPC.Image = PCTokenDown;
            }
        }

        private void moveKeyUp(object sender, KeyEventArgs e)
        {
            //For movement when a key is NOT pressed
            if (e.KeyCode == Keys.Left)
            {
                blMoveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                blMoveRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                blMoveUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                blMoveDown = false;
            }

            //Bow and arrow use if quest 1 is complete
            if (e.KeyCode == Keys.Space)
            {
                if (equipmentTrack >= 2)
                {
                    if (currentTime - lastShotTime > 500)
                    {
                        //Prevent shooting if dead, too
                        if (intArrowsPC > 0 && blGameOver == false)
                        {
                            intArrowsPC--;
                            arrowSound.Play();
                            arrowShoot(strFaceing);
                            lastShotTime = stopWatch.ElapsedMilliseconds;
                        }
                    }
                }
            }
        }

        //Spawn codes------------------------------------------------------Spawn codes
        //Pull the custom class and use it
        private void arrowShoot(string shootDiretion)
        {
            Arrow arrowShoot = new Arrow();
            //Determine which way it is going
            arrowShoot.shootDirection = shootDiretion;
            //It should come from the player token, not outside of it (looks weird)
            arrowShoot.arrowLeftSide = picPC.Left + (picPC.Width / 2);
            arrowShoot.arrowTopSide = picPC.Top + (picPC.Height / 2);
            arrowShoot.arrowCreate(this);
        }

        private void craftArrows()
        {
            //Includes arrow crafting as well as meat crafting
            if (chkCraftArrows.Checked && intArrowsPC < 10)
            {
                if (currentTime - lastShotTime > 1000)
                {
                    if (intStickPC >= 1)
                    {
                        if (intStonePC >= 1)
                        {
                            craftSound.Play();
                            intStonePC = intStonePC - 1;
                            intStickPC = intStickPC - 1;
                            intArrowsPC = intArrowsPC + 1;
                        }
                    }
                }
            }
            if (intQuestTrack >= 5 && intCookedMeatPC <1) 
            {
                if (currentTime - lastShotTime > 8000)
                {
                    if (intMeatPC >= 1)
                    {
                        if (intStickPC >= 1)
                        {
                            cookSound.Play();
                            intMeatPC = intMeatPC - 1;
                            intStickPC = intStickPC - 1;
                            intCookedMeatPC = intCookedMeatPC + 1;
                        }
                    }
                }
            }
            return;
        }

        private void rabbitSpawn()
        {
            PictureBox rabbit = new PictureBox();
            rabbit.Tag = "rabbit";
            rabbit.Image = Image.FromFile("rabbitUp.png");
            rabbit.Left = rnd.Next(10, this.ClientSize.Width - rabbit.Width);
            rabbit.Top = rnd.Next(108, this.ClientSize.Height - rabbit.Height);
            Size rabbitSize = new Size(25, 25);
            rabbit.Size = rabbitSize;
            rabbit.SizeMode = PictureBoxSizeMode.StretchImage;
            rabbit.BackColor = Color.Transparent;
            creatureList.Add(rabbit);
            this.Controls.Add(rabbit);
            picPC.BringToFront();
        }

        private void wolfSpawn()
        {
            PictureBox wolf = new PictureBox();
            wolf.Tag = "wolf";
            wolf.Image = Image.FromFile("wolfUp.png");
            wolf.Left = rnd.Next(10, this.ClientSize.Width - wolf.Width);
            wolf.Top = rnd.Next(108, this.ClientSize.Height - wolf.Height);
            Size wolfSize = new Size(60, 60);
            wolf.Size = wolfSize;
            wolf.SizeMode = PictureBoxSizeMode.StretchImage;
            wolf.BackColor = Color.Transparent;
            creatureList.Add(wolf);
            this.Controls.Add(wolf);
            picPC.BringToFront();
        }

        private void wolfSpawnExtra()
        {
            PictureBox ewolf = new PictureBox();
            ewolf.Tag = "Ewolf";
            ewolf.Image = Image.FromFile("wolf2Up.png");
            ewolf.Left = rnd.Next(10, this.ClientSize.Width - ewolf.Width);
            ewolf.Top = rnd.Next(108, this.ClientSize.Height - ewolf.Height);
            Size wolfSize = new Size(60, 60);
            ewolf.Size = wolfSize;
            ewolf.SizeMode = PictureBoxSizeMode.StretchImage;
            ewolf.BackColor = Color.Transparent;
            creatureList.Add(ewolf);
            this.Controls.Add(ewolf);
            picPC.BringToFront();
        }

        private void spawnSticks()
        {
            //Setting up spawning items was a nightmare -- THANK YOU STACKOVERFLOW
            PictureBox stick = new PictureBox();

            //Set the size for the sticks, make sure they fit
            Size stickSize = new Size(25, 21);
            stick.Size = stickSize;
            stick.SizeMode = PictureBoxSizeMode.StretchImage;
            stick.BackColor = Color.Transparent;
            stick.Image = Image.FromFile("stick" + rnd.Next(1, 5) + ".png");

            //Spawn within the boundary of the form
            stick.Left = rnd.Next(10, this.ClientSize.Width - stick.Width);
            stick.Top = rnd.Next(108, this.ClientSize.Height - stick.Height);

            //Tags track the item dropped
            stick.Tag = "stick";

            //Adds as needed
            itemList.Add(stick);
            this.Controls.Add(stick);

            //Bring to front?
            stick.BringToFront();
            picPC.BringToFront();
        }

        private void spawnStones()
        {
            PictureBox stone = new PictureBox();

            //Set the size for the sticks, make sure they fit
            Size stoneSize = new Size(25, 25);
            stone.Size = stoneSize;
            stone.SizeMode = PictureBoxSizeMode.StretchImage;
            stone.BackColor = Color.Transparent;
            stone.Image = Image.FromFile("stone" + rnd.Next(1, 5) + ".png");

            //Spawn within the boundary of the form
            stone.Left = rnd.Next(10, this.ClientSize.Width - stone.Width);
            stone.Top = rnd.Next(108, this.ClientSize.Height - stone.Height);

            //Tags track the item dropped
            stone.Tag = "stone";

            //Adds as needed
            itemList.Add(stone);
            this.Controls.Add(stone);

            //Bring to front?
            stone.BringToFront();
            picPC.BringToFront();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            restartGame();
            Form1_Load();
        }

        private void restartGame()
        {
            //Sets the default map image on load - can be changed with new zones?
            this.BackgroundImage = area1;

            //If health reaches zero, death and restart (not really implemented, monsters are wonky and something is missing)
            picPC.Image = PCTokenUp;

            foreach (PictureBox ewolf in creatureList)
            {
                this.Controls.Remove(ewolf);
            }
            foreach (PictureBox n in itemList)
            {
                this.Controls.Remove(n);
            }

            itemList.Clear();
            creatureList.Clear();

            //Need to stop all movement or else it's creepy!
            blMoveLeft = false;
            blMoveRight = false;
            blMoveUp = false;
            blMoveDown = false;
            blGameOver = false;

            //PC Health
            prgHealthBar.Value = 100;
            intHealth = 100;

            //Reset stats and inventory
            picStone.Visible = false;
            lblStones.Visible = false;

            chkCraftArrows.Checked = false;
            picArrows.Visible = false;
            lblArrowCounter.Visible = false;
            chkCraftArrows.Visible = false;
            lblKillScore.Visible = false;

            rdoPeltGather.Checked = false;
            rdoPeltGather.Visible = false;
            picPelt.Visible = false;
            lblPelt.Visible = false;

            rdoMeatGather.Checked = false; 
            rdoMeatGather.Visible = false;
            picMeat.Visible = false;
            lblMeat.Visible = false;

            picTent.Visible = false;
            picFire.Visible = false;

            picCookedMeat.Visible = false;
            lblCookedMeat.Visible = false;

            btnRestart.Visible = false;

            //Items
            intStickPC = 0;
            intStonePC = 0;
            intArrowsPC = 0;
            intMeatPC = 0;
            intPeltPC = 0;
            intCookedMeatPC = 0;
            killScore = 0;

            //Quest related
            spawnOnce = 0;
            intCollector = 0;
            equipmentTrack = 0;
            intQuestTrack = 0;
            StickSpawn = 0;
            StoneSpawn = 0;

            //Start game basics to restart
            gameTime.Start();
            stopWatch.Start();
            updateQuest();
        }

        private void updateQuest()
        {
            //Quest 1 ---- gather 5 sticks
            if (equipmentTrack == 0 && intQuestTrack == 0)
            {
                if (intStickPC >= 5)
                {
                    btnQuestComplete.Visible = true;

                    while (intQuestTrack == 0)
                    {
                        lblQuest.Text = "1. Click hand in to craft your bow and continue.";
                        bellSound.Play();
                        intQuestTrack = 1;
                    }
                }
            }

            //Quest 2 ---- gather 5 sticks and 5 stone
            if (equipmentTrack == 1 && intQuestTrack == 1)
            {
                if (intStickPC >= 5 && intStonePC >= 5)
                {
                    chkCraftArrows.Visible = true;
                    //Unfocuising this is found on the check event questTwo

                    while (intQuestTrack == 1)
                    {
                        lblQuest.Text = "2. Click the checkmark to automaticall craft arrows. It takes some time after your last shot to create new arrows, so be careful!";
                        bellSound.Play();
                        intQuestTrack = 2;
                    }
                }
            }

            //Quest 3 ---- shoot 3 rabbits
            if (equipmentTrack == 2 && intQuestTrack == 2)
            {
                if (killScore >= 3)
                {
                    rdoPeltGather.Visible = true;
                    lblPelt.Visible = true;
                    picPelt.Visible = true;

                    while (intQuestTrack == 2)
                    {
                        lblQuest.Text = "3. Select a toggle to prepare either raw meat or pelts.";
                        bellSound.Play();
                        intQuestTrack = 3;
                    }
                }
            }

            //Quest 4 ---- collect 5 pelts
            if (equipmentTrack == 3 && intQuestTrack == 3)
            {
                if (intPeltPC >= 5)
                {
                    //Buildings visible
                    picTent.Visible = true;
                    rdoMeatGather.Visible = true;

                    //Prevend rdo focus
                    Form1_Load();

                    while (intQuestTrack == 3)
                    {
                        lblQuest.Text = "5. Your home is built. Now to prepare your first meal, collect 5 sticks and 5 meat. (Toggle to meat collection!)";
                        tentSound.Play();
                        intQuestTrack = 4;
                    }
                }
            }

            //Quest 5 ---- cook 1 meat
            if (equipmentTrack == 4 && intQuestTrack == 4)
            {
                if (intStickPC >= 5 && intMeatPC >= 5)
                {
                    //Show cooking fire
                    picFire.Visible = true;

                    //Cooked meat show
                    picCookedMeat.Visible = true;
                    lblCookedMeat.Visible = true;

                    while (intQuestTrack == 4)
                    {
                        lblQuest.Text = "6. Smells good! It takes a couple seconds from your last arrow shot to create a meal.";
                        bellSound.Play();
                        intQuestTrack = 5;
                        equipmentTrack = 5;
                    }
                }
            }

            //Quest 6 ---- survive wolves
            if (equipmentTrack == 5 && intQuestTrack == 5)
            {
                if (intCookedMeatPC > 0)
                {
                    while (intQuestTrack == 5)
                    {
                        lblQuest.Text = "7. The smell has attracted wolves, good luck!";
                        howlSound.Play();
                        intQuestTrack = 6;
                        equipmentTrack = 6;
                    }
                }
            }
        }

        private void questOne(object sender, EventArgs e)
        {
            //Hand in first quest, enables crafting level 1
            intStickPC = intStickPC - 5;

            //Show stone inventory
            lblStones.Visible = true;
            picStone.Visible = true;

            //Updates quest and equipment trackers
            equipmentTrack = 1;
            btnQuestComplete.Visible = false;

            //Update quest text
            lblQuest.Text = "2. Gather 5 sticks and 5 stones to create your arrows.";
           
            //Prevent btn focus
            Form1_Load();
        }

        private void questTwo(object sender, EventArgs e)
        {
            if(intQuestTrack == 2 && equipmentTrack == 1)
            {
                //Hand in second quest, enables crafting level 2
                intStonePC = intStonePC - 5;
                intStickPC = intStickPC - 5;
                intArrowsPC = 5;

                //Show arrow inventory
                lblArrowCounter.Visible = true;
                picArrows.Visible = true;
                lblKillScore.Visible = true;

                //Updates quest and equipment trackers
                equipmentTrack = 2;

                //This enables arrow crafting
                intCollector = 1;

                //Update quest text
                lblQuest.Text = "3. Shoot three rabbits.";

                //Prevent chk focus
                Form1_Load();
            }
        }

        private void questThree(object sender, EventArgs e)
        {
            //Hand in second quest, enables crafting level 3
            equipmentTrack = 3;

            //Show pelt/meat inventory
            picPelt.Visible = true;
            lblPelt.Visible = true;

            //Update quest text
            lblQuest.Text = "4. Collect 5 pelts to build a tent.";

            //Prevent rdo focus
            Form1_Load();
        }

        private void questFour(object sender, EventArgs e)
        {
            //Hand in second quest, enables crafting level 3
            equipmentTrack = 4;

            //Meat track show
            rdoMeatGather.Visible = true;
            picMeat.Visible = true;
            lblMeat.Visible = true;

            //Update quest text
            lblQuest.Text = "5. Collect 5 meat and 5 sticks to prepare your fire.";

            //Prevent rdo focus
            Form1_Load();
        }
    }
}


namespace PuzzleCraftGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblHealth = new System.Windows.Forms.Label();
            this.prgHealthBar = new System.Windows.Forms.ProgressBar();
            this.grpInventory = new System.Windows.Forms.GroupBox();
            this.lblKillScore = new System.Windows.Forms.Label();
            this.picStick = new System.Windows.Forms.PictureBox();
            this.lblSticks = new System.Windows.Forms.Label();
            this.picStone = new System.Windows.Forms.PictureBox();
            this.lblStones = new System.Windows.Forms.Label();
            this.lblPelt = new System.Windows.Forms.Label();
            this.picMeat = new System.Windows.Forms.PictureBox();
            this.picPelt = new System.Windows.Forms.PictureBox();
            this.lblMeat = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            this.grpQuests = new System.Windows.Forms.GroupBox();
            this.btnQuestComplete = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblQuest = new System.Windows.Forms.Label();
            this.spawnTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlHUD = new System.Windows.Forms.Panel();
            this.picCookedMeat = new System.Windows.Forms.PictureBox();
            this.lblCookedMeat = new System.Windows.Forms.Label();
            this.rdoMeatGather = new System.Windows.Forms.RadioButton();
            this.rdoPeltGather = new System.Windows.Forms.RadioButton();
            this.chkCraftArrows = new System.Windows.Forms.CheckBox();
            this.picArrows = new System.Windows.Forms.PictureBox();
            this.lblArrowCounter = new System.Windows.Forms.Label();
            this.picFire = new System.Windows.Forms.PictureBox();
            this.picTent = new System.Windows.Forms.PictureBox();
            this.picPC = new System.Windows.Forms.PictureBox();
            this.grpInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPelt)).BeginInit();
            this.grpQuests.SuspendLayout();
            this.pnlHUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookedMeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPC)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.Location = new System.Drawing.Point(11, 11);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(58, 18);
            this.lblHealth.TabIndex = 0;
            this.lblHealth.Text = "Health: ";
            // 
            // prgHealthBar
            // 
            this.prgHealthBar.ForeColor = System.Drawing.Color.DarkGreen;
            this.prgHealthBar.Location = new System.Drawing.Point(64, 13);
            this.prgHealthBar.Name = "prgHealthBar";
            this.prgHealthBar.Size = new System.Drawing.Size(158, 16);
            this.prgHealthBar.TabIndex = 2;
            this.prgHealthBar.Value = 100;
            // 
            // grpInventory
            // 
            this.grpInventory.Controls.Add(this.lblKillScore);
            this.grpInventory.Controls.Add(this.picStick);
            this.grpInventory.Controls.Add(this.lblSticks);
            this.grpInventory.Controls.Add(this.picStone);
            this.grpInventory.Controls.Add(this.lblStones);
            this.grpInventory.Controls.Add(this.lblPelt);
            this.grpInventory.Controls.Add(this.picMeat);
            this.grpInventory.Controls.Add(this.picPelt);
            this.grpInventory.Controls.Add(this.lblMeat);
            this.grpInventory.Location = new System.Drawing.Point(623, 3);
            this.grpInventory.Name = "grpInventory";
            this.grpInventory.Size = new System.Drawing.Size(155, 84);
            this.grpInventory.TabIndex = 4;
            this.grpInventory.TabStop = false;
            this.grpInventory.Text = "Backpack:";
            // 
            // lblKillScore
            // 
            this.lblKillScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKillScore.Location = new System.Drawing.Point(6, 61);
            this.lblKillScore.Name = "lblKillScore";
            this.lblKillScore.Size = new System.Drawing.Size(143, 17);
            this.lblKillScore.TabIndex = 17;
            this.lblKillScore.Text = "Kill Score:";
            this.lblKillScore.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblKillScore.Visible = false;
            // 
            // picStick
            // 
            this.picStick.Image = global::PuzzleCraftGame.Properties.Resources.stick3;
            this.picStick.Location = new System.Drawing.Point(19, 19);
            this.picStick.Name = "picStick";
            this.picStick.Size = new System.Drawing.Size(25, 20);
            this.picStick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStick.TabIndex = 13;
            this.picStick.TabStop = false;
            // 
            // lblSticks
            // 
            this.lblSticks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSticks.Location = new System.Drawing.Point(19, 42);
            this.lblSticks.Name = "lblSticks";
            this.lblSticks.Size = new System.Drawing.Size(25, 17);
            this.lblSticks.TabIndex = 14;
            this.lblSticks.Text = "0";
            this.lblSticks.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // picStone
            // 
            this.picStone.Image = ((System.Drawing.Image)(resources.GetObject("picStone.Image")));
            this.picStone.Location = new System.Drawing.Point(50, 19);
            this.picStone.Name = "picStone";
            this.picStone.Size = new System.Drawing.Size(25, 20);
            this.picStone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStone.TabIndex = 15;
            this.picStone.TabStop = false;
            this.picStone.Visible = false;
            // 
            // lblStones
            // 
            this.lblStones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStones.Location = new System.Drawing.Point(50, 42);
            this.lblStones.Name = "lblStones";
            this.lblStones.Size = new System.Drawing.Size(25, 17);
            this.lblStones.TabIndex = 16;
            this.lblStones.Text = "0";
            this.lblStones.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblStones.Visible = false;
            // 
            // lblPelt
            // 
            this.lblPelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPelt.Location = new System.Drawing.Point(112, 42);
            this.lblPelt.Name = "lblPelt";
            this.lblPelt.Size = new System.Drawing.Size(25, 17);
            this.lblPelt.TabIndex = 12;
            this.lblPelt.Text = "0";
            this.lblPelt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPelt.Visible = false;
            // 
            // picMeat
            // 
            this.picMeat.Image = ((System.Drawing.Image)(resources.GetObject("picMeat.Image")));
            this.picMeat.Location = new System.Drawing.Point(81, 19);
            this.picMeat.Name = "picMeat";
            this.picMeat.Size = new System.Drawing.Size(25, 20);
            this.picMeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMeat.TabIndex = 9;
            this.picMeat.TabStop = false;
            this.picMeat.Visible = false;
            // 
            // picPelt
            // 
            this.picPelt.Image = ((System.Drawing.Image)(resources.GetObject("picPelt.Image")));
            this.picPelt.Location = new System.Drawing.Point(112, 19);
            this.picPelt.Name = "picPelt";
            this.picPelt.Size = new System.Drawing.Size(25, 20);
            this.picPelt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPelt.TabIndex = 11;
            this.picPelt.TabStop = false;
            this.picPelt.Visible = false;
            // 
            // lblMeat
            // 
            this.lblMeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeat.Location = new System.Drawing.Point(81, 42);
            this.lblMeat.Name = "lblMeat";
            this.lblMeat.Size = new System.Drawing.Size(25, 17);
            this.lblMeat.TabIndex = 10;
            this.lblMeat.Text = "0";
            this.lblMeat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblMeat.Visible = false;
            // 
            // gameTime
            // 
            this.gameTime.Enabled = true;
            this.gameTime.Tick += new System.EventHandler(this.timeTrack);
            // 
            // grpQuests
            // 
            this.grpQuests.Controls.Add(this.btnQuestComplete);
            this.grpQuests.Controls.Add(this.btnRestart);
            this.grpQuests.Controls.Add(this.lblQuest);
            this.grpQuests.Location = new System.Drawing.Point(231, 3);
            this.grpQuests.Name = "grpQuests";
            this.grpQuests.Size = new System.Drawing.Size(386, 84);
            this.grpQuests.TabIndex = 5;
            this.grpQuests.TabStop = false;
            this.grpQuests.Text = "Quests:";
            // 
            // btnQuestComplete
            // 
            this.btnQuestComplete.Location = new System.Drawing.Point(302, 16);
            this.btnQuestComplete.Name = "btnQuestComplete";
            this.btnQuestComplete.Size = new System.Drawing.Size(75, 23);
            this.btnQuestComplete.TabIndex = 3;
            this.btnQuestComplete.Text = "Hand In";
            this.btnQuestComplete.UseVisualStyleBackColor = true;
            this.btnQuestComplete.Visible = false;
            this.btnQuestComplete.Click += new System.EventHandler(this.questOne);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(48, 50);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(315, 27);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart?";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblQuest
            // 
            this.lblQuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuest.Location = new System.Drawing.Point(7, 16);
            this.lblQuest.Name = "lblQuest";
            this.lblQuest.Size = new System.Drawing.Size(288, 65);
            this.lblQuest.TabIndex = 0;
            this.lblQuest.Text = "1. Find 5 sticks to craft a bow.";
            // 
            // spawnTimer
            // 
            this.spawnTimer.Enabled = true;
            this.spawnTimer.Interval = 500;
            this.spawnTimer.Tick += new System.EventHandler(this.spawnItems);
            // 
            // pnlHUD
            // 
            this.pnlHUD.Controls.Add(this.picCookedMeat);
            this.pnlHUD.Controls.Add(this.lblCookedMeat);
            this.pnlHUD.Controls.Add(this.rdoMeatGather);
            this.pnlHUD.Controls.Add(this.rdoPeltGather);
            this.pnlHUD.Controls.Add(this.chkCraftArrows);
            this.pnlHUD.Controls.Add(this.lblHealth);
            this.pnlHUD.Controls.Add(this.picArrows);
            this.pnlHUD.Controls.Add(this.lblArrowCounter);
            this.pnlHUD.Controls.Add(this.grpInventory);
            this.pnlHUD.Controls.Add(this.grpQuests);
            this.pnlHUD.Controls.Add(this.prgHealthBar);
            this.pnlHUD.Location = new System.Drawing.Point(-1, -1);
            this.pnlHUD.Name = "pnlHUD";
            this.pnlHUD.Size = new System.Drawing.Size(786, 90);
            this.pnlHUD.TabIndex = 6;
            // 
            // picCookedMeat
            // 
            this.picCookedMeat.Image = ((System.Drawing.Image)(resources.GetObject("picCookedMeat.Image")));
            this.picCookedMeat.Location = new System.Drawing.Point(166, 41);
            this.picCookedMeat.Name = "picCookedMeat";
            this.picCookedMeat.Size = new System.Drawing.Size(25, 20);
            this.picCookedMeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCookedMeat.TabIndex = 15;
            this.picCookedMeat.TabStop = false;
            this.picCookedMeat.Visible = false;
            // 
            // lblCookedMeat
            // 
            this.lblCookedMeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCookedMeat.Location = new System.Drawing.Point(166, 64);
            this.lblCookedMeat.Name = "lblCookedMeat";
            this.lblCookedMeat.Size = new System.Drawing.Size(25, 17);
            this.lblCookedMeat.TabIndex = 16;
            this.lblCookedMeat.Text = "0";
            this.lblCookedMeat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCookedMeat.Visible = false;
            // 
            // rdoMeatGather
            // 
            this.rdoMeatGather.AutoSize = true;
            this.rdoMeatGather.Location = new System.Drawing.Point(14, 49);
            this.rdoMeatGather.Name = "rdoMeatGather";
            this.rdoMeatGather.Size = new System.Drawing.Size(84, 17);
            this.rdoMeatGather.TabIndex = 14;
            this.rdoMeatGather.TabStop = true;
            this.rdoMeatGather.Text = "Collect Meat";
            this.rdoMeatGather.UseVisualStyleBackColor = true;
            this.rdoMeatGather.Visible = false;
            this.rdoMeatGather.CheckedChanged += new System.EventHandler(this.questFour);
            // 
            // rdoPeltGather
            // 
            this.rdoPeltGather.AutoSize = true;
            this.rdoPeltGather.Location = new System.Drawing.Point(14, 65);
            this.rdoPeltGather.Name = "rdoPeltGather";
            this.rdoPeltGather.Size = new System.Drawing.Size(83, 17);
            this.rdoPeltGather.TabIndex = 13;
            this.rdoPeltGather.TabStop = true;
            this.rdoPeltGather.Text = "Collect Pelts";
            this.rdoPeltGather.UseVisualStyleBackColor = true;
            this.rdoPeltGather.Visible = false;
            this.rdoPeltGather.CheckedChanged += new System.EventHandler(this.questThree);
            // 
            // chkCraftArrows
            // 
            this.chkCraftArrows.AutoSize = true;
            this.chkCraftArrows.Location = new System.Drawing.Point(13, 32);
            this.chkCraftArrows.Name = "chkCraftArrows";
            this.chkCraftArrows.Size = new System.Drawing.Size(82, 17);
            this.chkCraftArrows.TabIndex = 6;
            this.chkCraftArrows.Text = "Craft arrows";
            this.chkCraftArrows.UseVisualStyleBackColor = true;
            this.chkCraftArrows.Visible = false;
            this.chkCraftArrows.Click += new System.EventHandler(this.questTwo);
            // 
            // picArrows
            // 
            this.picArrows.Image = global::PuzzleCraftGame.Properties.Resources.arrowInv;
            this.picArrows.Location = new System.Drawing.Point(197, 41);
            this.picArrows.Name = "picArrows";
            this.picArrows.Size = new System.Drawing.Size(25, 20);
            this.picArrows.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picArrows.TabIndex = 7;
            this.picArrows.TabStop = false;
            this.picArrows.Visible = false;
            // 
            // lblArrowCounter
            // 
            this.lblArrowCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrowCounter.Location = new System.Drawing.Point(197, 64);
            this.lblArrowCounter.Name = "lblArrowCounter";
            this.lblArrowCounter.Size = new System.Drawing.Size(25, 17);
            this.lblArrowCounter.TabIndex = 8;
            this.lblArrowCounter.Text = "0";
            this.lblArrowCounter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblArrowCounter.Visible = false;
            // 
            // picFire
            // 
            this.picFire.BackColor = System.Drawing.Color.Transparent;
            this.picFire.Image = ((System.Drawing.Image)(resources.GetObject("picFire.Image")));
            this.picFire.Location = new System.Drawing.Point(150, 148);
            this.picFire.Name = "picFire";
            this.picFire.Size = new System.Drawing.Size(41, 39);
            this.picFire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFire.TabIndex = 8;
            this.picFire.TabStop = false;
            this.picFire.Visible = false;
            // 
            // picTent
            // 
            this.picTent.BackColor = System.Drawing.Color.Transparent;
            this.picTent.Image = ((System.Drawing.Image)(resources.GetObject("picTent.Image")));
            this.picTent.Location = new System.Drawing.Point(-13, 87);
            this.picTent.Name = "picTent";
            this.picTent.Size = new System.Drawing.Size(127, 151);
            this.picTent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTent.TabIndex = 7;
            this.picTent.TabStop = false;
            this.picTent.Visible = false;
            // 
            // picPC
            // 
            this.picPC.BackColor = System.Drawing.Color.Transparent;
            this.picPC.Location = new System.Drawing.Point(541, 423);
            this.picPC.Name = "picPC";
            this.picPC.Size = new System.Drawing.Size(53, 53);
            this.picPC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPC.TabIndex = 3;
            this.picPC.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.picFire);
            this.Controls.Add(this.picTent);
            this.Controls.Add(this.pnlHUD);
            this.Controls.Add(this.picPC);
            this.Name = "Form1";
            this.Text = "ITEC 140 - Puzzle Game - Kayla Purcha";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moveKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moveKeyUp);
            this.grpInventory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picStone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPelt)).EndInit();
            this.grpQuests.ResumeLayout(false);
            this.pnlHUD.ResumeLayout(false);
            this.pnlHUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCookedMeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.ProgressBar prgHealthBar;
        private System.Windows.Forms.PictureBox picPC;
        private System.Windows.Forms.GroupBox grpInventory;
        private System.Windows.Forms.Timer gameTime;
        private System.Windows.Forms.GroupBox grpQuests;
        private System.Windows.Forms.Label lblQuest;
        private System.Windows.Forms.Timer spawnTimer;
        private System.Windows.Forms.Panel pnlHUD;
        private System.Windows.Forms.CheckBox chkCraftArrows;
        private System.Windows.Forms.Label lblArrowCounter;
        private System.Windows.Forms.PictureBox picArrows;
        private System.Windows.Forms.Label lblMeat;
        private System.Windows.Forms.PictureBox picMeat;
        private System.Windows.Forms.PictureBox picPelt;
        private System.Windows.Forms.RadioButton rdoMeatGather;
        private System.Windows.Forms.RadioButton rdoPeltGather;
        private System.Windows.Forms.Label lblPelt;
        private System.Windows.Forms.PictureBox picStick;
        private System.Windows.Forms.Label lblSticks;
        private System.Windows.Forms.PictureBox picStone;
        private System.Windows.Forms.Label lblStones;
        private System.Windows.Forms.Label lblKillScore;
        private System.Windows.Forms.PictureBox picCookedMeat;
        private System.Windows.Forms.Label lblCookedMeat;
        private System.Windows.Forms.PictureBox picTent;
        private System.Windows.Forms.PictureBox picFire;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnQuestComplete;
    }
}


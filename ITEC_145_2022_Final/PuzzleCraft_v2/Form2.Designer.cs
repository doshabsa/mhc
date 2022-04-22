
namespace PuzzleCraft_v2
{
    partial class Form2
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
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            this.lblSticks = new System.Windows.Forms.Label();
            this.lblStones = new System.Windows.Forms.Label();
            this.pnlInventory = new System.Windows.Forms.Panel();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblArrows = new System.Windows.Forms.Label();
            this.lblPackClose = new System.Windows.Forms.Label();
            this.lblPackOpen = new System.Windows.Forms.Label();
            this.CheaterArrows = new System.Windows.Forms.Label();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.lblMute = new System.Windows.Forms.Label();
            this.lblCloseSetting = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblNight = new System.Windows.Forms.Label();
            this.lblOpenSettings = new System.Windows.Forms.Label();
            this.pnlInventory.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameTime
            // 
            this.gameTime.Tick += new System.EventHandler(this.gameTime_Tick);
            // 
            // lblSticks
            // 
            this.lblSticks.AutoSize = true;
            this.lblSticks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSticks.ForeColor = System.Drawing.Color.Sienna;
            this.lblSticks.Location = new System.Drawing.Point(3, 31);
            this.lblSticks.Name = "lblSticks";
            this.lblSticks.Size = new System.Drawing.Size(58, 19);
            this.lblSticks.TabIndex = 0;
            this.lblSticks.Text = "Sticks: 0";
            // 
            // lblStones
            // 
            this.lblStones.AutoSize = true;
            this.lblStones.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStones.ForeColor = System.Drawing.Color.Sienna;
            this.lblStones.Location = new System.Drawing.Point(3, 50);
            this.lblStones.Name = "lblStones";
            this.lblStones.Size = new System.Drawing.Size(65, 19);
            this.lblStones.TabIndex = 1;
            this.lblStones.Text = "Stones: 0";
            // 
            // pnlInventory
            // 
            this.pnlInventory.BackColor = System.Drawing.Color.Linen;
            this.pnlInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInventory.Controls.Add(this.lblScore);
            this.pnlInventory.Controls.Add(this.lblArrows);
            this.pnlInventory.Controls.Add(this.lblPackClose);
            this.pnlInventory.Controls.Add(this.lblSticks);
            this.pnlInventory.Controls.Add(this.lblStones);
            this.pnlInventory.Location = new System.Drawing.Point(12, 9);
            this.pnlInventory.Name = "pnlInventory";
            this.pnlInventory.Size = new System.Drawing.Size(86, 114);
            this.pnlInventory.TabIndex = 3;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblScore.ForeColor = System.Drawing.Color.Maroon;
            this.lblScore.Location = new System.Drawing.Point(3, 88);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(63, 19);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Score: 0";
            // 
            // lblArrows
            // 
            this.lblArrows.AutoSize = true;
            this.lblArrows.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblArrows.ForeColor = System.Drawing.Color.Sienna;
            this.lblArrows.Location = new System.Drawing.Point(3, 69);
            this.lblArrows.Name = "lblArrows";
            this.lblArrows.Size = new System.Drawing.Size(67, 19);
            this.lblArrows.TabIndex = 5;
            this.lblArrows.Text = "Arrows: 0";
            // 
            // lblPackClose
            // 
            this.lblPackClose.AutoSize = true;
            this.lblPackClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPackClose.ForeColor = System.Drawing.Color.Sienna;
            this.lblPackClose.Location = new System.Drawing.Point(11, 0);
            this.lblPackClose.Name = "lblPackClose";
            this.lblPackClose.Size = new System.Drawing.Size(51, 21);
            this.lblPackClose.TabIndex = 4;
            this.lblPackClose.Text = "Close";
            this.lblPackClose.Click += new System.EventHandler(this.lblInventory_Click);
            // 
            // lblPackOpen
            // 
            this.lblPackOpen.AutoSize = true;
            this.lblPackOpen.BackColor = System.Drawing.Color.Linen;
            this.lblPackOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPackOpen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPackOpen.ForeColor = System.Drawing.Color.Sienna;
            this.lblPackOpen.Location = new System.Drawing.Point(12, 9);
            this.lblPackOpen.Name = "lblPackOpen";
            this.lblPackOpen.Size = new System.Drawing.Size(48, 23);
            this.lblPackOpen.TabIndex = 2;
            this.lblPackOpen.Text = "Pack";
            this.lblPackOpen.Click += new System.EventHandler(this.lblInventory_Click);
            // 
            // CheaterArrows
            // 
            this.CheaterArrows.AutoSize = true;
            this.CheaterArrows.Location = new System.Drawing.Point(1011, 571);
            this.CheaterArrows.Name = "CheaterArrows";
            this.CheaterArrows.Size = new System.Drawing.Size(85, 15);
            this.CheaterArrows.TabIndex = 4;
            this.CheaterArrows.Text = "CheaterArrows";
            this.CheaterArrows.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Linen;
            this.pnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSettings.Controls.Add(this.lblMute);
            this.pnlSettings.Controls.Add(this.lblCloseSetting);
            this.pnlSettings.Controls.Add(this.lblDay);
            this.pnlSettings.Controls.Add(this.lblNight);
            this.pnlSettings.Location = new System.Drawing.Point(1006, 9);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(86, 96);
            this.pnlSettings.TabIndex = 5;
            this.pnlSettings.Visible = false;
            // 
            // lblMute
            // 
            this.lblMute.AutoSize = true;
            this.lblMute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMute.ForeColor = System.Drawing.Color.Sienna;
            this.lblMute.Location = new System.Drawing.Point(4, 69);
            this.lblMute.Name = "lblMute";
            this.lblMute.Size = new System.Drawing.Size(77, 19);
            this.lblMute.TabIndex = 5;
            this.lblMute.Text = "Stop Music";
            this.lblMute.Click += new System.EventHandler(this.lblMute_Click);
            // 
            // lblCloseSetting
            // 
            this.lblCloseSetting.AutoSize = true;
            this.lblCloseSetting.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCloseSetting.ForeColor = System.Drawing.Color.Sienna;
            this.lblCloseSetting.Location = new System.Drawing.Point(11, 0);
            this.lblCloseSetting.Name = "lblCloseSetting";
            this.lblCloseSetting.Size = new System.Drawing.Size(51, 21);
            this.lblCloseSetting.TabIndex = 4;
            this.lblCloseSetting.Text = "Close";
            this.lblCloseSetting.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDay.ForeColor = System.Drawing.Color.Sienna;
            this.lblDay.Location = new System.Drawing.Point(4, 31);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(60, 19);
            this.lblDay.TabIndex = 0;
            this.lblDay.Text = "Daytime";
            this.lblDay.Click += new System.EventHandler(this.lblDay_Click);
            // 
            // lblNight
            // 
            this.lblNight.AutoSize = true;
            this.lblNight.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNight.ForeColor = System.Drawing.Color.Sienna;
            this.lblNight.Location = new System.Drawing.Point(4, 50);
            this.lblNight.Name = "lblNight";
            this.lblNight.Size = new System.Drawing.Size(70, 19);
            this.lblNight.TabIndex = 1;
            this.lblNight.Text = "Nighttime";
            this.lblNight.Click += new System.EventHandler(this.lblNight_Click);
            // 
            // lblOpenSettings
            // 
            this.lblOpenSettings.AutoSize = true;
            this.lblOpenSettings.BackColor = System.Drawing.Color.Linen;
            this.lblOpenSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpenSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOpenSettings.ForeColor = System.Drawing.Color.Sienna;
            this.lblOpenSettings.Location = new System.Drawing.Point(1006, 9);
            this.lblOpenSettings.Name = "lblOpenSettings";
            this.lblOpenSettings.Size = new System.Drawing.Size(74, 23);
            this.lblOpenSettings.TabIndex = 7;
            this.lblOpenSettings.Text = "Settings";
            this.lblOpenSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1104, 595);
            this.Controls.Add(this.pnlSettings);
            this.Controls.Add(this.lblOpenSettings);
            this.Controls.Add(this.CheaterArrows);
            this.Controls.Add(this.pnlInventory);
            this.Controls.Add(this.lblPackOpen);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1540, 830);
            this.MinimumSize = new System.Drawing.Size(770, 415);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.moveKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.moveKeyUp);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.pnlInventory.ResumeLayout(false);
            this.pnlInventory.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTime;
        private System.Windows.Forms.Label lblSticks;
        private System.Windows.Forms.Label lblStones;
        private System.Windows.Forms.Panel pnlInventory;
        private System.Windows.Forms.Label lblPackOpen;
        private System.Windows.Forms.Label lblPackClose;
        private System.Windows.Forms.Label lblArrows;
        private System.Windows.Forms.Label CheaterArrows;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblCloseSetting;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblNight;
        private System.Windows.Forms.Label lblOpenSettings;
        private System.Windows.Forms.Label lblMute;
        private System.Windows.Forms.Label lblScore;
    }
}
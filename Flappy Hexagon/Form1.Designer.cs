namespace Flappy_Hexagon
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
            this.pnlGame = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFrameCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFPSDisplay = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtLives = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrStep = new System.Windows.Forms.Timer(this.components);
            this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyModeCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalModeCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.infiniteLivesCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.drawHiddenHitboxesCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSpawnObstacle = new System.Windows.Forms.Timer(this.components);
            this.tmrTransform = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlGame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGame.Location = new System.Drawing.Point(0, 27);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(800, 800);
            this.pnlGame.TabIndex = 0;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtFrameCounter,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.txtFPSDisplay,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.txtLives});
            this.statusStrip.Location = new System.Drawing.Point(0, 837);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(841, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabel1.Text = "Frame";
            // 
            // txtFrameCounter
            // 
            this.txtFrameCounter.Name = "txtFrameCounter";
            this.txtFrameCounter.Size = new System.Drawing.Size(13, 17);
            this.txtFrameCounter.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(22, 17);
            this.toolStripStatusLabel3.Text = "     ";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabel4.Text = "FPS";
            // 
            // txtFPSDisplay
            // 
            this.txtFPSDisplay.Name = "txtFPSDisplay";
            this.txtFPSDisplay.Size = new System.Drawing.Size(13, 17);
            this.txtFPSDisplay.Text = "0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel2.Text = "        ";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabel5.Text = "Lives";
            // 
            // txtLives
            // 
            this.txtLives.Name = "txtLives";
            this.txtLives.Size = new System.Drawing.Size(19, 17);
            this.txtLives.Text = "10";
            // 
            // tmrStep
            // 
            this.tmrStep.Interval = 20;
            this.tmrStep.Tick += new System.EventHandler(this.tmrStep_Tick);
            // 
            // tmrRedraw
            // 
            this.tmrRedraw.Interval = 20;
            this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(841, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.CheckOnClick = true;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.infiniteLivesCheckBox,
            this.drawHiddenHitboxesCheckBox});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EasyModeCheckBox,
            this.NormalModeCheckBox});
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.easyToolStripMenuItem.Text = "Difficulty";
            // 
            // EasyModeCheckBox
            // 
            this.EasyModeCheckBox.Name = "EasyModeCheckBox";
            this.EasyModeCheckBox.Size = new System.Drawing.Size(114, 22);
            this.EasyModeCheckBox.Text = "Easy";
            this.EasyModeCheckBox.Click += new System.EventHandler(this.EasyModeCheckBox_Click);
            // 
            // NormalModeCheckBox
            // 
            this.NormalModeCheckBox.Checked = true;
            this.NormalModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NormalModeCheckBox.Name = "NormalModeCheckBox";
            this.NormalModeCheckBox.Size = new System.Drawing.Size(114, 22);
            this.NormalModeCheckBox.Text = "Normal";
            this.NormalModeCheckBox.Click += new System.EventHandler(this.NormalModeCheckBox_Click);
            // 
            // infiniteLivesCheckBox
            // 
            this.infiniteLivesCheckBox.CheckOnClick = true;
            this.infiniteLivesCheckBox.Name = "infiniteLivesCheckBox";
            this.infiniteLivesCheckBox.Size = new System.Drawing.Size(192, 22);
            this.infiniteLivesCheckBox.Text = "Infinite Lives";
            this.infiniteLivesCheckBox.Click += new System.EventHandler(this.infiniteLivesCheckBox_Click);
            // 
            // drawHiddenHitboxesCheckBox
            // 
            this.drawHiddenHitboxesCheckBox.CheckOnClick = true;
            this.drawHiddenHitboxesCheckBox.Name = "drawHiddenHitboxesCheckBox";
            this.drawHiddenHitboxesCheckBox.Size = new System.Drawing.Size(192, 22);
            this.drawHiddenHitboxesCheckBox.Text = "Draw Hidden Hitboxes";
            this.drawHiddenHitboxesCheckBox.Click += new System.EventHandler(this.drawHiddenHitboxesCheckBox_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tmrSpawnObstacle
            // 
            this.tmrSpawnObstacle.Interval = 2000;
            this.tmrSpawnObstacle.Tick += new System.EventHandler(this.tmrSpawnObstacle_Tick);
            // 
            // tmrTransform
            // 
            this.tmrTransform.Interval = 10000;
            this.tmrTransform.Tick += new System.EventHandler(this.tmrTransform_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 859);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pnlGame);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Flappy Hexagon";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel txtFrameCounter;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel txtFPSDisplay;
        private System.Windows.Forms.Timer tmrStep;
        private System.Windows.Forms.Timer tmrRedraw;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Timer tmrSpawnObstacle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel txtLives;
        private System.Windows.Forms.Timer tmrTransform;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EasyModeCheckBox;
        private System.Windows.Forms.ToolStripMenuItem NormalModeCheckBox;
        private System.Windows.Forms.ToolStripMenuItem infiniteLivesCheckBox;
        private System.Windows.Forms.ToolStripMenuItem drawHiddenHitboxesCheckBox;
    }
}


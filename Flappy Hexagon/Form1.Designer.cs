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
            this.tmrStep = new System.Windows.Forms.Timer(this.components);
            this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EasyModeCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalModeCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.classicModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrSpawnObstacle = new System.Windows.Forms.Timer(this.components);
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
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(841, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.CheckOnClick = true;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.classicModeToolStripMenuItem});
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
            // classicModeToolStripMenuItem
            // 
            this.classicModeToolStripMenuItem.Checked = true;
            this.classicModeToolStripMenuItem.CheckOnClick = true;
            this.classicModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.classicModeToolStripMenuItem.Name = "classicModeToolStripMenuItem";
            this.classicModeToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.classicModeToolStripMenuItem.Text = "Classic Mode";
            this.classicModeToolStripMenuItem.Click += new System.EventHandler(this.classicModeToolStripMenuItem_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 859);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pnlGame);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Flappy Hexagon";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrStep;
        private System.Windows.Forms.Timer tmrRedraw;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Timer tmrSpawnObstacle;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EasyModeCheckBox;
        private System.Windows.Forms.ToolStripMenuItem NormalModeCheckBox;
        private System.Windows.Forms.ToolStripMenuItem classicModeToolStripMenuItem;
    }
}


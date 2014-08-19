using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;
//using NAudio;
using NAudio.Wave;
//using NAudio.CoreAudioApi;
//using NAudio.Midi;

//time spent so far : ~6h
//TODO: Add highscores
namespace Flappy_Hexagon
{
    public partial class Form1 : Form
    {
        public const int initialLives = 1, internalWidth = 800, internalHeight = 800;
        DateTime previousFrameTime = DateTime.Now;
        public static int frame = 0, score = 0, lives = 100;
        public static float rotationAngle = 0, rotationSpeed = -10, rotationSegments = -90, degreesToRotate = 0;
        public static bool isRotating = false, started = false, easyMode = false, jumpQueued=false, drawGameOverScreen=false, drawHitboxes=false, infiniteLives=false;
        public static Panel GamePanel;
        public static List<Obstacle> obstacles = new List<Obstacle>();
        public static Player player;
        public static System.Drawing.Color[] bgColors = new[] { 
            System.Drawing.Color.FromArgb(78, 196, 59), 
            System.Drawing.Color.FromArgb(87, 93, 191), 
            System.Drawing.Color.FromArgb(191, 87, 153), 
            System.Drawing.Color.FromArgb(191, 37, 44),
            System.Drawing.Color.FromArgb(244, 121, 63),
            System.Drawing.Color.FromArgb(244, 226, 63)};
        public static System.Drawing.Color[] obstacleColors=new[]{
            System.Drawing.Color.FromArgb(48, 166, 29), 
            System.Drawing.Color.FromArgb(57, 63, 161), 
            System.Drawing.Color.FromArgb(161, 57, 123), 
            System.Drawing.Color.FromArgb(161, 7, 14),
            System.Drawing.Color.FromArgb(214, 91, 33),
            System.Drawing.Color.FromArgb(214, 196, 33)};

        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            pnlGame.Location = new Point(0, menuStrip.Height);
            pnlGame.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            pnlGame.Height = Screen.PrimaryScreen.Bounds.Height-menuStrip.Height-statusStrip.Height;
            pnlGame.SetDoubleBuffered();
            GamePanel = pnlGame;
            player = new Player(internalWidth / 2, internalHeight / 2);
            Properties.Resources.flappy_hexagon.PlaySound();
        }

        private void tmrStep_Tick(object sender, EventArgs e)
        {
            if(isRotating && Math.Abs(degreesToRotate)<=Math.Abs(rotationSpeed))
            {
                if (!easyMode)
                {
                    rotationAngle += degreesToRotate;
                }
                degreesToRotate = 0;
                isRotating=false;
            }
            else if (isRotating)
            {
                if (!easyMode)
                {
                    rotationAngle += rotationSpeed;
                }
                degreesToRotate -= rotationSpeed;
            }
            //if (!formIsRotating && jumpQueued)
            //{
            //    player.jump();
            //    jumpQueued = false;
            //    formIsRotating = true;
            //    formDegreesToRotate = rotationSegments;
            //}
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.step();
            }
            player.step();
            checkCollisions();
            //rotationAngle--;
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = now - previousFrameTime;
            previousFrameTime = now;

            frame++;
            try
            {
                txtFPSDisplay.Text = (1000f / (float)difference.Milliseconds).ToString().Substring(0, 4) + "(" + difference.Milliseconds.ToString() + "ms)";
            }
            catch
            { }

            txtFrameCounter.Text = frame.ToString();
            despawnObstacles();
            pnlGame.Refresh();
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLevel();
        }
        private void loadLevel()
        {
            score = 0;
            player = new Player(internalWidth / 2, internalHeight / 2);
            rotationSegments = -360 / player.sides;
            rotationAngle = 0;
            degreesToRotate = 0;
            rotationSpeed = -10;
            lives = infiniteLives ? 99999999 : initialLives;

            drawGameOverScreen = false;

            player.isRotating = true;
            player.degreesToRotate = rotationSegments;

            obstacles = new List<Obstacle>();
            started = true;
            tmrRedraw.Enabled = true;
            tmrStep.Enabled = true;
            tmrSpawnObstacle.Enabled = true;
            tmrTransform.Enabled = true;

            Properties.Resources.music1.PlaySound("BGM");
            Properties.Resources.start.PlaySound();
            Properties.Resources.hexagon.PlaySound();
        }

        private void gameOver()
        {
            tmrStep.Enabled = false;
            tmrSpawnObstacle.Enabled = false;
            tmrTransform.Enabled = false;
            started = false;
            drawGameOverScreen = true;
            Properties.Resources.die.PlaySound();
            if(ExtensionMethods.NowPlaying.ContainsKey("BGM"))
                ExtensionMethods.NowPlaying["BGM"].Stop();
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetShittyQuality();
            //e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            //e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            //e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            Bitmap b = new Bitmap(internalWidth > internalHeight ? internalWidth : internalHeight, internalWidth > internalHeight ? internalWidth : internalHeight);
            Graphics g = Graphics.FromImage(b);
            g.SetShittyQuality();
            //RotateTransform r = new RotateTransform(rotationAngle, b.Width / 2, b.Height / 2);
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.draw(g);
            }
            player.draw(g);
            //e.Graphics.DrawImage(b.rotateImage(rotationAngle), new Point(0,0));
            e.Graphics.DrawImage(b.rotateImage(rotationAngle), pnlGame.DisplayRectangle);
            //pnlGame.BackgroundImage = b.rotateImage(rotationAngle);

            System.Drawing.Font font = new System.Drawing.Font("Consolas", 50, FontStyle.Bold);

            if (!started)
            {
                drawGameOverScreen = false;
                tmrRedraw.Enabled = false;
                g = e.Graphics;
                g.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(120,System.Drawing.Color.Black)), 0, 0, pnlGame.Width, pnlGame.Height);
                Rectangle textRectangle = new Rectangle(0, 3 * pnlGame.Height / 4, pnlGame.Width, pnlGame.Height / 4);
                TextRenderer.DrawText(g, "Press [SPACE]", font, textRectangle, System.Drawing.Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak);
            }
            //Draw the Score
            SolidBrush fillBrush = drawGameOverScreen ? new SolidBrush(System.Drawing.Color.White) : new SolidBrush(System.Drawing.Color.Black);
            e.Graphics.DrawString(score.ToString(), font, fillBrush, internalWidth / 2 - 20, 100);
            b.Dispose();
            font.Dispose();
            fillBrush.Dispose();
            
        }

        private void tmrSpawnObstacle_Tick(object sender, EventArgs e)
        {
            obstacles.Add(new Obstacle(internalWidth>internalHeight?internalWidth:internalHeight));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //press space to start (if not started) or to jump/rotate
            if (e.KeyCode == Keys.Space && (!isRotating || player.sides==1))
            {
                if (started)
                {
                    if (isRotating && player.sides!=1)
                        jumpQueued = true;
                    else
                        player.jump();
                    isRotating = true;
                    degreesToRotate = rotationSegments;
                    player.isRotating = true;
                    player.degreesToRotate = rotationSegments;
                    
                }
                else
                    loadLevel();
            }
        }
        private void checkCollisions()
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (!obstacle.collided)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (obstacle.sides[i].IntersectsWith(player.rectangle))
                        {
                            lives--;
                            txtLives.Text = lives.ToString();
                            obstacle.collided = true;
                            if (lives == 0)
                                gameOver();
                        }
                    }
                }
                if (!obstacle.collided && !obstacle.scored)
                {
                    if (player.rectangle.IntersectsWith(obstacle.gap))
                    {
                        obstacle.scored = true;
                        score++;
                    }
                }
            }
        }

        private void tmrTransform_Tick(object sender, EventArgs e)
        {
            player.transform();
        }
        private void despawnObstacles()
        {
            foreach (Obstacle obstacle in obstacles)
            {
                if (obstacle.sides[0].X < -1000)
                {
                    obstacle.markedForDeletion = true;
                }
            }
            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                if (obstacles[i].markedForDeletion)
                    obstacles.RemoveAt(i);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void NormalModeCheckBox_Click(object sender, EventArgs e)
        {
            if (easyMode)
            {
                easyMode = false;
                EasyModeCheckBox.Checked = false;
                NormalModeCheckBox.Checked = true;
            }
        }

        private void EasyModeCheckBox_Click(object sender, EventArgs e)
        {
            if (!easyMode)
            {
                easyMode = true;
                EasyModeCheckBox.Checked = true;
                NormalModeCheckBox.Checked = false;
            }
        }

        private void infiniteLivesCheckBox_Click(object sender, EventArgs e)
        {
            infiniteLives = infiniteLivesCheckBox.Checked;
        }

        private void drawHiddenHitboxesCheckBox_Click(object sender, EventArgs e)
        {
            drawHitboxes = drawHiddenHitboxesCheckBox.Checked;
        }

        
    }
}

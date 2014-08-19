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
        //the game's obstacles' and background color are determined by what shape the plaer is
        //the following two arrays contain what colors the player should be at each stage
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
            //maximise the window and set it to borderless for pseudo-fullscreen mode
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            //resize the gamepanel to fill the screen
            pnlGame.Location = new Point(0, menuStrip.Height);
            pnlGame.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            pnlGame.Height = Screen.PrimaryScreen.Bounds.Height-menuStrip.Height-statusStrip.Height;
            //set the game panel to double buffered to eliminate flickering
            pnlGame.SetDoubleBuffered();
            //create a static reference to the game panel so it can be accessed elsewhere
            GamePanel = pnlGame;
            //create a new player object
            player = new Player(internalWidth / 2, internalHeight / 2);
            //play a sound announcing the name of the game
            Properties.Resources.flappy_hexagon.PlaySound();
        }

        private void tmrStep_Tick(object sender, EventArgs e)
        {
            //rotate the screen if necessary
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
            //move the obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.step();
            }
            //move the player
            player.step();
            //check for collisions between the player and any obstacles
            checkCollisions();
            //despawn any obstacles that have left the game area
            despawnObstacles();
        }

        private void tmrRedraw_Tick(object sender, EventArgs e)
        {
            //calculate the time since the previous frame
            DateTime now = DateTime.Now;
            TimeSpan difference = now - previousFrameTime;
            previousFrameTime = now;
            frame++;
            //display the framerate in the statusStrip
            try
            {
                txtFPSDisplay.Text = (1000f / (float)difference.Milliseconds).ToString().Substring(0, 4) + "(" + difference.Milliseconds.ToString() + "ms)";
            }
            catch
            { }
            txtFrameCounter.Text = frame.ToString();
            //force a redraw of the game panel
            pnlGame.Refresh();
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reset the game when the Start button is clicked
            loadLevel();
        }
        private void loadLevel()
        {
            //reset all game variables
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

            //start the BGM and play the starting sound effects
            Properties.Resources.music1.PlaySound("BGM");
            Properties.Resources.start.PlaySound();
            Properties.Resources.hexagon.PlaySound();
        }

        private void gameOver()
        {
            //when the game ends, stop the movement timer
            tmrStep.Enabled = false;
            tmrSpawnObstacle.Enabled = false;
            started = false;
            //tell the game to draw the game over screen
            drawGameOverScreen = true;
            //play the death sound
            Properties.Resources.die.PlaySound();
            //stop the BGM if it is playing
            if(ExtensionMethods.NowPlaying.ContainsKey("BGM"))
                ExtensionMethods.NowPlaying["BGM"].Stop();
        }

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            //set the gamepanel to fast drawing mode
            e.Graphics.SetShittyQuality();
            //create a new bitmap to draw to
            Bitmap b = new Bitmap(internalWidth > internalHeight ? internalWidth : internalHeight, internalWidth > internalHeight ? internalWidth : internalHeight);
            Graphics g = Graphics.FromImage(b);
            //set the bitmap to fast drawing mode
            g.SetShittyQuality();
            //draw the obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.draw(g);
            }
            //draw the player
            player.draw(g);
            //draw the bitmap to the gamepanel, rotated by a certain amount
            e.Graphics.DrawImage(b.rotateImage(rotationAngle), pnlGame.DisplayRectangle);
            //create a new font for drawing the score and instructions
            System.Drawing.Font font = new System.Drawing.Font("Consolas", 50, FontStyle.Bold);
            if (!started)
            {
                //if the game is not running, then draw a opaque black rectangle to fade the game out, then draw the "Press [Space]" prompt
                drawGameOverScreen = false;
                tmrRedraw.Enabled = false;
                g = e.Graphics;
                g.FillRectangle(new SolidBrush(System.Drawing.Color.FromArgb(120,System.Drawing.Color.Black)), 0, 0, pnlGame.Width, pnlGame.Height);
                Rectangle textRectangle = new Rectangle(0, 3 * pnlGame.Height / 4, pnlGame.Width, pnlGame.Height / 4);
                TextRenderer.DrawText(g, "Press [SPACE]", font, textRectangle, System.Drawing.Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak);
            }
            //draw the score at the upper middle of the screen
            SolidBrush fillBrush = drawGameOverScreen ? new SolidBrush(System.Drawing.Color.White) : new SolidBrush(System.Drawing.Color.Black);
            e.Graphics.DrawString(score.ToString(), font, fillBrush, internalWidth / 2 - 20, 100);
            //dispose of the font and brushes to free up memory
            b.Dispose();
            font.Dispose();
            fillBrush.Dispose();
        }

        private void tmrSpawnObstacle_Tick(object sender, EventArgs e)
        {
            //create a new obstacle at regular intervals
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
            //check for any collisions between the player and obstacles
            foreach (Obstacle obstacle in obstacles)
            {
                if (!obstacle.collided)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (obstacle.sides[i].IntersectsWith(player.rectangle))
                        {
                            //if the player has collided with the side of an obstacle, decrement number of lives
                            lives--;
                            txtLives.Text = lives.ToString();
                            obstacle.collided = true;
                            //if the player reaches 0 lives, then it is game over
                            if (lives == 0)
                                gameOver();
                        }
                    }
                }
                if (!obstacle.collided && !obstacle.scored)
                {
                    if (player.rectangle.IntersectsWith(obstacle.gap))
                    {
                        //if the player goes through the gap between the sides of an obstacle, then increment the score
                        obstacle.scored = true;
                        score++;
                        //every 5 points the player scores, they transform into a different polygon
                        if (score % 5 == 0)
                            player.transform();
                    }
                }
            }
        }

        private void despawnObstacles()
        {
            //despawn/delete obstacles after they move away from the game area
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
            //close the game upon clicking Exit
            Application.Exit();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //restart the whole application (hard reset) upon clicking Restart
            Application.Restart();
        }

        private void NormalModeCheckBox_Click(object sender, EventArgs e)
        {
            //unset easyMode if the player checks Normal Mode
            if (easyMode)
            {
                easyMode = false;
                EasyModeCheckBox.Checked = false;
                NormalModeCheckBox.Checked = true;
            }
        }

        private void EasyModeCheckBox_Click(object sender, EventArgs e)
        {
            //set easyMode is the player checks Easy Mode
            if (!easyMode)
            {
                easyMode = true;
                EasyModeCheckBox.Checked = true;
                NormalModeCheckBox.Checked = false;
            }
        }

        private void infiniteLivesCheckBox_Click(object sender, EventArgs e)
        {
            //toggle infiniteLives mode upon clicking Infinite Lives
            infiniteLives = infiniteLivesCheckBox.Checked;
        }

        private void drawHiddenHitboxesCheckBox_Click(object sender, EventArgs e)
        {
            //toggle drawing of hitboxes upon clicking Draw Hidden Hitboxes
            drawHitboxes = drawHiddenHitboxesCheckBox.Checked;
        }

        
    }
}

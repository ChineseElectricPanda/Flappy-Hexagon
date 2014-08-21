using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Flappy_Hexagon
{
    public class Obstacle
    {
        public static float scrollSpeed = -7;
        public static int minHeight = 150, maxHeight = 175, width = 50, padding=100;
        public static Random r = new Random();
        public static Color obstacleColor = Color.Black;

        public RectangleF[] sides;
        public RectangleF gap;
        public bool collided = false, scored = false, markedForDeletion=false;

        public Obstacle(int x)
        {
            //randomise the sides of the obstacle when it is created
            sides = new RectangleF[2];
            sides[0] = new RectangleF(x, -1000, width, 1000 + r.Next(padding, (Form1.internalHeight < Form1.internalWidth ? Form1.internalHeight : Form1.internalWidth - maxHeight - padding)));
            sides[1] = new RectangleF(x, sides[0].Y + sides[0].Height + r.Next(minHeight, maxHeight), width, 1000);
            gap = new RectangleF(x, sides[0].Y + sides[0].Height, width, sides[1].Y - sides[0].Y - sides[0].Height);
        }
        public void draw(Graphics g)
        {
            //draw the obstacle
            Brush b=new SolidBrush(obstacleColor);
            g.FillRectangles(b, sides);
            b.Dispose();
            if(Form1.drawHitboxes)
                g.FillRectangle(new SolidBrush(Color.Red), gap);
        }
        public void step()
        {
            //scroll the obstacle towards the other side of the screen
            sides[0].X += scrollSpeed;
            sides[1].X += scrollSpeed;
            gap.X += scrollSpeed;
        }
    }
}

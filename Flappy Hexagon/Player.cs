using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Media;

namespace Flappy_Hexagon
{
    public class Player
    {
        public static PointF[] line, triangle, rectanglePolygon, pentagon, hexagon, nanogon, octagon;
        public static int width=30, height=30;
        public static int maxSides = 8;
        public static float terminalVelocity = 10, gravity=0.7f, jumpForce=-10f, rotationSpeed=Form1.rotationSpeed;
        public static bool freezePosition = false;
        public static System.Drawing.Color playerColor = System.Drawing.Color.Gray;

        public RectangleF rectangle;
        public int sides = 6;
        public float speed = 0, yOffset=0, xOffset=0, rotation=0, degreesToRotate = 0;
        public bool isRotating = false;

        public Player(float x, float y)
        {
            Obstacle.obstacleColor = Form1.obstacleColors[sides - 1];
            Form1.GamePanel.BackColor = Form1.bgColors[sides - 1];
            rotation -= 360 / sides;
            xOffset = x - width * 2;
            yOffset = y - width *2;
            rectangle = new RectangleF(x - width / 2, y - width / 2, width, height);
            line = new[]{
                new PointF(width/2-2,0),
                new PointF(width/2+2,0),
                new PointF(width/2+2,height),
                new PointF(width/2-2,height)
            };
            triangle=new[] {
                new PointF(0,rectangle.Height),
                new PointF(rectangle.Width , rectangle.Height),
                new PointF(rectangle.Width/2 , 0)
            };
            rectanglePolygon = new[]{
                new PointF(0,0),
                new PointF(width, 0),
                new PointF(width, height),
                new PointF(0,height)
            };
            pentagon = new[] {
                new PointF(width/2, 0),
                new PointF(width, height/3 ),
                new PointF(4*width/5, height),
                new PointF(width/5, height),
                new PointF(0,height/3)
            };
            hexagon = new[] {
                new PointF(2*width/7, 0),
                new PointF(5*width/7, 0),
                new PointF(width, height/2),
                new PointF(5*width/7, height),
                new PointF(2*width/7, height),
                new PointF(0,height/2)
            };
            
        }
        public void draw(Graphics g)
        {
            if (!Form1.drawGameOverScreen)
            {
                Bitmap b = new Bitmap(width * 4, height * 4);
                Graphics bg = Graphics.FromImage(b);
                bg.SetShittyQuality();
                //bg.DrawRectangle(new System.Drawing.Pen(new SolidBrush(System.Drawing.Color.YellowGreen)), 0, 0, b.Width-1 , b.Height-1);
                bg.TranslateTransform(b.Width / 2 - width / 2, b.Height / 2 - height / 2);
                //RotateTransform r = new RotateTransform(Form1.rotationAngle, b.Width / 2, b.Height / 2);
                SolidBrush brush = new SolidBrush(playerColor);
                switch (sides)
                {
                    case 1:
                        //bg.FillEllipse(brush, rectangle);
                        bg.FillEllipse(brush, 0, 0, width, height);
                        break;
                    case 2:
                        bg.FillPolygon(brush, line);
                        break;
                    case 3:
                        bg.FillPolygon(brush, triangle);
                        break;
                    case 4:
                        bg.FillPolygon(brush, rectanglePolygon);
                        break;
                    case 5:
                        bg.FillPolygon(brush, pentagon);
                        break;
                    case 6:
                        bg.FillPolygon(brush, hexagon);
                        break;
                }
                brush.Dispose();
                if(Form1.drawHitboxes)
                    g.FillRectangle(new SolidBrush(System.Drawing.Color.Red), rectangle);
                g.DrawImage(b.rotateImage(rotation), new PointF(xOffset, yOffset));
            }
        }

        public void step()
        {
            if (isRotating && Math.Abs(degreesToRotate) <= Math.Abs(rotationSpeed))
            {
                rotation -= degreesToRotate;
                degreesToRotate = 0;
                isRotating = false;
            }
            else if (isRotating)
            {
                rotation -= rotationSpeed;
                degreesToRotate -= rotationSpeed;
            }
            Form1.rotationSegments = -360/sides;
            if(!freezePosition)
                speed += gravity;
            if (speed > terminalVelocity)
                speed = terminalVelocity;
            yOffset += speed;
            rectangle.Location = new PointF(xOffset + width*1.5f, yOffset+height*1.5f);
            if (sides == 1)
            {
                Form1.degreesToRotate = 99999;
                Form1.isRotating = true;
                Form1.rotationSpeed = -5;
            }
        }
        public void transform()
        {
            if (sides > 1)
            {
                sides--;
                switch (sides)
                {
                    case 1:
                        Properties.Resources.circle.PlaySound();
                        break;
                    case 2:
                        Properties.Resources.line.PlaySound();
                        break;
                    case 3:
                        Properties.Resources.triangle.PlaySound();
                        break;
                    case 4:
                        Properties.Resources.square.PlaySound();
                        break;
                    case 5:
                        Properties.Resources.pentagon.PlaySound();
                        break;
                    case 6:
                        Properties.Resources.hexagon.PlaySound();
                        break;
                }
            }
            Obstacle.obstacleColor = Form1.obstacleColors[sides - 1];
            Form1.GamePanel.BackColor = Form1.bgColors[sides - 1];
        }
        public void jump()
        {
            if(!freezePosition)
                speed = jumpForce;
            
        }

    }
}

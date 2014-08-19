using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using NAudio.Wave;

namespace Flappy_Hexagon
{
    //Extension methods for certain utility functions
    public static class ExtensionMethods
    {
        public static Dictionary<string,IWavePlayer> NowPlaying=new Dictionary<string,IWavePlayer>();
        public static void SetDoubleBuffered(this System.Windows.Forms.Control c)
        {
            //sets the specified form control to double buffer, by setting its DoubleBuffered flag
            //disclaimer: code by Ian Boyd on StackOverflow here: http://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form
            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        public static Bitmap rotateImage(this Bitmap i, float angle)
        {
            //rotate an image about its center by translating it, rotating it, then translating it back
            Bitmap b = new Bitmap(i.Width, i.Height);
            Graphics g = Graphics.FromImage(b);
            g.SetShittyQuality();
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(angle);
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(i, new Point(0, 0));
            return b;
        }
        public static void PlaySound(this System.IO.UnmanagedMemoryStream sound, string name = "")
        {
            //create a WaveStream using the NAudio library to play the specified sound in the background (without interrupting normal program flow)
            IWavePlayer waveOutDevice = new WaveOut();
            WaveStream wmaReader = new WaveFileReader(sound);
            WaveChannel32 volumeStream = new WaveChannel32(wmaReader);
            WaveStream outputStream = volumeStream;
            waveOutDevice.Init(outputStream);
            waveOutDevice.Play();
            //if a sound of the specified name is already playing, then stop it and play it from the start
            if (name.Length > 0)
            {
                if (NowPlaying.ContainsKey(name))
                {
                    NowPlaying[name].Stop();
                    NowPlaying[name] = waveOutDevice;
                }

                else
                    NowPlaying.Add(name, waveOutDevice);
            }
        }
        public static void SetShittyQuality(this Graphics g)
        {
            //set the specified GDI drawing surface to use faster rendering methods
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingQuality = CompositingQuality.HighSpeed;
        }
    }
}

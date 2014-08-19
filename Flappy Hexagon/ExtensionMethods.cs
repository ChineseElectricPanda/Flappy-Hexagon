using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using NAudio.Wave;

namespace Flappy_Hexagon
{
    public static class ExtensionMethods
    {
        public static Dictionary<string,IWavePlayer> NowPlaying=new Dictionary<string,IWavePlayer>();
        public static void SetDoubleBuffered(this System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        public static Bitmap rotateImage(this Bitmap i, float angle)
        {
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
            IWavePlayer waveOutDevice = new WaveOut();
            WaveStream wmaReader = new WaveFileReader(sound);
            WaveChannel32 volumeStream = new WaveChannel32(wmaReader);
            WaveStream outputStream = volumeStream;
            waveOutDevice.Init(outputStream);
            waveOutDevice.Play();
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
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.CompositingQuality = CompositingQuality.HighSpeed;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphs
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        String byteCode;

        public Form1()
        {
            InitializeComponent();
            initGraph();
            initScheme();
            if (!GetMACAddress().Equals("00FFB736C5F7"))
            {
                okButton.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
            }
            else
            {
                button12.Enabled = false;
                button12.Text = "";
            }
        }
        
        void initGraph()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            pen = new Pen(Color.Black);
        }

        void initScheme()
        {
            pen = new Pen(Color.Blue);
            int step = 20;
            for (int x = 0; x<=pictureBox1.Width; x += step)
                for (int y = 0; y <= pictureBox1.Height; y += step)
                {
                    g.DrawLine(pen, x, y, x + step, y);
                    if (x  % 40 == 0) pen.Width = 2;
                    g.DrawLine(pen, x, y, x, y + step);
                    pen.Width = 1;
                }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            byteCode = "";
            byteCode = textForCode.Text;
            Console.WriteLine(byteCode.Length);
            Console.WriteLine(byteCode[0]);
            try
            {
                label1.Text = byteCode[0].ToString();
                label2.Text = byteCode[1].ToString();
                label3.Text = byteCode[2].ToString();
                label4.Text = byteCode[3].ToString();
                label5.Text = byteCode[4].ToString();
                label6.Text = byteCode[5].ToString();
                label7.Text = byteCode[6].ToString();
                label8.Text = byteCode[7].ToString();
            } catch
            {
                
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i=0; i < byteCode.Length; i++)
            {   
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                } else
                {
                    drawSin(0.5f, 1, xz, yz);
                }
                
                xz = xz + 40;
            }
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i = 0; i < byteCode.Length; i++)
            {
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                    xz = xz + 40;
                }
                else
                {
                    xz -= 5;
                    drawSin(1, 0.5f, xz, yz, 10);
                    xz = xz + 20;
                    drawSin(1, 0.5f, xz, yz, 10);
                    xz = xz + 25;
                }

                
            }
            pictureBox1.Refresh();
        }

        void drawSin(float amp, float freq, int xz, int yz, int space=20)
        {
            pen = new Pen(Color.Black);
            pen.Width = 2;
            float x1, y1, x2, y2, alpha;
            for (alpha = 3.15f; alpha <= 6.25f;)
            {
                x1 = (float)Math.Cos(alpha) * 10 * freq + xz;
                y1 = (float)Math.Sin(alpha) * 40 * amp + yz;
                alpha += 0.1f;
                x2 = (float)Math.Cos(alpha) * 10 * freq + xz;
                y2 = (float)Math.Sin(alpha) * 40 * amp + yz;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            for (alpha = 0; alpha <= 3;)
            {
                x1 = (float)Math.Cos(alpha) * 10 * freq + xz + space;
                y1 = (float)Math.Sin(alpha) * 40 * amp + yz;
                alpha += 0.1f;
                x2 = (float)Math.Cos(alpha) * 10 * freq + xz + space;
                y2 = (float)Math.Sin(alpha) * 40 * amp + yz;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }
        void drawSinReverse(float amp, float freq, int xz, int yz, int space = 20)
        {
            pen = new Pen(Color.Black);
            pen.Width = 2;
            float x1, y1, x2, y2, alpha;
            for (alpha = 3.15f; alpha <= 6.25f;)
            {
                x1 = (float)Math.Cos(alpha) * 10 * freq + xz + space;
                y1 = (float)Math.Sin(alpha) * 40 * amp + yz;
                alpha += 0.1f;
                x2 = (float)Math.Cos(alpha) * 10 * freq + xz + space;
                y2 = (float)Math.Sin(alpha) * 40 * amp + yz;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
            for (alpha = 0; alpha <= 3;)
            {
                x1 = (float)Math.Cos(alpha) * 10 * freq + xz;
                y1 = (float)Math.Sin(alpha) * 40 * amp + yz;
                alpha += 0.1f;
                x2 = (float)Math.Cos(alpha) * 10 * freq + xz;
                y2 = (float)Math.Sin(alpha) * 40 * amp + yz;
                g.DrawLine(pen, x1, y1, x2, y2);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i = 0; i < byteCode.Length; i++)
            {
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                    xz = xz + 40;
                }
                else
                {
                    xz -= 5;
                    drawSin(0.5f, 0.5f, xz, yz, 10);
                    xz = xz + 20;
                    drawSin(0.5f, 0.5f, xz, yz, 10);
                    xz = xz + 25;
                }


            }
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i = 0; i < byteCode.Length; i++)
            {
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                    xz = xz + 40;
                }
                else
                {
                    drawSinReverse(1, 1, xz, yz);
                    xz = xz + 40;
                }


            }
            pictureBox1.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i = 0; i < byteCode.Length; i++)
            {
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                    xz = xz + 40;
                }
                else
                {
                    drawSinReverse(0.5f, 1, xz, yz);
                    xz = xz + 40;
                }
            }
            pictureBox1.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            initScheme();
            int xz = 50;
            int yz = 60;
            for (int i = 0; i < byteCode.Length; i++)
            {
                if (byteCode[i].Equals('1'))
                {
                    drawSin(1, 1, xz, yz);
                    xz = xz + 40;
                }
                else
                {
                    xz -= 5;
                    drawSinReverse(0.5f, 0.5f, xz, yz, 10);
                    xz = xz + 20;
                    drawSinReverse(0.5f, 0.5f, xz, yz, 10);
                    xz = xz + 25;
                }


            }
            pictureBox1.Refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int y = 100;
            int x = 40;
            g.Clear(Color.White);
            initScheme();
            pen = new Pen(Color.Black);
            pen.Width = 2;
            for (int i = 0; i < byteCode.Length; i++)
            {
                
                if (byteCode[i].Equals('1'))
                    g.DrawLine(pen, x, y, x + 40, y);
                else
                {
                    if (i > 0 && !byteCode[i - 1].Equals('0'))
                        g.DrawLine(pen, x, y, x, y - 40);
                    g.DrawLine(pen, x, y-40, x + 40, y-40);
                    if (i > 0 && i < byteCode.Length-1 && !byteCode[i + 1].Equals('0'))
                        g.DrawLine(pen, x+40, y-40, x+40, y);
                }
                x += 40;
                
            }
            pictureBox1.Refresh();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bool wasOne = false;
            int y = 80;
            int x = 40;
            g.Clear(Color.White);
            initScheme();
            pen = new Pen(Color.Black);
            pen.Width = 2;
            for (int i = 0; i < byteCode.Length; i++)
            {

                if (byteCode[i].Equals('1') && wasOne == false)
                {
                    g.DrawLine(pen, x, y, x, y - 20);
                    g.DrawLine(pen, x, y - 20, x + 40, y - 20);
                    g.DrawLine(pen, x + 40, y - 20, x + 40, y);
                    wasOne = true;
                } else if (wasOne == true && byteCode[i].Equals('1'))
                {
                    g.DrawLine(pen, x, y, x, y + 20);
                    g.DrawLine(pen, x, y + 20, x + 40, y + 20);
                    g.DrawLine(pen, x + 40, y + 20, x + 40, y);
                    wasOne = false;
                }
                else
                {
                    g.DrawLine(pen, x, y, x+40, y);
                }
                x += 40;

            }
            pictureBox1.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int y = 80;
            int x = 40;
            g.Clear(Color.White);
            initScheme();
            pen = new Pen(Color.Black);
            pen.Width = 2;
            for (int i = 0; i < byteCode.Length; i++)
            {

                if (byteCode[i].Equals('1'))
                {
                    g.DrawLine(pen, x, y, x, y - 20);
                    g.DrawLine(pen, x, y - 20, x + 20, y - 20);
                    g.DrawLine(pen, x + 20, y - 20, x + 20, y);
                    g.DrawLine(pen, x + 20, y, x + 40, y);
                }
                   
                else
                {
                    g.DrawLine(pen, x, y, x, y + 20);
                    g.DrawLine(pen, x, y + 20, x + 20, y + 20);
                    g.DrawLine(pen, x + 20, y + 20, x + 20, y);
                    g.DrawLine(pen, x + 20, y, x + 40, y);
                }
                x += 40;

            }
            pictureBox1.Refresh();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int y = 100;
            int x = 40;
            g.Clear(Color.White);
            initScheme();
            pen = new Pen(Color.Black);
            pen.Width = 2;
            for (int i = 0; i < byteCode.Length; i++)
            {

                if (byteCode[i].Equals('1'))
                {
                    
                    g.DrawLine(pen, x, y, x + 20, y);
                    g.DrawLine(pen, x + 20, y, x + 20, y - 40);
                    g.DrawLine(pen, x + 20, y - 40, x + 40, y - 40);
                    if (i > 0 && byteCode[i - 1].Equals('1'))
                        g.DrawLine(pen, x, y - 40, x, y);

                }
                else
                {
                    g.DrawLine(pen, x, y - 40, x + 20, y - 40);
                    g.DrawLine(pen, x + 20, y - 40, x + 20, y);
                    g.DrawLine(pen, x + 20, y, x + 40, y);
                    if (i > 0 && byteCode[i - 1].Equals('0'))
                        g.DrawLine(pen, x, y - 40, x, y);
                }
                x += 40;

            }
            pictureBox1.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label9.Text = "+3";
            label10.Text = "+1";
            label11.Text = "-1";
            label12.Text = "-3";
            try
            {
                label13.Text = byteCode.Substring(0,2);
                label14.Text = byteCode.Substring(2,2);
                label15.Text = byteCode.Substring(4,2);
                label16.Text = byteCode.Substring(6,2);
            }
            catch { }
            
            int y = 80;
            int x = 40;
            g.Clear(Color.White);
            initScheme();
            pen = new Pen(Color.Red);
            g.DrawLine(pen, x - 20, y, x + 40 * byteCode.Length, y);
            pen = new Pen(Color.Black);
            pen.Width = 2;
            for (int i = 0; i < byteCode.Length; i+=2)
            {
                if (byteCode[i].Equals('0') && byteCode[i + 1].Equals('0'))
                {
                    g.DrawLine(pen, x, y, x, y+40);
                    g.DrawLine(pen, x, y+40, x+40, y+40);
                    g.DrawLine(pen, x+40, y+40, x+40, y);
                } else if (byteCode[i].Equals('0') && byteCode[i + 1].Equals('1'))
                {
                    g.DrawLine(pen, x, y, x, y + 20);
                    g.DrawLine(pen, x, y + 20, x + 40, y + 20);
                    g.DrawLine(pen, x + 40, y + 20, x + 40, y);
                } else if (byteCode[i].Equals('1') && byteCode[i + 1].Equals('1'))
                {
                    g.DrawLine(pen, x, y, x, y - 20);
                    g.DrawLine(pen, x, y - 20, x + 40, y - 20);
                    g.DrawLine(pen, x + 40, y - 20, x + 40, y);
                } else
                {
                    g.DrawLine(pen, x, y, x, y - 40);
                    g.DrawLine(pen, x, y - 40, x + 40, y - 40);
                    g.DrawLine(pen, x + 40, y - 40, x + 40, y);
                }
                    x += 40;
            }
            pictureBox1.Refresh();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

      
        public string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                   
                }
            }
            return sMacAddress;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            label17.Text = GetMACAddress();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            g.Clear(Color.White);
            initScheme();
            pictureBox1.Refresh();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("cmd.exe", "/C " + "Examen.exe");
        }
    }
}

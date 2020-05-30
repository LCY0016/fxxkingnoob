using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project11
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
            {
                graphics = this.panel1.CreateGraphics();
                int n;
                int.TryParse(textBox1.Text, out n);
                double length;
                double.TryParse(textBox2.Text, out length);
                int x0 = this.panel1.Width / 2;
                int y0 = this.Height / 2;
                drawCayleyTree(n, x0, y0, length, -Math.PI / 2);
            }
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double th1;
            double.TryParse(trackBar1.Value.ToString(), out th1);
            double th2;
            double.TryParse(trackBar2.Value.ToString(), out th2);
            double per1;
            double.TryParse(textBox5.Text, out per1);
            double per2;
            double.TryParse(textBox6.Text, out per2);
            Color x = Color.FromName((string)comboBox1.SelectedItem);
            graphics.DrawLine(new Pen(x), (int)x0, (int)y0, (int)x1, (int)y1);
            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            textBox3.Text = trackBar1.Value.ToString();
        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {
            textBox4.Text = trackBar2.Value.ToString();
        }

    }
}

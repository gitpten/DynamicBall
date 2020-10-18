using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DynamicBall
{
    public partial class Form1 : Form
    {
        Vector v, a, r;
        Vector v2, a2, r2;
        Vector r0;
        double m, m2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            v = new Vector(500, -300);
            
            r = new Vector((int)pbBall.Left, (int)pbBall.Top);
            m = 1;


            v2 = new Vector();

            r2 = new Vector((int)pbBall2.Left, (int)pbBall2.Top);
            m2 = 1;
            r0 = new Vector((int)pbBall2.Left, (int)pbBall2.Top+100);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double dt = timer1.Interval / 1000.0;

            Vector g = new Vector(0, 980);
            Vector F = m * g;

            a = F / m;
            v += a * dt;
            r += v * dt;

            pbBall.Location = new Point((int)r.X, (int)r.Y);



            Vector F2 = 10 * (r0 - r2);

            a2 = F2 / m2;
            v2 += a2 * dt;
            r2 += v2 * dt;


            pbBall2.Location = new Point((int)r2.X, (int)r2.Y);
            pictureBox4.Height = pbBall2.Top - pictureBox4.Top;
        }
    }
}

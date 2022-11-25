using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace PCSystemInformation.UI.OSD
{
    public partial class OSDForm : Form
    {
        private Point point;
        private PerformanceCounter cpucounter;
        private PerformanceCounter memcounter;
        //private PerformanceCounter gpucounter;

        public OSDForm()
        {
            InitializeComponent();
        }

        private void OSDForm_Load(object sender, EventArgs e)
        {
            cpucounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            memcounter = new PerformanceCounter("Memory", "Available MBytes", true);
            //gpucounter = new PerformanceCounter("GPU", "% GPU Usage", true);
            timer1.Start();
        }

        private void OSDForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void OSDForm_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = String.Format("CPU: {0:#.#} %", cpucounter.NextValue());
            label2.Text = String.Format("Mem: {0} Мб", memcounter.NextValue());
            //label3.Text = String.Format("GPU: {0} Мб", gpucounter.NextValue());
        }
    }
}

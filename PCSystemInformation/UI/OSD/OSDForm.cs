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
using PCSystemInformation.Models;
using System.Diagnostics;

namespace PCSystemInformation.UI.OSD
{
    public partial class OSDForm : Form
    {
        private Point point;
        private CPUUsage cpuUsage;
        private MemoryUsage memoryUsage;
        private GPUUsage gpuUsage;
        private Thread thread;

        public OSDForm()
        {
            InitializeComponent();
        }

        private void OSDForm_Load(object sender, EventArgs e)
        {
            thread = new Thread(ThreadTask);
            thread.Start();
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

        private async void ThreadTask()
        {
            try
            {
                cpuUsage = new CPUUsage();
                memoryUsage = new MemoryUsage();
                gpuUsage = new GPUUsage();
                while (true)
                {
                    double value = Math.Round(await gpuUsage.getValue());
                    label3.Invoke(new Action(() => Tick((int)value)));
                    Thread.Sleep(1000);
                }
            }
            catch(Exception e) { Console.WriteLine(e.Message); }
        }

        private void Tick(int value)
        {
            label1.Text = String.Format("{0} %", (int)Math.Round(cpuUsage.getValue()));
            label2.Text = String.Format("{0} Мб", memoryUsage.getValue());
            label3.Text = String.Format("{0} %", value);

        }

        private void OSDForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread != null) thread.Abort();
        }
    }
}

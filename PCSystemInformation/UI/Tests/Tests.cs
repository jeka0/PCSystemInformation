using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PCSystemInformation.UI
{
    public partial class Tests : Form
    {
        public List<Thread> threads;
        private Form1 form;
        public Tests(Form1 form)
        {
            InitializeComponent();
            this.form = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (threads == null)
            {
                threads = new List<Thread>();
                for (int i = 0; i < 9; i++)
                {
                    Thread tread = new Thread(() => { while (true) { } });
                    threads.Add(tread);
                    tread.Start();
                }
            }
        }

        private void Stop()
        {
            if (threads != null) foreach (Thread thread in threads) thread.Abort();
            threads = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Tests_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.tests = null;
            Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

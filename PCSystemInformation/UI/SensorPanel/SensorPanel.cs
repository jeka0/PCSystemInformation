using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PCSystemInformation.SystemInformation.Helpers;

namespace PCSystemInformation.UI.SensorPanel
{
    public partial class SensorPanel : Form
    {
        private Point point;
        private Thread thread;
        private Form1 form;
        private Dictionary<String, Temp> temps;
        private CpuTemperature temperature;

        public SensorPanel(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            this.temps = new Dictionary<String, Temp>();
            this.temperature = new CpuTemperature();
        }

        private void SensorPanel_Load(object sender, EventArgs e)
        {
            thread = new Thread(ThreadTask);
            thread.Start();
        }

        private void Init()
        {
            int previous = 15;
            Dictionary<String, float?> list = temperature.GetCpuTemp();
            foreach(var item in list)
            {
                Label label = new Label();
                label.Text = item.Key;
                label.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                label.ForeColor = Color.White;
                label.AutoSize = true;
                label.Location = new Point(20, previous);
                Label label2 = new Label();
                label2.Text = String.Format("{0} °C", item.Value);
                label2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                label2.ForeColor = Color.White;
                label2.AutoSize = true;
                label2.Location = new Point(label.Size.Width + 60, previous);
                previous += 30;
                ProgressBar progressBar = new ProgressBar();
                progressBar.Size = new Size(200, 18);
                progressBar.Value = (int)item.Value;
                progressBar.Maximum = 100;
                progressBar.Location = new Point(20, previous);
                previous += 30;
                temps.Add(item.Key, new Temp(label2, progressBar));
                this.Invoke(new Action(()=> {
                    this.Controls.Add(label);
                    this.Controls.Add(label2);
                    this.Controls.Add(progressBar);
                }));
            }
        }

        private void ThreadTask()
        {
            try
            {
                Init();
                while (true)
                {
                    Dictionary<String, float?> list = temperature.GetCpuTemp();
                    this.Invoke(new Action(() => Tick(list)));
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        private void Tick(Dictionary<String, float?> list)
        {
            foreach (var item in list)
            {
                if(temps.TryGetValue(item.Key, out Temp temp))
                {
                    Color color;
                    if (item.Value <= 45) color = Color.White; 
                    else if(item.Value <= 75) color = Color.Yellow; 
                    else color = Color.Red;
                    temp.label.Text = String.Format("{0} °C", item.Value);
                    temp.label.ForeColor = color;
                    temp.progressBar.Value = (int)item.Value;
                }
            }
        }

        private void SensorPanel_MouseDown(object sender, MouseEventArgs e)
        {
            point = new Point(e.X, e.Y);
        }

        private void SensorPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - point.X;
                this.Top += e.Y - point.Y;
            }
        }

        private void SensorPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.sensorPanel = null;
            if (thread != null) thread.Abort();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private struct Temp
        {
            public Label label;
            public ProgressBar progressBar;
            public Temp(Label label, ProgressBar progressBar)
            {
                this.label = label;
                this.progressBar = progressBar;
            }
        } 
    }
}

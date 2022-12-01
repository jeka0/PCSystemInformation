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
using PCSystemInformation.UI;
using PCSystemInformation.UI.OSD;
using PCSystemInformation.UI.ThreadsForm;

namespace PCSystemInformation
{
    public partial class Form1 : Form
    {
        private Thread thread;
        private UIController controller;
        public OSDForm osd;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new UIController(listView);
            treeView.Nodes.Add("Компьютер");
            treeView.Nodes.Add("Операционная система");
            treeView.Nodes.Add("Материнская плата");
            treeView.Nodes.Add("ЦП");
            treeView.Nodes.Add("Дисплей");
            treeView.Nodes.Add("Video");
            treeView.Nodes.Add("Диски");
            treeView.Nodes.Add("Процессы");
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TreeView)sender).SelectedNode = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                ((TreeView)sender).Focus();
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (thread != null) { thread.Abort(); thread = null; }
            listView.Items.Clear();
            String text = treeView.SelectedNode.Text;
            thread = new Thread(() => controller.Navigate(text));
            thread.Start();
        }

        private void OSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (osd == null)
            {
                osd = new OSDForm();
                osd.Show();
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(treeView.SelectedNode.Text== "Процессы")
            {
                foreach(ListViewItem item in listView.SelectedItems)
                {
                    String id = item.SubItems[0].Text;
                    if (id == "") return;
                    var list = controller.processesController.GetThreads(id);
                    if (list == null) return;
                    ThreadsForm threadsForm = new ThreadsForm(list);
                    threadsForm.ShowDialog();
                    break;
                }
            }
        }
    }
}

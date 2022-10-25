using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataSystemInformation;

namespace PCSystemInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListViewItem items;
        private void Form1_Load(object sender, EventArgs e)
        {
            Data data = new Data();
            treeView.Nodes.Add("1");
            treeView.Nodes.Add("2");
            treeView.Nodes.Add("3");
            items = new ListViewItem("adada");
            items.SubItems.Add(data.name);
            listView.Items.Add(items);

        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ((TreeView)sender).SelectedNode = ((TreeView)sender).GetNodeAt(e.X, e.Y);
                ((TreeView)sender).Focus();
            }
        }
    }
}

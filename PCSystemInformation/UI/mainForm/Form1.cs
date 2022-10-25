using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCSystemInformation.Controllers;

namespace PCSystemInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            treeView.Nodes.Add("1");
            treeView.Nodes.Add("2");
            treeView.Nodes.Add("3");
            OperatingSystemController controller = new OperatingSystemController();
            foreach (KeyValuePair<String, String> entry in controller.GetOperatingSystem())
            {
                ListViewItem item = new ListViewItem(entry.Key);
                item.SubItems.Add(entry.Value);
                listView.Items.Add(item);
            }

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

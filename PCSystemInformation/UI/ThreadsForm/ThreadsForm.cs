using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCSystemInformation.Models;

namespace PCSystemInformation.UI.ThreadsForm
{
    public partial class ThreadsForm : Form
    {
        private List<MyThread> threads;
        public ThreadsForm(List<MyThread> threads)
        {
            InitializeComponent();
            this.threads = threads;
        }

        private void ThreadsForm_Load(object sender, EventArgs e)
        {
            foreach (MyThread thread in threads)
            {
                ListViewItem item = new ListViewItem(thread.Id.ToString());
                item.SubItems.Add(thread.Priority.ToString());
                listView.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

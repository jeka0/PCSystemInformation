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
using PCSystemInformation.Controllers;
using PCSystemInformation.Models;

namespace PCSystemInformation
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            treeView.Nodes.Add("Компьютер");
            treeView.Nodes.Add("Операционная система");
            treeView.Nodes.Add("Материнская плата");
            treeView.Nodes.Add("ЦП");
            treeView.Nodes.Add("Дисплей");
            treeView.Nodes.Add("Video");
        }

        private void AddBlock(InformationBlock block)
        {
            listView.Invoke(new Action(() =>
            {
                listView.Items.Add(block.Name);
                foreach (Element element in block.elements)
                {
                    ListViewItem item = new ListViewItem(element.Name);
                    foreach (String part in element.parts) item.SubItems.Add(part);
                    listView.Items.Add(item);
                }
                listView.Items.Add("");
            }));
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
            thread = new Thread(() =>
            {
                switch (text)
                {
                    case "Компьютер":
                        ComputerInformationController computerContoller = new ComputerInformationController();
                        AddBlock(computerContoller.GetGeneralInformation());
                        break;
                    case "Операционная система":
                        OperatingSystemController controller = new OperatingSystemController();
                        AddBlock(controller.GetOperatingSystem());
                        AddBlock(controller.GetUserInformation());
                        break;
                    case "Материнская плата":
                        MotherboardInformationConstoller motherboardController = new MotherboardInformationConstoller();
                        AddBlock(motherboardController.GetMotherboardProperties());
                        AddBlock(motherboardController.GetManufacturerInformation());
                        break;
                    case "ЦП":
                        CPUInformationController cpuInformationController = new CPUInformationController();
                        AddBlock(cpuInformationController.GetCPUProperties());
                        AddBlock(cpuInformationController.GetCharacteristics());
                        AddBlock(cpuInformationController.GetMultiCPU());
                        AddBlock(cpuInformationController.GetSystemInformation());
                        AddBlock(cpuInformationController.GetCurrentInformation());
                        AddBlock(cpuInformationController.GetManufacturerInformation());
                        break;
                    case "Дисплей":
                        DisplayInformationController displayController = new DisplayInformationController();
                        AddBlock(displayController.GetDisplayProperties());
                        break;
                    case "Video":
                        VIdeoInformationController vIdeoInformationController = new VIdeoInformationController();
                        AddBlock(vIdeoInformationController.GetBasicInformation());
                        AddBlock(vIdeoInformationController.GetCharacteristics());
                        AddBlock(vIdeoInformationController.GetCurrentInformation());
                        AddBlock(vIdeoInformationController.GetSystemInformation());
                        break;
                }
            });
            thread.Start();
        }
    }
}

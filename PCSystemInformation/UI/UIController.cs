using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCSystemInformation.Models;
using PCSystemInformation.Controllers;

namespace PCSystemInformation.UI
{
    public class UIController
    {
        private ListView listView;

        public UIController(ListView listView)
        {
            this.listView = listView;
        }

        public void Navigate(String text)
        {
            switch (text)
            {
                case "Компьютер":
                    ComputerPage();
                    break;
                case "Операционная система":
                    OSPage();
                    break;
                case "Материнская плата":
                    MotherboardPage();
                    break;
                case "ЦП":
                    CPUPage();
                    break;
                case "Дисплей":
                    DisplayPage();
                    break;
                case "Video":
                    VideoPage();
                    break;
                case "Диски":
                    DrivePage();
                    break;
            }
        }

        private void ComputerPage()
        {
            ComputerInformationController computerContoller = new ComputerInformationController();
            HardDrivesInformationController hardDrivesInformationController = new HardDrivesInformationController();
            AddBlock(computerContoller.GetGeneralInformation());
            AddBlock(hardDrivesInformationController.DiscNames());
        }

        private void OSPage()
        {
            OperatingSystemController controller = new OperatingSystemController();
            AddBlock(controller.GetOperatingSystem());
            AddBlock(controller.GetUserInformation());
        }

        private void MotherboardPage()
        {
            MotherboardInformationConstoller motherboardController = new MotherboardInformationConstoller();
            AddBlock(motherboardController.GetMotherboardProperties());
            AddBlock(motherboardController.GetSystemInformation());
            AddBlock(motherboardController.BaseBoardDescription());
            AddBlock(motherboardController.MotherboardDescription());
            AddBlock(motherboardController.GetManufacturerInformation());
        }

        private void CPUPage()
        {
            CPUInformationController cpuInformationController = new CPUInformationController();
            AddBlock(cpuInformationController.GetCPUProperties());
            AddBlock(cpuInformationController.GetCharacteristics());
            AddBlock(cpuInformationController.GetMultiCPU());
            AddBlock(cpuInformationController.GetSystemInformation());
            AddBlock(cpuInformationController.GetCurrentInformation());
            AddBlock(cpuInformationController.GetManufacturerInformation());
        }

        private void DisplayPage()
        {
            DisplayInformationController displayController = new DisplayInformationController();
            AddBlock(displayController.GetDisplayProperties());
            AddBlock(displayController.GetSystemInformation());
            AddBlock(displayController.GetManufacturerInformation());
        }

        private void VideoPage()
        {
            VIdeoInformationController vIdeoInformationController = new VIdeoInformationController();
            AddBlock(vIdeoInformationController.GetBasicInformation());
            AddBlock(vIdeoInformationController.GetCharacteristics());
            AddBlock(vIdeoInformationController.GetCurrentInformation());
            AddBlock(vIdeoInformationController.GetSystemInformation());
        }

        private void DrivePage()
        {
            HardDrivesInformationController hardDrivesInformationController = new HardDrivesInformationController();
            AddBlock(hardDrivesInformationController.DiscNames());
            foreach (InformationBlock block in hardDrivesInformationController.GetDrives())
            {
                AddBlock(block);
            }
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
    }
}

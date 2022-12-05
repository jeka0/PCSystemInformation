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
        private ContextMenuStrip ContextMenu;
        public ProcessesController processesController { get; private set; }

        public UIController(ListView listView, ContextMenuStrip ContextMenu)
        {
            this.listView = listView;
            this.ContextMenu = ContextMenu;
        }

        public void Navigate(String text)
        {
            switch (text)
            {
                case "Компьютер":
                    InitPage();
                    ComputerPage();
                    break;
                case "Операционная система":
                    InitPage();
                    OSPage();
                    break;
                case "Материнская плата":
                    InitPage();
                    MotherboardPage();
                    break;
                case "ЦП":
                    InitPage();
                    CPUPage();
                    break;
                case "Дисплей":
                    InitPage();
                    DisplayPage();
                    break;
                case "Video":
                    InitPage();
                    VideoPage();
                    break;
                case "Диски":
                    InitPage();
                    DrivePage();
                    break;
                case "Процессы":
                    InitProcesses();
                    Processes();
                    break;
            }
        }

        private void InitPage()
        {
            listView.Invoke(new Action(() =>
            {
                this.listView.Columns.Clear();
                this.listView.Columns.Add("Поле", 200);
                this.listView.Columns.Add("Значение", 500);
                this.listView.ContextMenuStrip = null;
            }));
        }

        private void InitProcesses()
        {
            listView.Invoke(new Action(() =>
            {
                this.listView.Columns.Clear();
                this.listView.Columns.Add("Id", 50);
                this.listView.Columns.Add("Название процесса", 120);
                this.listView.Columns.Add("Занимаемая память", 120);
                this.listView.Columns.Add("Приоритет", 80);
                this.listView.Columns.Add("Имя пользователя", 120);
                this.listView.Columns.Add("Количество потоков", 120);
                this.listView.ContextMenuStrip = this.ContextMenu;
            }));
        }

        private void Processes()
        {
            processesController = new ProcessesController();
            AddBlock(processesController.GetProcesses());
        }

        private void ComputerPage()
        {
            ComputerInformationController computerContoller = new ComputerInformationController();
            HardDrivesInformationController hardDrivesInformationController = new HardDrivesInformationController();
            AddBlock(computerContoller.GetGeneralInformation());
            AddBlock(computerContoller.GetCPUInfo());
            AddBlock(computerContoller.GetMotherboardInfo());
            AddBlock(computerContoller.GetVideoInfo());
            AddBlock(hardDrivesInformationController.DiscNames());
        }

        private void OSPage()
        {
            OperatingSystemController controller = new OperatingSystemController();
            AddBlock(controller.GetOperatingSystem());
            AddBlock(controller.GetUserInformation());
            AddBlock(controller.GetSystemInfo());
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

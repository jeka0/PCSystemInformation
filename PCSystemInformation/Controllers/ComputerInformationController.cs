using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class ComputerInformationController
    {
        private IComputerInformation computerInformation;
        private IOperatingSystem operatingSystem;
        private ICPUInformation cpuInformation;
        private IMotherboardInformation motherboardInformation;
        private IVIdeoInformation videoInformation;
        public ComputerInformationController()
        {
            this.computerInformation = new ComputerInformation();
            this.operatingSystem = new OperatingInformation();
            this.cpuInformation = new CPUInformation();
            this.motherboardInformation = new MotherboardInformation();
            this.videoInformation = new VIdeoInformation();
        }
        public InformationBlock GetGeneralInformation()
        {
            InformationBlock block = new InformationBlock("Компьютер");
            block.elements.Add(new Element("Операционная система", operatingSystem.FriendlyName()));
            block.elements.Add(new Element("Пакет обновления ОС", operatingSystem.GetServicePack()));
            block.elements.Add(new Element("Internet Explorer", computerInformation.GetIEVetsion()));
            block.elements.Add(new Element("Имя компьютера", computerInformation.GetPCName()));
            block.elements.Add(new Element("Имя польщователя", computerInformation.GetUserName()));
            block.elements.Add(new Element("Вход в домен", computerInformation.GetDomainName()));
            block.elements.Add(new Element("Дата / Время", computerInformation.GetDateAndTime()));
            return block;
        }
        
        public InformationBlock GetCPUInfo()
        {
            InformationBlock block = new InformationBlock("Процессор");
            block.elements.Add(new Element("Название", cpuInformation.GetName()));
            block.elements.Add(new Element("Описание", cpuInformation.GetDescription()));
            block.elements.Add(new Element("Кэш L2", (Convert.ToInt32(cpuInformation.GetL2CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Кэш L3", (Convert.ToInt32(cpuInformation.GetL3CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Максимальная тактовая частота", cpuInformation.GetMaxClockSpeed()));
            block.elements.Add(new Element("Фирма", cpuInformation.GetManufacturer()));
            return block;
        }

        public InformationBlock GetMotherboardInfo()
        {
            InformationBlock block = new InformationBlock("Системная плата");
            block.elements.Add(new Element("Системная плата", motherboardInformation.GetBoardName()));
            block.elements.Add(new Element("Продукт", motherboardInformation.GetBaseBoardProduct()));
            block.elements.Add(new Element("Версия", motherboardInformation.GetBaseBoardVersion()));
            block.elements.Add(new Element("Серийные номера", motherboardInformation.GetBaseBoardSerialNumbers()));
            block.elements.Add(new Element("Фирма", motherboardInformation.GetManufacturer()));
            return block;
        }

        public InformationBlock GetVideoInfo()
        {
            InformationBlock block = new InformationBlock("Видео Windows");
            block.elements.Add(new Element("Название", videoInformation.GetName()));
            block.elements.Add(new Element("Максимальная частота обновления", videoInformation.GetMaxRefreshRate()));
            block.elements.Add(new Element("ОЗУ адаптера", videoInformation.GetAdapterRAM()));
            block.elements.Add(new Element("Описание режима видео", videoInformation.GetVideoModeDescription()));
            block.elements.Add(new Element("ID устройства PNP", videoInformation.GetPNPDeviceID()));
            block.elements.Add(new Element("Совместимость адаптера", videoInformation.GetAdapterCompatibility()));
            return block;
        }
    }
}

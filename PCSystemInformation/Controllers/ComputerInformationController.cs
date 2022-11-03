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
        public ComputerInformationController()
        {
            this.computerInformation = new ComputerInformation();
            this.operatingSystem = new OperatingInformation();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class DisplayInformationController
    {
        private IDisplayInformation displayInformation;
        public DisplayInformationController()
        {
            displayInformation = new DisplayInformation();
        }
        public InformationBlock GetDisplayProperties()
        {
            InformationBlock informationBlock = new InformationBlock("Дисплей");
            informationBlock.elements.Add(new Element("Название", displayInformation.GetName()));
            informationBlock.elements.Add(new Element("Доступность", displayInformation.GetAvailability()));
            informationBlock.elements.Add(new Element("Идентификатор устройства", displayInformation.GetDeviceID()));
            informationBlock.elements.Add(new Element("Описание", displayInformation.GetDescription()));
            informationBlock.elements.Add(new Element("Статус", displayInformation.GetStatus()));
            informationBlock.elements.Add(new Element("Менеджер конфигурации (Конфигурация пользователя)", displayInformation.GetConfigManagerUserConfig()));
            informationBlock.elements.Add(new Element("Пикселей на X логических дюймов", displayInformation.GetPixelsPerXLogicalInch()));
            informationBlock.elements.Add(new Element("Пикселей на Y логических дюймов", displayInformation.GetPixelsPerYLogicalInch()));
            return informationBlock;
        }

        public InformationBlock GetSystemInformation()
        {
            InformationBlock informationBlock = new InformationBlock("Системная информация");
            informationBlock.elements.Add(new Element("Имя системы", displayInformation.GetSystemName()));
            informationBlock.elements.Add(new Element("Подпись", displayInformation.GetCaption()));
            informationBlock.elements.Add(new Element("Имя класса создания системы", displayInformation.GetSystemCreationClassName()));
            informationBlock.elements.Add(new Element("Идентификатор устройства PNP", displayInformation.GetPNPDeviceID()));
            informationBlock.elements.Add(new Element("Тип монитора", displayInformation.GetMonitorType()));
            informationBlock.elements.Add(new Element("Имя класса создания", displayInformation.GetCreationClassName()));
            return informationBlock;
        }

        public InformationBlock GetManufacturerInformation()
        {
            InformationBlock informationBlock = new InformationBlock("Производитель");
            informationBlock.elements.Add(new Element("Производитель мониторов", displayInformation.GetMonitorManufacturer()));
            return informationBlock;
        }
    }
}

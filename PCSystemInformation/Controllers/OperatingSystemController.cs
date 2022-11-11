using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using System.Windows.Forms;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class OperatingSystemController
    {
        private IOperatingSystem operatingSystem;
        public OperatingSystemController()
        {
            this.operatingSystem = new OperatingInformation();
        }
        public InformationBlock GetOperatingSystem()
        {
            InformationBlock block = new InformationBlock("Компьютер");
            block.elements.Add(new Element("Операционная система", operatingSystem.FriendlyName()));
            block.elements.Add(new Element("Язык ОС", operatingSystem.GetCulture()));
            block.elements.Add(new Element("Язык установщика ОС", operatingSystem.GetCulture()));
            block.elements.Add(new Element("Тип ядра ОС", operatingSystem.GetType()));
            block.elements.Add(new Element("Версия ОС", operatingSystem.GetVersion()));
            block.elements.Add(new Element("Пакет обновления ОС", operatingSystem.GetServicePack()));
            block.elements.Add(new Element("Дата установки ОС", operatingSystem.GetDate()));
            block.elements.Add(new Element("Основная папка ОС", operatingSystem.GetBaseDir()));
            return block;
        }
        public InformationBlock GetUserInformation()
        {
            InformationBlock block = new InformationBlock("Лицензионная инфформация");
            block.elements.Add(new Element("Зарегистрированный пользователь", operatingSystem.GetUserName()));
            block.elements.Add(new Element("ID продукта", operatingSystem.GetProductID()));
           // block.elements.Add(new Element("Ключ продукта", operatingSystem.GetProductKey()));
            return block;
        }
    }
}

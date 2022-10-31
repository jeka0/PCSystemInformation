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
            operatingSystem = new OperatingInformation();
        }
        public InformationBlock GetOperatingSystem()
        {
            InformationBlock block = new InformationBlock("Компьютер");
            block.elements.Add(new Element("Операционная система", operatingSystem.FriendlyName()));
            block.elements.Add(new Element("Язык ОС", operatingSystem.GetCulture()));
            block.elements.Add(new Element("Язык установщика ОС", operatingSystem.GetCulture()));
            block.elements.Add(new Element("Тип ядра ОС", operatingSystem.GetType()));
            block.elements.Add(new Element("Версия ОС", operatingSystem.GetVersion()));
            return block;
        }
    }
}

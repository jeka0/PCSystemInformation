using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class MotherboardInformationConstoller
    {
        private IMotherboardInformation motherboardInformation;
        public MotherboardInformationConstoller()
        {
            this.motherboardInformation = new MotherboardInformation();
        }
        public InformationBlock GetMotherboardProperties()
        {
            InformationBlock block = new InformationBlock("Свойства системной платы");
            block.elements.Add(new Element("Системная плата", motherboardInformation.GetBoardName()));
            block.elements.Add(new Element("Серийные номера", motherboardInformation.GetBoardSerialNumbers()));
            return block;
        }
        public InformationBlock GetManufacturerInformation()
        {
            InformationBlock block = new InformationBlock("Производитель системной платы");
            block.elements.Add(new Element("Фирма", motherboardInformation.GetManufacturer()));
            return block;
        }
    }
}

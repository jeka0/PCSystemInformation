using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class CPUInformationController
    {
        private ICPUInformation cpuInformation;
        public CPUInformationController()
        {
            this.cpuInformation = new CPUInformation();
        }
        public InformationBlock GetCPUProperties()
        {
            InformationBlock block = new InformationBlock("Свойства ЦП");
            int countCore = Convert.ToInt32(cpuInformation.GetNumberOfCores());
            block.elements.Add(new Element("Тип ЦП", cpuInformation.GetName()));
            block.elements.Add(new Element("Кэш L2", (Convert.ToInt32(cpuInformation.GetL2CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Кэш L3", (Convert.ToInt32(cpuInformation.GetL3CacheSize()) / 1024.0).ToString() + " Мб"));
            return block;
        }
        public InformationBlock GetMultiCPU()
        {
            InformationBlock block = new InformationBlock("Multi CPU");
            for(int i=1; i <= cpuInformation.GetNumbersOfCores();i++)
            {
                block.elements.Add(new Element("CPU #" + i, cpuInformation.GetCore()));
            }
            return block;
        }
        public InformationBlock GetManufacturerInformation()
        {
            InformationBlock block = new InformationBlock("Производитель ЦП");
            block.elements.Add(new Element("Фирма", cpuInformation.GetManufacturer()));
            return block;
        }
    }
}

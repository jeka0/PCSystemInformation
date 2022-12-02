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
            block.elements.Add(new Element("Тип ЦП", cpuInformation.GetName()));
            block.elements.Add(new Element("Кэш L2", (Convert.ToInt32(cpuInformation.GetL2CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Кэш L3", (Convert.ToInt32(cpuInformation.GetL3CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Описание", cpuInformation.GetDescription()));
            block.elements.Add(new Element("Разрядность адреса", cpuInformation.GetAddressWidth()));
            block.elements.Add(new Element("Разрядность данных", cpuInformation.GetDataWidth()));
            block.elements.Add(new Element("Поддерживается управление питанием", cpuInformation.GetPowerManagementSupported()));
            block.elements.Add(new Element("Роль", cpuInformation.GetRole()));
            block.elements.Add(new Element("Количество ядер", cpuInformation.GetNumberOfCores()));
            block.elements.Add(new Element("Количество логических процессоров", cpuInformation.GetNumberOfLogicalProcessors()));
            block.elements.Add(new Element("Имя системы", cpuInformation.GetSystemName()));
            return block;
        }

        public InformationBlock GetCharacteristics()
        {
            InformationBlock block = new InformationBlock("Характеристики");
            block.elements.Add(new Element("Название", cpuInformation.GetName()));
            block.elements.Add(new Element("Разрядность адреса", cpuInformation.GetAddressWidth()));
            block.elements.Add(new Element("Разрядность данных", cpuInformation.GetDataWidth()));
            block.elements.Add(new Element("Подпись", cpuInformation.GetCaption()));
            block.elements.Add(new Element("Архитектура", cpuInformation.GetArchitecture()));
            block.elements.Add(new Element("Обозначение разъема", cpuInformation.GetSocketDesignation()));
            block.elements.Add(new Element("Доступность", cpuInformation.GetAvailability()));
            block.elements.Add(new Element("Ядро", cpuInformation.GetCore()));
            block.elements.Add(new Element("Кэш L2", (Convert.ToInt32(cpuInformation.GetL2CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Кэш L3", (Convert.ToInt32(cpuInformation.GetL3CacheSize()) / 1024.0).ToString() + " Мб"));
            block.elements.Add(new Element("Максимальная тактовая частота", cpuInformation.GetMaxClockSpeed()));
            return block;
        }

        public InformationBlock GetSystemInformation()
        {
            InformationBlock block = new InformationBlock("Системная информация");
            block.elements.Add(new Element("ID процессора", cpuInformation.GetProcessorid()));
            block.elements.Add(new Element("Тип процессора", cpuInformation.GetProcessorType()));
            block.elements.Add(new Element("Статус процессора", cpuInformation.GetCpuStatus()));
            block.elements.Add(new Element("Имя класса создания", cpuInformation.GetCreationClassName()));
            block.elements.Add(new Element("ID устройства", cpuInformation.GetDeviceID()));
            block.elements.Add(new Element("Внешние часы", cpuInformation.GetExtClock()));
            block.elements.Add(new Element("Family", cpuInformation.GetFamily()));
            block.elements.Add(new Element("Уровень", cpuInformation.GetLevel()));
            block.elements.Add(new Element("Статус", cpuInformation.GetStatus()));
            block.elements.Add(new Element("Информация о статусе", cpuInformation.GetStatusInfo()));
            block.elements.Add(new Element("Способ обновления", cpuInformation.GetUpgradeMethod()));
            return block;
        }

        public InformationBlock GetCurrentInformation()
        {
            InformationBlock block = new InformationBlock("Текущая информация");
            block.elements.Add(new Element("Текущая тактовая частота", cpuInformation.GetCurrentClockSpeed()));
            block.elements.Add(new Element("Текущее напряжение", cpuInformation.GetCurrentVoltage()));
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

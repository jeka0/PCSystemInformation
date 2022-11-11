using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class VIdeoInformationController
    {
        private IVIdeoInformation videoInformation;
        public VIdeoInformationController()
        {
            this.videoInformation = new VIdeoInformation();
        }

        public InformationBlock GetBasicInformation()
        {
            InformationBlock block = new InformationBlock("Видео Windows");
            block.elements.Add(new Element("Название", videoInformation.GetName()));
            block.elements.Add(new Element("ОЗУ адаптера", videoInformation.GetAdapterRAM()));
            block.elements.Add(new Element("Доступность", videoInformation.GetAvailability()));
            block.elements.Add(new Element("Текущая частота обновления", videoInformation.GetCurrentRefreshRate()));
            block.elements.Add(new Element("Подпись", videoInformation.GetCaption()));
            block.elements.Add(new Element("Описание режима видео", videoInformation.GetVideoModeDescription()));
            block.elements.Add(new Element("Имя системы", videoInformation.GetSystemName()));
            block.elements.Add(new Element("Видеопроцессор", videoInformation.GetVideoProcessor()));
            block.elements.Add(new Element("Совместимость адаптера", videoInformation.GetAdapterCompatibility()));
            block.elements.Add(new Element("Видео Архитектура", videoInformation.GetVideoArchitecture()));
            block.elements.Add(new Element("Тип видеопамяти", videoInformation.GetVideoMemoryType()));
            return block;
        }
        public InformationBlock GetCharacteristics()
        {
            InformationBlock block = new InformationBlock("Характеристики");
            block.elements.Add(new Element("Тип ЦАП адаптера", videoInformation.GetAdapterDACType()));
            block.elements.Add(new Element("Доступность", videoInformation.GetAvailability()));
            block.elements.Add(new Element("Описание режима видео", videoInformation.GetVideoModeDescription()));
            block.elements.Add(new Element("Тип дизеринга", videoInformation.GetDitherType()));
            block.elements.Add(new Element("Максимальная частота обновления", videoInformation.GetMaxRefreshRate()));
            block.elements.Add(new Element("Минимальная частота обновления", videoInformation.GetMinRefreshRate()));
            block.elements.Add(new Element("Описание", videoInformation.GetDescription()));
            block.elements.Add(new Element("Monochrome", videoInformation.GetMonochrome()));
            block.elements.Add(new Element("Видеопроцессор", videoInformation.GetVideoProcessor()));
            return block;
        }
        public InformationBlock GetCurrentInformation()
        {
            InformationBlock block = new InformationBlock("Текущая информация");
            block.elements.Add(new Element("Текущие биты на пиксель", videoInformation.GetCurrentBitsPerPixel()));
            block.elements.Add(new Element("Текущее горизонтальное разрешение", videoInformation.GetCurrentHorizontalResolution()));
            block.elements.Add(new Element("Текущее вертикальное разрешение", videoInformation.GetCurrentVerticalResolution()));
            block.elements.Add(new Element("Текущее количество цветов", videoInformation.GetCurrentNumberOfColors()));
            block.elements.Add(new Element("Текущее количество столбцов", videoInformation.GetCurrentNumberOfColumns()));
            block.elements.Add(new Element("Текущее количество строк", videoInformation.GetCurrentNumberOfRows()));
            block.elements.Add(new Element("Текущая частота обновления", videoInformation.GetCurrentRefreshRate()));
            block.elements.Add(new Element("Текущий режим сканирования", videoInformation.GetCurrentScanMode()));
            block.elements.Add(new Element("Статус", videoInformation.GetStatus()));
            return block;
        }
        public InformationBlock GetSystemInformation()
        {
            InformationBlock block = new InformationBlock("Системная информация");
            block.elements.Add(new Element("Название", videoInformation.GetName()));
            block.elements.Add(new Element("Тип ЦАП адаптера", videoInformation.GetAdapterDACType()));
            block.elements.Add(new Element("Имя класса создания", videoInformation.GetCreationClassName()));
            block.elements.Add(new Element("ID устройства", videoInformation.GetDeviceID()));
            block.elements.Add(new Element("Дата драйвера", videoInformation.GetDriverDate()));//?
            block.elements.Add(new Element("Версия драйвера", videoInformation.GetDriverVersion()));
            block.elements.Add(new Element("Код ошибки диспетчера конфигурации", videoInformation.GetConfigManagerErrorCode()));
            block.elements.Add(new Element("Конфигурация пользователя диспетчера конфигураций", videoInformation.GetConfigManagerUserConfig()));
            block.elements.Add(new Element("Имя Inf файла", videoInformation.GetInfFilename()));
            block.elements.Add(new Element("Раздел Inf", videoInformation.GetInfSection()));
            block.elements.Add(new Element("Установленные драйверы дисплея", videoInformation.GetInstalledDisplayDrivers()));
            block.elements.Add(new Element("ID устройства PNP", videoInformation.GetPNPDeviceID()));
            block.elements.Add(new Element("Статус", videoInformation.GetStatus()));
            block.elements.Add(new Element("Имя класса создания системы", videoInformation.GetSystemCreationClassName()));
            block.elements.Add(new Element("Имя системы", videoInformation.GetSystemName()));
            return block;
        }
    }
}

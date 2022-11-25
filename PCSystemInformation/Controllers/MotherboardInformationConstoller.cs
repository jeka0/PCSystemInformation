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
            block.elements.Add(new Element("Серийные номера", motherboardInformation.GetBaseBoardSerialNumbers()));
            block.elements.Add(new Element("Статус", motherboardInformation.GetBaseBoardStatus()));
            block.elements.Add(new Element("Версия", motherboardInformation.GetBaseBoardVersion()));
            block.elements.Add(new Element("Плата включена", motherboardInformation.GetBaseBoardPoweredOn()));
            block.elements.Add(new Element("Продукт", motherboardInformation.GetBaseBoardProduct()));
            block.elements.Add(new Element("Плата съемная", motherboardInformation.GetBaseBoardRemovable()));
            block.elements.Add(new Element("Сменная плата", motherboardInformation.GetBaseBoardReplaceable()));
            block.elements.Add(new Element("Параметры конфигурации платы", motherboardInformation.GetBaseBoardConfigOptions()));
            block.elements.Add(new Element("Заголовок базовой платы", motherboardInformation.GetBaseBoardCaption()));
            block.elements.Add(new Element("Наличие материнской платы", motherboardInformation.GetMotherboardAvailability()));
            return block;
        }

        public InformationBlock GetSystemInformation()
        {
            InformationBlock block = new InformationBlock("Системная информация");
            block.elements.Add(new Element("Серийные номера базовой платы", motherboardInformation.GetBaseBoardSerialNumbers()));
            block.elements.Add(new Element("Название системы материнской платы", motherboardInformation.GetMotherboardSystemName()));
            block.elements.Add(new Element("Имя класса создания базовой платы", motherboardInformation.GetBaseBoardCreationClassName()));
            block.elements.Add(new Element("Имя класса создания материнской платы", motherboardInformation.GetMotherboardCreationClassName()));
            block.elements.Add(new Element("Имя класса создания системы материнской платы", motherboardInformation.GetMotherboardSystemCreationClassName()));
            block.elements.Add(new Element("Тип основной шины материнской платы", motherboardInformation.GetMotherboardPrimaryBusType()));
            block.elements.Add(new Element("Тип вторичной шины материнской платы", motherboardInformation.GetMotherboardSecondaryBusType()));
            block.elements.Add(new Element("Состояние материнской платы", motherboardInformation.GetMotherboardStatus()));
            block.elements.Add(new Element("Плата хостинга", motherboardInformation.GetBaseBoardHostingBoard()));
            block.elements.Add(new Element("Возможность горячей замены", motherboardInformation.GetBaseBoardHotSwappable()));
            return block;
        }

        public InformationBlock BaseBoardDescription()
        {
            InformationBlock block = new InformationBlock("Описание базовой платы");
            block.elements.Add(new Element("Заголовок платы", motherboardInformation.GetBaseBoardCaption()));
            block.elements.Add(new Element("Параметры конфигурации платы", motherboardInformation.GetBaseBoardConfigOptions()));
            block.elements.Add(new Element("Серийные номера платы", motherboardInformation.GetBaseBoardSerialNumbers()));
            block.elements.Add(new Element("Имя класса создания платы", motherboardInformation.GetBaseBoardCreationClassName()));
            block.elements.Add(new Element("Описание платы", motherboardInformation.GetBaseBoardDescription()));
            block.elements.Add(new Element("Плата хостинга", motherboardInformation.GetBaseBoardHostingBoard()));
            block.elements.Add(new Element("Плата с возможностью горячей замены", motherboardInformation.GetBaseBoardHotSwappable()));
            block.elements.Add(new Element("Название платы", motherboardInformation.GetBaseBoardName()));
            block.elements.Add(new Element("Плата включена", motherboardInformation.GetBaseBoardPoweredOn()));
            block.elements.Add(new Element("Продукт платы", motherboardInformation.GetBaseBoardProduct()));
            block.elements.Add(new Element("Плата съемная", motherboardInformation.GetBaseBoardRemovable()));
            block.elements.Add(new Element("Сменная плата", motherboardInformation.GetBaseBoardReplaceable()));
            block.elements.Add(new Element("Для платы требуется дочерняя плата", motherboardInformation.GetBaseBoardRequiresDaughterBoard()));
            block.elements.Add(new Element("Статус платы", motherboardInformation.GetBaseBoardStatus()));
            block.elements.Add(new Element("Тег платы", motherboardInformation.GetBaseBoardTag()));
            block.elements.Add(new Element("Версия платы", motherboardInformation.GetBaseBoardVersion()));
            return block;
        }

        public InformationBlock MotherboardDescription()
        {
            InformationBlock block = new InformationBlock("Описание материнской платы");
            block.elements.Add(new Element("Наличие платы", motherboardInformation.GetMotherboardAvailability()));
            block.elements.Add(new Element("Заголовок платы", motherboardInformation.GetMotherboardCaption()));
            block.elements.Add(new Element("Имя класса создания платы", motherboardInformation.GetMotherboardCreationClassName()));
            block.elements.Add(new Element("Описание платы", motherboardInformation.GetMotherboardDescription()));
            block.elements.Add(new Element("Идентификатор устройства платы", motherboardInformation.GetMotherboardDeviceID()));
            block.elements.Add(new Element("Название платы", motherboardInformation.GetMotherboardName()));
            block.elements.Add(new Element("Тип вторичной шины платы", motherboardInformation.GetMotherboardSecondaryBusType()));
            block.elements.Add(new Element("Тип основной шины платы", motherboardInformation.GetMotherboardPrimaryBusType()));
            block.elements.Add(new Element("Состояние платы", motherboardInformation.GetMotherboardStatus()));
            block.elements.Add(new Element("Имя класса создания системы платы", motherboardInformation.GetMotherboardSystemCreationClassName()));
            block.elements.Add(new Element("Название системы платы", motherboardInformation.GetMotherboardSystemName()));
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

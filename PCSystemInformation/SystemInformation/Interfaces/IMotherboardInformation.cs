using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface IMotherboardInformation
    {
        String GetBaseBoardCaption();
        String GetBaseBoardConfigOptions();
        String GetBaseBoardSerialNumbers();
        String GetBaseBoardCreationClassName();
        String GetBaseBoardDescription();
        String GetBaseBoardHostingBoard();
        String GetBaseBoardHotSwappable();
        String GetBaseBoardName();
        String GetBaseBoardPoweredOn();
        String GetBaseBoardProduct();
        String GetBaseBoardRemovable();
        String GetBaseBoardReplaceable();
        String GetBaseBoardRequiresDaughterBoard();
        String GetBaseBoardStatus();
        String GetBaseBoardTag();
        String GetBaseBoardVersion();
        String GetMotherboardAvailability();
        String GetMotherboardCaption();
        String GetMotherboardCreationClassName();
        String GetMotherboardDescription();
        String GetMotherboardDeviceID();
        String GetMotherboardName();
        String GetMotherboardSecondaryBusType();
        String GetMotherboardPrimaryBusType();
        String GetMotherboardStatus();
        String GetMotherboardSystemCreationClassName();
        String GetMotherboardSystemName();
        String GetBoardName();
        String GetManufacturer();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface ICPUInformation
    {
        String GetName();
        String GetAddressWidth();
        String GetArchitecture();
        String GetAvailability();
        String GetCaption();
        String GetCpuStatus();
        String GetCreationClassName();
        String GetCurrentClockSpeed();
        String GetCurrentVoltage();
        String GetDataWidth();
        String GetDescription();
        String GetDeviceID();
        String GetExtClock();
        String GetFamily();
        String GetL2CacheSize();
        String GetL3CacheSize();
        String GetLevel();
        String GetLoadPercentage();
        String GetNumberOfCores();
        String GetNumberOfLogicalProcessors();
        String GetPowerManagementSupported();
        String GetProcessorid();
        String GetProcessorType();
        String GetRole();
        String GetSocketDesignation();
        String GetStatus();
        String GetStatusInfo();
        String GetSystemName();
        String GetUpgradeMethod();
        String GetManufacturer();
        String GetCore();
        String GetMaxClockSpeed();
        int GetNumbersOfCores();
    }
}

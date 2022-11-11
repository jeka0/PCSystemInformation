using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface IDisplayInformation
    {
        String GetName();
        String GetAvailability();
        String GetPNPDeviceID();
        String GetMonitorManufacturer();
        String GetStatus();
        String GetPixelsPerXLogicalInch();
        String GetPixelsPerYLogicalInch();
    }
}

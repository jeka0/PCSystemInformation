using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface IOperatingSystem
    {
        String GetVersion();
        String GetCulture();
        String GetInstalledCulture();
        String FriendlyName();
        String GetType();
        String GetDate();
        String GetBaseDir();
        String GetUserName();
        String GetProductID();
        String GetPlatform();
        String GetVersionString();
        String GetServicePack();
    }
}

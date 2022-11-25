using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PCSystemInformation.SystemInformation
{
    public class DisplayInformation: IDisplayInformation
    {
        private RegistryAccess registry;
        private ManagementObjectSearcher searcher;
        private const String ROOT = "root\\CIMV2";
        private const String DEVICE = "SELECT * FROM Win32_DesktopMonitor";
        public DisplayInformation()
        {
            registry = new RegistryAccess();
            searcher = new ManagementObjectSearcher(ROOT, DEVICE);
        }
        public String GetName()
        {
            return GetInformation("Name", searcher);
        }
        public String GetAvailability()
        {
            return GetInformation("Availability", searcher);
        }
        public String GetPNPDeviceID()
        {
            return GetInformation("PNPDeviceID", searcher);
        }
        public String GetMonitorManufacturer()
        {
            return GetInformation("MonitorManufacturer", searcher);
        }
        public String GetStatus()
        {
            return GetInformation("Status", searcher);
        }
        public String GetPixelsPerXLogicalInch()
        {
            return GetInformation("PixelsPerXLogicalInch", searcher);
        }
        public String GetPixelsPerYLogicalInch()
        {
            return GetInformation("PixelsPerYLogicalInch", searcher);
        }

        public String GetCaption()
        {
            return GetInformation("Caption", searcher);
        }
        public String GetConfigManagerUserConfig()
        {
            return GetInformation("ConfigManagerUserConfig", searcher);
        }
        public String GetCreationClassName()
        {
            return GetInformation("CreationClassName", searcher);
        }
        public String GetDescription()
        {
            return GetInformation("Description", searcher);
        }
        public String GetDeviceID()
        {
            return GetInformation("DeviceID", searcher);
        }
        public String GetMonitorType()
        {
            return GetInformation("MonitorType", searcher);
        }
        public String GetSystemCreationClassName()
        {
            return GetInformation("SystemCreationClassName", searcher);
        }
        public String GetSystemName()
        {
            return GetInformation("SystemName", searcher);
        }

        private String GetInformation(String str, ManagementObjectSearcher searcher)
        {
            try
            {
                foreach (ManagementObject querObj in searcher.Get())
                {
                    var value = querObj[str];
                    if (value == null || value.ToString() == "" || value.ToString() == "Монитор по умолчанию") continue;
                    return value.ToString();
                }
                return "";
            }
            catch { return ""; }
        }

    }
}

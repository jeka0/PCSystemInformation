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
        private ManagementObjectSearcher videosearcher;
        private const String ROOT = "root\\CIMV2";
        private const String DEVICE = "SELECT * FROM Win32_DesktopMonitor";
        private const String VIDEO_CONTROLLER = "SELECT * FROM Win32_VideoController";
        public DisplayInformation()
        {
            registry = new RegistryAccess();
            searcher = new ManagementObjectSearcher(ROOT, DEVICE);
            videosearcher = new ManagementObjectSearcher(ROOT, VIDEO_CONTROLLER);
        }
        public String GetName()
        {
            return GetInformation("Name", searcher);
        }
        public String GetAvailability()
        {
            return GetInformation("Availability", videosearcher);
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

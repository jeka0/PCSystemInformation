using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PCSystemInformation.SystemInformation
{
    public class VIdeoInformation : IVIdeoInformation
    {
        private RegistryAccess registry;
        private ManagementObjectSearcher searcher;
        private ManagementObject querObj;
        private const String ROOT = "root\\CIMV2";
        private const String VIDEO_CONTROLLER = "SELECT * FROM Win32_VideoController";
        public VIdeoInformation()
        {
            registry = new RegistryAccess();
            this.searcher = new ManagementObjectSearcher(ROOT, VIDEO_CONTROLLER);
            foreach (ManagementObject querObj in searcher.Get()) { this.querObj = querObj; break; }
        }

        public String GetAdapterCompatibility() { return GetStringInformation("AdapterCompatibility", searcher); }

        public String GetAdapterDACType() { return GetStringInformation("AdapterDACType", searcher); }

        public String GetAdapterRAM() { 
            double value = Convert.ToDouble(GetInformation("AdapterRAM", searcher));
            value /= 1024 * 1024;
            return value.ToString() + " Мб";
        }

        public String GetAvailability() { return GetStringInformation("Availability", searcher); }

        public String GetCaption() { return GetStringInformation("Caption", searcher); }

        public String GetName() { return GetStringInformation("Name", searcher); }

        public String GetConfigManagerErrorCode() { return GetStringInformation("ConfigManagerErrorCode", searcher); }

        public String GetConfigManagerUserConfig() { return GetStringInformation("ConfigManagerUserConfig", searcher); }

        public String GetCreationClassName() { return GetStringInformation("CreationClassName", searcher); }

        public String GetCurrentBitsPerPixel() { return GetStringInformation("CurrentBitsPerPixel", searcher); }

        public String GetCurrentHorizontalResolution() { return GetStringInformation("CurrentHorizontalResolution", searcher); }

        public String GetCurrentNumberOfColors() { return GetStringInformation("CurrentNumberOfColors", searcher); }

        public String GetCurrentNumberOfColumns() { return GetStringInformation("CurrentNumberOfColumns", searcher); }

        public String GetCurrentNumberOfRows() { return GetStringInformation("CurrentNumberOfRows", searcher); }

        public String GetCurrentRefreshRate() { return GetStringInformation("CurrentRefreshRate", searcher); }

        public String GetCurrentScanMode() { return GetStringInformation("CurrentScanMode", searcher); }

        public String GetCurrentVerticalResolution() { return GetStringInformation("CurrentVerticalResolution", searcher); }

        public String GetDescription() { return GetStringInformation("Description", searcher); }

        public String GetDeviceID() { return GetStringInformation("DeviceID", searcher); }

        public String GetDitherType() { return GetStringInformation("DitherType", searcher); }

        public String GetDriverDate() {
            String[] strs = GetStringInformation("DriverDate", searcher).Split('.');
            DateTime date = DateTime.FromFileTimeUtc(Convert.ToInt64(strs[0]));
            return date.ToString(); 
        }

        public String GetDriverVersion() { return GetStringInformation("DriverVersion", searcher); }

        public String GetInfFilename() { return GetStringInformation("InfFilename", searcher); }

        public String GetInfSection() { return GetStringInformation("InfSection", searcher); }

        public String GetInstalledDisplayDrivers() { return GetStringInformation("InstalledDisplayDrivers", searcher); }

        public String GetMaxRefreshRate() { return GetStringInformation("MaxRefreshRate", searcher); }

        public String GetMinRefreshRate() { return GetStringInformation("MinRefreshRate", searcher); }

        public String GetMonochrome() { return GetStringInformation("Monochrome", searcher); }

        public String GetPNPDeviceID() { return GetStringInformation("PNPDeviceID", searcher); }

        public String GetStatus() { return GetStringInformation("Status", searcher); }

        public String GetSystemCreationClassName() { return GetStringInformation("SystemCreationClassName", searcher); }

        public String GetSystemName() { return GetStringInformation("SystemName", searcher); }

        public String GetVideoArchitecture() { return GetStringInformation("VideoArchitecture", searcher); }

        public String GetVideoMemoryType() { return GetStringInformation("VideoMemoryType", searcher); }

        public String GetVideoModeDescription() { return GetStringInformation("VideoModeDescription", searcher); }

        public String GetVideoProcessor() { return GetStringInformation("VideoProcessor", searcher); }

        private object GetInformation(String str, ManagementObjectSearcher searcher)
        {
            return querObj[str];
        }
        private String GetStringInformation(String str, ManagementObjectSearcher searcher)
        {
            try
            {
                return GetInformation(str, searcher).ToString();
            }
            catch { return "-"; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PCSystemInformation.SystemInformation
{
    public class MotherboardInformation: IMotherboardInformation
    {
        private RegistryAccess registry;
        private const String QUERY = "SELECT * FROM Win32_BaseBoard";
        private const String ROOT = "root\\CIMV2";
        private const String Device = "SELECT * FROM Win32_MotherboardDevice";
        private ManagementObjectSearcher baseboardSearcher;
        private ManagementObjectSearcher motherboardSearcher;
        public MotherboardInformation()
        {
            registry = new RegistryAccess();
            baseboardSearcher = new ManagementObjectSearcher(ROOT, QUERY);
            motherboardSearcher = new ManagementObjectSearcher(ROOT, Device);
        }
        public String GetBoardSerialNumbers()
        {
            return GetMotherboardInformation("SerialNumber", baseboardSearcher);
        }
        public String GetBoardName()
        {
            return GetMotherboardInformation("Manufacturer", baseboardSearcher) + " " + GetMotherboardInformation("Product", baseboardSearcher);
        }
        public String GetManufacturer()
        {
            return GetMotherboardInformation("Manufacturer", baseboardSearcher);
        }
        private String GetMotherboardInformation(String str, ManagementObjectSearcher searcher)
        {
            try
            {
                foreach (ManagementObject querObj in searcher.Get())
                {
                    return querObj[str].ToString();
                }
                return "";
            }
            catch { return ""; }
        }
    }
}

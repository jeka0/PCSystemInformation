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
        private ManagementObject motherboardObj;
        private ManagementObject baseboardObj;
        public MotherboardInformation()
        {
            registry = new RegistryAccess();
            baseboardSearcher = new ManagementObjectSearcher(ROOT, QUERY);
            motherboardSearcher = new ManagementObjectSearcher(ROOT, Device);
            foreach (ManagementObject querObj in motherboardSearcher.Get()) { motherboardObj = querObj; break; }
            foreach (ManagementObject querObj in baseboardSearcher.Get()) { baseboardObj = querObj; break; }
        }

        public String GetBaseBoardCaption()
        {
            return GetString("Caption", baseboardObj);
        }

        public String GetBaseBoardConfigOptions()
        {
            String[] strs = (String[])GetObject("ConfigOptions", baseboardObj);
            if (strs != null && strs.Length != 0) return strs[0].ToString();
            return "-";
        }

        public String GetBaseBoardSerialNumbers()
        {
            return GetString("SerialNumber", baseboardObj);
        }

        public String GetBaseBoardCreationClassName()
        {
            return GetString("CreationClassName", baseboardObj);
        }

        public String GetBaseBoardDescription()
        {
            return GetString("Description", baseboardObj);
        }

        public String GetBaseBoardHostingBoard()
        {
            return GetString("HostingBoard", baseboardObj);
        }

        public String GetBaseBoardHotSwappable()
        {
            return GetString("HotSwappable", baseboardObj);
        }

        public String GetBaseBoardName()
        {
            return GetString("Name", baseboardObj);
        }

        public String GetBaseBoardPoweredOn()
        {
            return GetString("PoweredOn", baseboardObj);
        }

        public String GetBaseBoardProduct()
        {
            return GetString("Product", baseboardObj);
        }

        public String GetBaseBoardRemovable()
        {
            return GetString("Removable", baseboardObj);
        }

        public String GetBaseBoardReplaceable()
        {
            return GetString("Replaceable", baseboardObj);
        }

        public String GetBaseBoardRequiresDaughterBoard()
        {
            return GetString("RequiresDaughterBoard", baseboardObj);
        }

        public String GetBaseBoardStatus()
        {
            return GetString("Status", baseboardObj);
        }

        public String GetBaseBoardTag()
        {
            return GetString("Tag", baseboardObj);
        }

        public String GetBaseBoardVersion()
        {
            return GetString("Version", baseboardObj);
        }

        public String GetMotherboardAvailability()
        {
            return GetString("Availability", motherboardObj);
        }

        public String GetMotherboardCaption()
        {
            return GetString("Caption", motherboardObj);
        }

        public String GetMotherboardCreationClassName()
        {
            return GetString("CreationClassName", motherboardObj);
        }

        public String GetMotherboardDescription()
        {
            return GetString("Description", motherboardObj);
        }

        public String GetMotherboardDeviceID()
        {
            return GetString("DeviceID", motherboardObj);
        }

        public String GetMotherboardName()
        {
            return GetString("Name", motherboardObj);
        }

        public String GetMotherboardSecondaryBusType()
        {
            return GetString("SecondaryBusType", motherboardObj);
        }

        public String GetMotherboardPrimaryBusType()
        {
            return GetString("PrimaryBusType", motherboardObj);
        }

        public String GetMotherboardStatus()
        {
            return GetString("Status", motherboardObj);
        }

        public String GetMotherboardSystemCreationClassName()
        {
            return GetString("SystemCreationClassName", motherboardObj);
        }

        public String GetMotherboardSystemName()
        {
            return GetString("SystemName", motherboardObj);
        }


        public String GetBoardName()
        {
            return GetString("Manufacturer", baseboardObj) + " " + GetString("Product", baseboardObj);
        }

        public String GetManufacturer()
        {
            return GetString("Manufacturer", baseboardObj);
        }

        private String GetString(String str, ManagementObject querObj)
        {
            try
            {
               return GetObject(str, querObj).ToString();
            }
            catch { return ""; }
        }

        private object GetObject(String str, ManagementObject querObj)
        {
            try
            {
                return querObj[str];
            }
            catch { return null; }
        }
    }
}

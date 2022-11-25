using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Globalization;
using PCSystemInformation.Models;

namespace PCSystemInformation.SystemInformation
{
    public class OperatingInformation : IOperatingSystem
    {
        private const String CURRENT_VERSION = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private RegistryAccess registry;
        public OperatingInformation()
        {
            this.registry = new RegistryAccess();
        }
        public String GetVersion()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(registry.HKLM_GetString(CURRENT_VERSION, "CurrentMajorVersionNumber") + '.');
            stringBuilder.Append(registry.HKLM_GetString(CURRENT_VERSION, "CurrentMinorVersionNumber") + '.');
            stringBuilder.Append(registry.HKLM_GetString(CURRENT_VERSION, "CurrentBuildNumber") + '.');
            stringBuilder.Append(registry.HKLM_GetString(CURRENT_VERSION, "UBR"));
            return stringBuilder.ToString();
        }
        public String GetDate()
        {
           DateTime date = DateTime.FromFileTimeUtc(Convert.ToInt64(registry.HKLM_GetValue(CURRENT_VERSION, "InstallTime")));
            return date.Date.ToString().Split()[0];
        }
        public String GetBaseDir()
        {
            return registry.HKLM_GetString(CURRENT_VERSION, "PathName");
        }
        public String GetCulture()
        {
            return CultureInfo.CurrentUICulture.Name;
        }
        public String GetInstalledCulture()
        {
            return CultureInfo.InstalledUICulture.Name;
        }
        public String GetType()
        {
            return registry.HKLM_GetString(CURRENT_VERSION, "CurrentType");
        }
        

        public String FriendlyName()
        {
            string ProductName = registry.HKLM_GetString(CURRENT_VERSION, "ProductName");
            string CSDVersion = registry.HKLM_GetString(CURRENT_VERSION, "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }
        public String GetUserName()
        {
            return Environment.UserName;
        }
        public String GetProductID()
        {
            return registry.HKLM_GetString(CURRENT_VERSION, "ProductId");
        }

        public String GetPlatform()
        {
            return Environment.OSVersion.Platform.ToString();
        }

        public String GetVersionString()
        {
            return Environment.OSVersion.VersionString;
        }

        public String GetServicePack()
        {
            String value = Environment.OSVersion.ServicePack;
            if (value == null || value == "") return "-";
            return value;
        }

    }
}

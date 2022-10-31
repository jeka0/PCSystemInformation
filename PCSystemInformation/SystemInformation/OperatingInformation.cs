using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Globalization;
using Microsoft.Win32;

namespace PCSystemInformation.SystemInformation
{
    public class OperatingInformation : IOperatingSystem
    {

        public OperatingInformation()
        {

        }
        public String GetVersion()
        {
            return HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentMajorVersionNumber");
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
            return HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentType");
        }
        private String HKLM_GetString(String path, String key)
        {
            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(path);
                if (rk == null) return "";
                return (string)rk.GetValue(key);
            }
            catch { return ""; }
        }

        public String FriendlyName()
        {
            string ProductName = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName");
            string CSDVersion = HKLM_GetString(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion");
            if (ProductName != "")
            {
                return (ProductName.StartsWith("Microsoft") ? "" : "Microsoft ") + ProductName +
                            (CSDVersion != "" ? " " + CSDVersion : "");
            }
            return "";
        }
    }
}

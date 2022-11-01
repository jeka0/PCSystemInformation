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
        private const String CURRENT_VERSION = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion";
        private RegistryKey LocalMachine;
        public OperatingInformation()
        {
            RegistryView view;
            if (Environment.Is64BitOperatingSystem) view = RegistryView.Registry64;             
            else view = RegistryView.Registry32;
            this.LocalMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view);
        }
        public String GetVersion()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(HKLM_GetString(CURRENT_VERSION, "CurrentMajorVersionNumber") + '.');
            stringBuilder.Append(HKLM_GetString(CURRENT_VERSION, "CurrentMinorVersionNumber") + '.');
            stringBuilder.Append(HKLM_GetString(CURRENT_VERSION, "CurrentBuildNumber") + '.');
            stringBuilder.Append(HKLM_GetString(CURRENT_VERSION, "UBR"));
            return stringBuilder.ToString();
        }
        public String GetDate()
        {
           DateTime date = DateTime.FromFileTimeUtc(Convert.ToInt64(HKLM_GetValue(CURRENT_VERSION, "InstallTime")));
            return date.Date.ToString();
        }
        public String GetBaseDir()
        {
            return HKLM_GetString(CURRENT_VERSION, "PathName");
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
            return HKLM_GetString(CURRENT_VERSION, "CurrentType");
        }
        private object HKLM_GetValue(String path, String key)
        {
            try
            {
                RegistryKey rk = LocalMachine.OpenSubKey(path);
                if (rk == null) return null;
                return rk.GetValue(key);
            }
            catch (Exception e) { return null; }
        }
        private String HKLM_GetString(String path, String key)
        {
            object value = HKLM_GetValue(path, key);
            if (value == null) return "";
            return value.ToString();
        }

        public String FriendlyName()
        {
            string ProductName = HKLM_GetString(CURRENT_VERSION, "ProductName");
            string CSDVersion = HKLM_GetString(CURRENT_VERSION, "CSDVersion");
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
            return HKLM_GetString(CURRENT_VERSION, "ProductId");
        }
    }
}

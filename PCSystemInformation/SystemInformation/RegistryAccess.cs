using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace PCSystemInformation.SystemInformation
{
    public class RegistryAccess
    {
        private RegistryKey LocalMachine;
        public RegistryAccess()
        {
            RegistryView view;
            if (Environment.Is64BitOperatingSystem) view = RegistryView.Registry64; else view = RegistryView.Registry32;
            this.LocalMachine = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, view);
        }
        public object HKLM_GetValue(String path, String key)
        {
            try
            {
                RegistryKey rk = LocalMachine.OpenSubKey(path);
                if (rk == null) return null;
                return rk.GetValue(key);
            }
            catch { return null; }
        }
        public String HKLM_GetString(String path, String key)
        {
            object value = HKLM_GetValue(path, key);
            if (value == null) return "";
            return value.ToString();
        }
    }
}

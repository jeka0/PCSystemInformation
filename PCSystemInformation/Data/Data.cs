using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace DataSystemInformation
{
    public class Data
    {
        public String name;
        public Data()
        {
             name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault().ToString();
            //return name != null ? name.ToString() : "Unknown";
        }
    }
}

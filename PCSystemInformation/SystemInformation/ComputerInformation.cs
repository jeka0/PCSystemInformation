using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PCSystemInformation.SystemInformation
{
    public class ComputerInformation : IComputerInformation
    {
        private const String INTERNET_EXPLORER = @"Software\Microsoft\Internet Explorer";
        private RegistryAccess registry;
        public ComputerInformation()
        {
            registry = new RegistryAccess();
        }
        public String GetIEVetsion()
        {
            return registry.HKLM_GetString(INTERNET_EXPLORER, "svcVersion");
        }
        public String GetPCName()
        {
            return Environment.MachineName;
        }
        public String GetUserName()
        {
            return Environment.UserName;
        }
        public String GetDomainName()
        {
            return Environment.UserDomainName;
        }
        public String GetDateAndTime()
        {
            return DateTime.Now.ToString().Replace(" "," / ");
        }
    }
}

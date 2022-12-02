using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace PCSystemInformation.SystemInformation
{
    public class CPUInformation:ICPUInformation
    {
        private const String ROOT = "root\\CIMV2";
        private const String Device = "SELECT * FROM Win32_Processor";
        private RegistryAccess registry;
        private static ManagementObject querObj;
        private ManagementObjectSearcher cpu;
        private String core;
        private String name;
        public CPUInformation()
        {
            this.registry = new RegistryAccess();
            this.cpu = new ManagementObjectSearcher(ROOT, Device);
            if(CPUInformation.querObj == null) foreach (ManagementObject querObj in cpu.Get()) { CPUInformation.querObj = querObj; break; }
        }
        public String GetName()
        {
            if(name==null)name = GetCPUInformation("Name", cpu);
            return name;
        }
        public String GetAddressWidth()
        {
            return GetCPUInformation("AddressWidth", cpu);
        }
        public String GetArchitecture()
        {
            return GetCPUInformation("Architecture", cpu);
        }
        public String GetAvailability()
        {
            return GetCPUInformation("Availability", cpu);
        }
        public String GetCaption()
        {
            return GetCPUInformation("Caption", cpu);
        }
        public String GetCpuStatus()
        {
            return GetCPUInformation("CpuStatus", cpu);
        }
        public String GetCreationClassName()
        {
            return GetCPUInformation("CreationClassName", cpu);
        }
        public String GetCurrentClockSpeed()
        {
            return GetCPUInformation("CurrentClockSpeed", cpu) + " МГц";
        }
        public String GetCurrentVoltage()
        {
            return GetCPUInformation("CurrentVoltage", cpu);
        }
        public String GetDataWidth()
        {
            return GetCPUInformation("DataWidth", cpu);
        }
        public String GetDescription()
        {
            return GetCPUInformation("Description", cpu);
        }
        public String GetDeviceID()
        {
            return GetCPUInformation("DeviceID", cpu);
        }
        public String GetExtClock()
        {
            return GetCPUInformation("ExtClock", cpu);
        }
        public String GetFamily()
        {
            return GetCPUInformation("Family", cpu);
        }
        public String GetL2CacheSize()
        {
            return GetCPUInformation("L2CacheSize", cpu);
        }
        public String GetL3CacheSize()
        {
            return GetCPUInformation("L3CacheSize", cpu);
        }
        public String GetLevel()
        {
            return GetCPUInformation("Level", cpu);
        }
        public String GetLoadPercentage()
        {
            return GetCPUInformation("LoadPercentage", cpu);
        }
        public String GetNumberOfCores()
        {
            return GetCPUInformation("NumberOfCores", cpu);
        }
        public String GetNumberOfLogicalProcessors()
        {
            return GetCPUInformation("NumberOfLogicalProcessors", cpu);
        }
        public String GetPowerManagementSupported()
        {
            return GetCPUInformation("PowerManagementSupported", cpu);
        }
        public String GetProcessorid()
        {
            return GetCPUInformation("Processorid", cpu);
        }
        public String GetProcessorType()
        {
            return GetCPUInformation("ProcessorType", cpu);
        }
        public String GetRole()
        {
            return GetCPUInformation("Role", cpu);
        }
        public String GetSocketDesignation()
        {
            return GetCPUInformation("SocketDesignation", cpu);
        }
        public String GetStatus()
        {
            return GetCPUInformation("Status", cpu);
        }
        public String GetStatusInfo()
        {
            return GetCPUInformation("StatusInfo", cpu);
        }
        public String GetSystemName()
        {
            return GetCPUInformation("SystemName", cpu);
        }
        public String GetUpgradeMethod()
        {
            return GetCPUInformation("UpgradeMethod", cpu);
        }
        public String GetManufacturer()
        {
            return GetCPUInformation("Manufacturer", cpu);
        }
        public String GetCore()
        {
            if (name == null) name = GetCPUInformation("Name", cpu);
            if (core==null)core = name + ", " + GetMaxClockSpeed();
            return core;
        }
        public String GetMaxClockSpeed()
        {
            return GetCPUInformation("MaxClockSpeed", cpu) + " МГц";
        }
        public int GetNumbersOfCores()
        {
            return Convert.ToInt32(GetCPUInformation("NumberOfCores", cpu));
        }
        private String GetCPUInformation(String str, ManagementObjectSearcher searcher)
        {
            try
            {
               return querObj[str].ToString();
            }
            catch { return ""; }
        }
    }
}

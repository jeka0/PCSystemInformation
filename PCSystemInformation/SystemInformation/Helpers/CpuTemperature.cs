using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using PCSystemInformation.Models;

namespace PCSystemInformation.SystemInformation.Helpers
{
    public class CpuTemperature
    {
        public Dictionary<String, float?> GetCpuTemp()
        {
            Dictionary<String, float?> list = new Dictionary<String, float?>();
            UpdateVisitor updateVisitor = new UpdateVisitor();
            Computer computer = new Computer();
            computer.Open();
            computer.CPUEnabled = true;
            computer.Accept(updateVisitor);
            for (int i = 0; i < computer.Hardware.Length; i++)
            {
                if (computer.Hardware[i].HardwareType == HardwareType.CPU)
                {
                    for (int j = 0; j < computer.Hardware[i].Sensors.Length; j++)
                    {
                        if (computer.Hardware[i].Sensors[j].SensorType == SensorType.Temperature)
                        {
                            list.Add(computer.Hardware[i].Sensors[j].Name, computer.Hardware[i].Sensors[j].Value);
                        }
                    }
                }
            }
            computer.Close();
            return list;
        }
    }
}

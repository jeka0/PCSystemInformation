using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PCSystemInformation.Models
{
    public class CPUUsage
    {
        private PerformanceCounter cpucounter;
        public CPUUsage()
        {
            cpucounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        }

        public float getValue()
        {
            return cpucounter.NextValue();
        }

    }
}

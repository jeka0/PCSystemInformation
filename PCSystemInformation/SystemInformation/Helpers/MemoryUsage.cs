using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PCSystemInformation.Models
{
    public class MemoryUsage
    {
        private PerformanceCounter memcounter;
        public MemoryUsage()
        {
            memcounter = new PerformanceCounter("Memory", "Available MBytes", true);
        }

        public float getValue()
        {
            return memcounter.NextValue();
        }

    }
}

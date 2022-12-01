using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.Models
{
    public class MyProcess
    {
        public int Id { get; set; }
        public String ProcessName { get; set; }
        public String Memory { get; set; }
        public int Priority { get; set; }
        public String Owner { get; set; }
        public int threadsCount { get; set; }
        public MyProcess(int Id, String ProcessName, String Memory, int Priority, String Owner, int threadsCount)
        {
            this.Id = Id;
            this.ProcessName = ProcessName;
            this.Memory = Memory;
            this.Priority = Priority;
            this.Owner = Owner;
            this.threadsCount = threadsCount;
        }
    }
}

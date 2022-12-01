using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.Models
{
    public class MyThread
    {
        public int Id { get; }
        public int Priority { get; }
        public MyThread(int Id, int Priority)
        {
            this.Id = Id;
            this.Priority = Priority;
        }
    }
}

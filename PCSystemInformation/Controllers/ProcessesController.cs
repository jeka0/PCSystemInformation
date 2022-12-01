using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class ProcessesController
    {
        private Processes processes;

        public ProcessesController()
        {
            processes = new Processes();
        }

        public InformationBlock GetProcesses()
        {
            processes.UpdateProcessesInfo();
            List<MyProcess> processesList = processes.MyProcesses;
            InformationBlock block = new InformationBlock("Процессы");
            foreach(MyProcess process in processesList)
            {
                block.elements.Add(new Element(process.Id.ToString(), process.ProcessName, process.Memory, process.Priority.ToString(), process.Owner, process.threadsCount.ToString()));
            }
            return block;
        }

        public List<MyThread> GetThreads(String id)
        {
            Dictionary<String, ProcessThreadCollection> thredss = processes.ThreadsInfo;
            if (thredss.TryGetValue(id, out ProcessThreadCollection process))
            {
                List<MyThread> threads = new List<MyThread>();
                foreach(ProcessThread thread in process)
                {
                    threads.Add(new MyThread(thread.Id, thread.CurrentPriority));
                }
                return threads;
            }
            else return null;
        }
    }

}

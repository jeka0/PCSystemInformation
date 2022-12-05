using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using PCSystemInformation.Models;

namespace PCSystemInformation.SystemInformation {
    public class Processes
    {
        public Dictionary<String, ProcessThreadCollection> ThreadsInfo { get; }
        public List<MyProcess> MyProcesses { get; }

        public Processes()
        {
            this.ThreadsInfo = new Dictionary<String, ProcessThreadCollection>();
            this.MyProcesses = new List<MyProcess>();
        }

        public void UpdateProcessesInfo()
        {
            MyProcesses.Clear();
            ThreadsInfo.Clear();
            using (Process process = new Process())
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process1 in processes)
                {
                    ProcessThreadCollection threads = process1.Threads;
                    MyProcesses.Add(new MyProcess(process1.Id, process1.ProcessName, process1.PrivateMemorySize64 / (1024 * 1024) + " МБ", process1.BasePriority, GetProcessOwnerByID(process1), threads.Count, process1));
                    ThreadsInfo.Add(process1.Id.ToString(), threads);
                }
            }
        }

        public static string GetProcessOwnerByID(Process process)
        {
            IntPtr tokenHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, TOKEN_QUERY, out tokenHandle);
                using (WindowsIdentity wi = new WindowsIdentity(tokenHandle))
                {
                    string user = wi.Name;
                    return user.Contains(@"\") ? user.Substring(user.IndexOf(@"\") + 1) : user;
                }
            }
            catch
            {
                return "NO ACCESS";
            }
            finally
            {
                if (tokenHandle != IntPtr.Zero) CloseHandle(tokenHandle);
            }
        }
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);
        private const UInt32 TOKEN_QUERY = 0x0008;
    }
}

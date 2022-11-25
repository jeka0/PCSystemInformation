using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace PCSystemInformation.SystemInformation
{
    public class HardDrivesInformation: IHardDrivesInformation
    {
        private DriveInfo[] drives;

        public HardDrivesInformation()
        {
            this.drives = DriveInfo.GetDrives();
        }

        public int GetDrivesCount(){ return drives.Length; }

        public String GetName(int index){ return drives[index].Name; }

        public String GetDriveFormat(int index) { return drives[index].DriveFormat; }

        public String GetDriveType(int index) { return drives[index].DriveType.ToString(); }

        public long GetAvailableFreeSpace(int index) { return drives[index].AvailableFreeSpace; }

        public String GetIsReady(int index) { return drives[index].IsReady.ToString(); }

        public String GetRootDirectory(int index) { return drives[index].RootDirectory.ToString(); }

        public long GetTotalFreeSpace(int index) { return drives[index].TotalFreeSpace; }

        public long GetTotalSize(int index) { return drives[index].TotalSize; }

        public String GetVolumeLabel(int index) 
        { 
            String str =  drives[index].VolumeLabel;
            if (str == "") return "-";
            return str;
        }
    }
}

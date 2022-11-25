using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation 
{ 
    interface IHardDrivesInformation
    {
        int GetDrivesCount();
        String GetName(int index);
        String GetDriveFormat(int index);
        String GetDriveType(int index);
        long GetAvailableFreeSpace(int index);
        String GetIsReady(int index);
        String GetRootDirectory(int index);
        long GetTotalFreeSpace(int index);
        long GetTotalSize(int index);
        String GetVolumeLabel(int index);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    interface IComputerInformation
    {
        String GetIEVetsion();
        String GetPCName();
        String GetUserName();
        String GetDomainName();
        String GetDateAndTime();
    }
}

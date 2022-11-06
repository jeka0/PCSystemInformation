using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.SystemInformation
{
    public class MotherboardInformation: IMotherboardInformation
    {
        private RegistryAccess registry;
        public MotherboardInformation()
        {
            registry = new RegistryAccess();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using PCSystemInformation.Models;

namespace PCSystemInformation.Controllers
{
    public class DisplayInformationController
    {
        private IDisplayInformation displayInformation;
        public DisplayInformationController()
        {
            displayInformation = new DisplayInformation();
        }
        public InformationBlock GetDisplayProperties()
        {
            InformationBlock informationBlock = new InformationBlock("Дисплей");
            informationBlock.elements.Add(new Element("Name", displayInformation.GetName()));
            informationBlock.elements.Add(new Element("Availability", displayInformation.GetAvailability()));
            informationBlock.elements.Add(new Element("MonitorManufacturer", displayInformation.GetMonitorManufacturer()));
            informationBlock.elements.Add(new Element("PNPDeviceID", displayInformation.GetPNPDeviceID()));
            informationBlock.elements.Add(new Element("Status", displayInformation.GetStatus()));
            informationBlock.elements.Add(new Element("GetPixelsPerXLogicalInch", displayInformation.GetPixelsPerXLogicalInch()));
            informationBlock.elements.Add(new Element("GetPixelsPerYLogicalInch", displayInformation.GetPixelsPerYLogicalInch()));
            return informationBlock;
        }
    }
}

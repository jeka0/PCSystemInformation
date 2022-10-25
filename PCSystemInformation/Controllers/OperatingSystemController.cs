using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSystemInformation.SystemInformation;
using System.Windows.Forms;

namespace PCSystemInformation.Controllers
{
    public class OperatingSystemController
    {
        private IOperatingSystem operatingSystem;
        public OperatingSystemController()
        {
            operatingSystem = new OperatingInformation();
        }
        public Dictionary<String, String> GetOperatingSystem()
        {
            Dictionary<String, String> pairs = new Dictionary<string, string>();
            pairs.Add("Операционная система", operatingSystem.GetVersion());
            return pairs;
            /*List <ListViewItem> listViewItems = new List<ListViewItem>();
            ListViewItem items = new ListViewItem("Операционная система");
            items.SubItems.Add(operatingSystem.GetVersion());
            listViewItems.Add(items);
            return listViewItems;*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.Models
{
    public class InformationBlock
    {
        public String Name { get; }
        public List<Element> elements { get; }
        public InformationBlock(String name)
        {
            this.Name = name;
            this.elements = new List<Element>();
        }
    }
}

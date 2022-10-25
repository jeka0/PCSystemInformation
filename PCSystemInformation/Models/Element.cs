using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCSystemInformation.Models
{
    public class Element
    {
        public String Name { get; }
        public String[] parts { get; }
        public Element(String name, params String[] parts)
        {
            this.Name = name;
            this.parts = parts;
        }
    }
}

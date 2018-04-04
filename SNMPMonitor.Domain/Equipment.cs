using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPMonitor.Domain
{
    public class Equipment
    {
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string UpTime { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPMonitor.Domain
{
    public class Interface
    {
        public string Index { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Speed { get; set; }
        public string MAC { get; set; }
        public string Administrative { get; set; }
        public string Operational { get; set; }
    }
}

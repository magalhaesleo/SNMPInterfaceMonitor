using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SNMPMonitor.Domain
{
    public class Interface
    {
        public int Index { get; set; }
        public string Description { get; set; }
        private int type;
        public string Type
        {
            get
            {
                NetworkInterfaceType interfaceType = (NetworkInterfaceType)type;
                return interfaceType.ToString() + " (" + type + ")";
            }
            set
            {
                type = int.Parse(value);
            }
        }
        public string Speed { get; set; }
        public string MAC { get; set; }
        private int administrativeStatus;
        public string AdministrativeStatus
        {
            get
            {
                OperationalStatus status = (OperationalStatus)administrativeStatus;
                return status.ToString() + "(" + administrativeStatus + ")";
            }
            set
            {
                administrativeStatus = int.Parse(value);
            }
        }
        private int operationalStatus { get; set; }
        public string OperationalStatus {
            get
            {
                OperationalStatus status = (OperationalStatus)operationalStatus;
                return status.ToString() + "(" + operationalStatus + ")";
            }
            set
            {
                operationalStatus = int.Parse(value);
            }
        }
        public int ErrorRateIn { get; set; }
        public int ErrorRateOut { get; set; }
        public int DiscardIn { get; set; }
        public int DiscardOut { get; set; }
        public int InUCastPkts { get; set; }
        public int OutUCastPkts { get; set; }

        public override string ToString()
        {
            return "Interface " + Index;
        }
    }
}

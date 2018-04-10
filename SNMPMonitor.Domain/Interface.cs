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
        public string MAC { get; set; }
        public int IfInOctets { get; set; }
        public int IfOutOctets { get; set; }
        public OperationalStatus AdministrativeStatus { get; set; }
        private int operationalStatus { get; set; }
        public OperationalStatus OperationalStatus { get; set; }
        public int ErrorRateIn { get; set; }
        public int ErrorRateOut { get; set; }
        public int DiscardIn { get; set; }
        public int DiscardOut { get; set; }
        public string Speed { get; set; }
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
        public string Status
        {
            get
            {
                if (AdministrativeStatus == OperationalStatus
                    && OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Up)
                {
                    return "Operational";
                }
                if (AdministrativeStatus == OperationalStatus
                    && OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Down)

                {
                    return "Down";
                }
                if (AdministrativeStatus == System.Net.NetworkInformation.OperationalStatus.Up
                    && OperationalStatus == System.Net.NetworkInformation.OperationalStatus.Down)

                {
                    return "Fail";
                }
                if (AdministrativeStatus == System.Net.NetworkInformation.OperationalStatus.Testing
                    && OperationalStatus == AdministrativeStatus)

                {
                    return "Testing";
                }
                return "N/A";
            }
            set
            {
                Status = value;
            }
        }
        public override string ToString()
        {
            return Index + " " + Description;
        }
    }
}

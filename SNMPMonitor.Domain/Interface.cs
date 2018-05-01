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
        public uint Index { get; set; }
        public string Description { get; set; }
        private uint _type;
        public string MAC { get; set; }
        public uint IfInOctets { get; set; }
        public uint IfOutOctets { get; set; }
        public OperationalStatus AdministrativeStatus { get; set; }
        private uint operationalStatus { get; set; }
        public OperationalStatus OperationalStatus { get; set; }
        public uint IfInUcastPkts { get; set; }
        public uint IfInNUcastPkts { get; set; }
        public uint IfOutUcastPkts { get; set; }
        public uint IfOutNUcastPkts { get; set; }
        public uint IfInErrors { get; set; }
        public uint IfOutErrors { get; set; }
        public uint DiscardIn { get; set; }
        public uint DiscardOut { get; set; }
        public uint Speed { get; set; }
        private DateTime _oldTime = DateTime.Now;
        public uint _oldIfInOctets = 0;
        public uint _oldIfOutOctets = 0;

        public decimal Utilization
        {
            get
            {
                //Calculo do tempo gasto
                DateTime currentTime = DateTime.Now;
                TimeSpan elapsedSpan = currentTime.Subtract(_oldTime);
                _oldTime = currentTime;
                uint totalBytes = (IfInOctets - _oldIfInOctets) + (IfOutOctets - _oldIfOutOctets);

                _oldIfInOctets = IfInOctets;
                _oldIfOutOctets = IfOutOctets;

                if (totalBytes == 0)
                    return 0;

                //long bytesPerSecond = (totalBytes * 8)* 100;
                decimal bytesPerSecond = totalBytes / elapsedSpan.Seconds;
                //decimal bitsPerSecond = bytesPerSecond * 8;
                decimal rateUtilization = bytesPerSecond / Speed;

                return rateUtilization;
            }
        }

        public uint ErrorRateIn
        {
            get
            {
                uint ret = 0;
                if (IfInErrors != 0 && (IfInUcastPkts != 0 || IfInNUcastPkts != 0))
                    ret = IfInErrors / (IfInUcastPkts + IfInNUcastPkts);

                return ret;
            }
        }
        public uint ErrorRateOut
        {
            get
            {
                uint ret = 0;
                if (IfOutErrors != 0 && (IfOutUcastPkts != 0 || IfOutNUcastPkts != 0))
                    ret = IfOutErrors / (IfOutUcastPkts + IfOutNUcastPkts);

                return ret;
            }
        }
        public uint DiscardRateIn
        {
            get
            {
                uint ret = 0;
                if (DiscardIn != 0 && (IfInUcastPkts != 0 || IfInNUcastPkts != 0))
                    ret = DiscardIn / (IfInUcastPkts + IfInNUcastPkts);

                return ret;

            }
        }
        public uint DiscardRateOut
        {
            get
            {
                uint ret = 0;
                if (DiscardOut != 0 && (IfOutUcastPkts != 0 || IfOutNUcastPkts != 0))
                    ret = DiscardOut / (IfOutUcastPkts + IfOutNUcastPkts);
                return ret;
            }
        }
        public string Type
        {
            get
            {
                NetworkInterfaceType interfaceType = (NetworkInterfaceType)_type;
                return interfaceType.ToString() + " (" + _type + ")";
            }
            set
            {
                _type = uint.Parse(value);
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

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
        private int _type;
        public string MAC { get; set; }
        public int IfInOctets { get; set; }
        public int IfOutOctets { get; set; }
        public OperationalStatus AdministrativeStatus { get; set; }
        private int operationalStatus { get; set; }
        public OperationalStatus OperationalStatus { get; set; }
        public int IfInUcastPkts { get; set; }
        public int IfInNUcastPkts { get; set; }
        public int IfOutUcastPkts { get; set; }
        public int IfOutNUcastPkts { get; set; }
        public int IfInErrors { get; set; }
        public int IfOutErrors { get; set; }
        public int DiscardIn { get; set; }
        public int DiscardOut { get; set; }
        public int Speed { get; set; }
        private int _oldIfInOctets = 0;
        private int _oldIfOutOctets = 0;
        private DateTime _inOldTime = DateTime.Now;
        private DateTime _outOldTime = DateTime.Now;

        public double InputUtilization
        {
            get
            {
                //Calculo do tempo gasto
                DateTime _currentTime = DateTime.Now;
                long elapsedTicks = _currentTime.Ticks - _inOldTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                _inOldTime = _currentTime;                          
                
                //Calculo da quantia de bits usado nesse intervalo de tempo
                long inOctects = IfInOctets - _oldIfInOctets;                                
                long totalBits = (inOctects * 8) * 100;
                _oldIfInOctets = IfInOctets;

                return totalBits / elapsedSpan.TotalSeconds;
            }
        }
        public double OutputUtilization
        {
            get
            {
                //Calculo do tempo gasto
                DateTime _currentTime = DateTime.Now;
                long elapsedTicks = _currentTime.Ticks - _outOldTime.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                _outOldTime = _currentTime;

                //Calculo da quantia de bits usado nesse intervalo de tempo
                long outOctects = IfOutOctets - _oldIfOutOctets;
                long totalBits = (outOctects * 8) * 100;
                _oldIfInOctets = IfOutOctets;

                return totalBits / elapsedSpan.TotalSeconds;
            }
        }
        public int ErrorRateIn
        {
            get
            {
                int ret = 0;
                if (IfInErrors != 0 && (IfInUcastPkts != 0 || IfInNUcastPkts != 0))
                    ret = IfInErrors / (IfInUcastPkts + IfInNUcastPkts);

                return ret;
            }
        }
        public int ErrorRateOut
        {
            get
            {
                int ret = 0;
                if (IfOutErrors != 0 && (IfOutUcastPkts != 0 || IfOutNUcastPkts != 0))
                    ret = IfOutErrors / (IfOutUcastPkts + IfOutNUcastPkts);

                return ret;
            }
        }
        public int DiscardRateIn
        {
            get
            {
                int ret = 0;
                if (DiscardIn != 0 && (IfInUcastPkts != 0 || IfInNUcastPkts != 0))
                    ret = DiscardIn / (IfInUcastPkts + IfInNUcastPkts);

                return ret;

            }
        }
        public int DiscardRateOut
        {
            get
            {
                int ret = 0;
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
                _type = int.Parse(value);
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

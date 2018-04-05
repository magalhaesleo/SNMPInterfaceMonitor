using SNMPMonitor.Communication;
using SNMPMonitor.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNMPMonitor.Services
{
    public class GetData
    {
        Get get = new Get();
        private string ip;
        private int port;
        private string communit;
        private int version;
        private int timeOut;
        private int retransmition;
        private int taxaErro;
        private string decValue;

        public GetData(string ip, int port, string communit, int version, int timeOut, int retransmition)
        {
            this.ip = ip;
            this.port = port;
            this.communit = communit;
            this.version = version;
            this.timeOut = timeOut;
            this.retransmition = retransmition;
        }

        public Equipment GetResumeOfEquipment()
        {

            Equipment equipment = new Equipment();

            switch (version)
            {
                case 1:
                    equipment.Description = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.1.0", timeOut);
                    equipment.Contact =  get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.4.0", timeOut);
                    equipment.Name =get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.5.0", timeOut);
                    equipment.Location = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.6.0", timeOut);
                    equipment.UpTime= get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.3.0", timeOut);
                    break;
                case 2:
                    equipment.Description = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.1.0", timeOut);
                    equipment.Contact = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.4.0", timeOut);
                    equipment.Name = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.5.0", timeOut);
                    equipment.Location = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.6.0", timeOut);
                    equipment.UpTime = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.1.3.0", timeOut);
                    break;
                default:
                    break;
            }
            
            return equipment;
        }

        public Interface GetResumeOfInterface(int _interface)
        {
            Interface inter = new Interface();
            switch (version)
            {
                case 1:
                    inter.Index = get.GetResponseV1(ip, port, communit, " 1.3.6.1.2.1.2.2.1.1." + _interface, timeOut);
                    inter.Description= get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.2." + _interface, timeOut);
                    inter.Type = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.3." + _interface, timeOut);
                    inter.Speed = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.5." + _interface, timeOut);
                    inter.MAC =get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.6." + _interface, timeOut);
                    inter.Administrative = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.7." + _interface, timeOut);
                    inter.Operational = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.8." + _interface, timeOut);
                    inter.ErrorRateIn = int.Parse(get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.14." + _interface, timeOut));
                    inter.ErrorRateOut = int.Parse(get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.20." + _interface, timeOut));
                    inter.DiscardIn = int.Parse(get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.13." + _interface, timeOut));
                    inter.DiscardOut = int.Parse(get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.2.1.19." + _interface, timeOut));
                    break;
                case 2:
                    inter.Index = get.GetResponseV2(ip, port, communit, " 1.3.6.1.2.1.2.2.1.1." + _interface, timeOut);
                    inter.Description = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.2." + _interface, timeOut);
                    inter.Type = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.3." + _interface, timeOut);
                    inter.Speed = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.5." + _interface, timeOut);
                    inter.MAC = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.6." + _interface, timeOut);
                    inter.Administrative = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.7." + _interface, timeOut);
                    inter.Operational = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.8." + _interface, timeOut);
                    inter.ErrorRateIn = int.Parse(get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.14." + _interface, timeOut));
                    inter.ErrorRateOut = int.Parse(get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.20." + _interface, timeOut));
                    inter.DiscardIn = int.Parse(get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.13." + _interface, timeOut));
                    inter.DiscardOut = int.Parse(get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.2.1.19." + _interface, timeOut));
                    break;
                default:
                    break;
            }
            
            return inter;
        }

        public int GetIndexOfInterfaces()
        {
            string index = "";
            switch (version)
            {
                case 1:
                     index = get.GetResponseV1(ip, port, communit, "1.3.6.1.2.1.2.1.0",  timeOut);
                    break;
                case 2:
                     index = get.GetResponseV2(ip, port, communit, "1.3.6.1.2.1.2.1.0",  timeOut);
                    break;
                default:
                    break;
            }
            
            return int.Parse(index);
        }

       
    }
}

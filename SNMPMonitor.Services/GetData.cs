using SNMPMonitor.Communication;
using SNMPMonitor.Domain;
using System;
using System.Net.NetworkInformation;

namespace SNMPMonitor.Services
{
    public class GetData
    {
        private Get _get;

        public GetData(string ip, int port, string communit, int version, int timeOut, int retransmition)
        {
            _get = new Get(ip, port, communit, version, timeOut, retransmition);
        }

        public Equipment GetResumeOfEquipment()
        {
            Equipment equipment = new Equipment();
            try
            {
                equipment.Description = _get.GetResponse("1.3.6.1.2.1.1.1.0");
                equipment.Contact = _get.GetResponse("1.3.6.1.2.1.1.4.0");
                equipment.Name = _get.GetResponse("1.3.6.1.2.1.1.5.0");
                equipment.Location = _get.GetResponse("1.3.6.1.2.1.1.6.0");
                
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel realizar a comunicação com o equipamento");
            }

            return equipment;
        }

        public Interface GetResumeOfInterface(uint index)
        {

            //capturar as informações do dispositivo
            Interface inter = new Interface();
            inter.Index = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.1." + index));
            inter.Description = _get.GetResponse("1.3.6.1.2.1.2.2.1.2." + index);
            inter.Type = _get.GetResponse("1.3.6.1.2.1.2.2.1.3." + index);
            inter.Speed = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.5." + index));
            inter.MAC = _get.GetResponse("1.3.6.1.2.1.2.2.1.6." + index);
            inter.AdministrativeStatus = (OperationalStatus)uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.7." + index));
            inter.OperationalStatus = (OperationalStatus)uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.8." + index));

            return inter;
        }

        public Interface GetUsageDetailsOfInterface(Interface Interface)
        {
            //Capturar a quantidade de pacotes de entrada
            Interface.IfInUcastPkts = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.11." + Interface.Index));
            Interface.IfInNUcastPkts = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.12." + Interface.Index));

            //Capturar a quantidade de pacotes de saida            
            Interface.IfOutUcastPkts = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.17." + Interface.Index));
            Interface.IfOutNUcastPkts = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.18." + Interface.Index));
            Interface.IfInErrors = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.14." + Interface.Index));
            Interface.IfOutErrors = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.20." + Interface.Index));
            Interface.DiscardIn = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.13." + Interface.Index));
            Interface.DiscardOut = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.19." + Interface.Index));

            //Capturar os dados de uso da interface
            Interface.IfInOctets = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.10." + Interface.Index));
            Interface.IfOutOctets = uint.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.16." + Interface.Index));

            return Interface;
        }
        public int GetIndexOfInterfaces()
        {
            string index = _get.GetResponse("1.3.6.1.2.1.2.1.0");

            return int.Parse(index);
        }
        public string GetTimeUp()
        {
            return _get.GetResponse("1.3.6.1.2.1.1.3.0");
        }
        public string GetTemperature(string oid)
        {
            return _get.GetResponse(oid);
        }

        public string GetMemory(string oid)
        {
            return _get.GetResponse(oid);
        }

        public string GetCPUUsage(string oid)
        {
            return _get.GetResponse(oid);
        }

    }
}

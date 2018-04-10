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
                equipment.UpTime = _get.GetResponse("1.3.6.1.2.1.1.3.0");
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel realizar a comunicação com o equipamento");
            }

            return equipment;
        }

        public Interface GetResumeOfInterface(int index)
        {
            //capturar as informações do dispositivo
            Interface inter = new Interface();
            inter.Index = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.1." + index));
            inter.Description = _get.GetResponse("1.3.6.1.2.1.2.2.1.2." + index);
            inter.Type = _get.GetResponse("1.3.6.1.2.1.2.2.1.3." + index);
            inter.Speed = _get.GetResponse("1.3.6.1.2.1.2.2.1.5." + index);
            inter.MAC = _get.GetResponse("1.3.6.1.2.1.2.2.1.6." + index);
            inter.AdministrativeStatus = (OperationalStatus)int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.7." + index));
            inter.OperationalStatus = (OperationalStatus)int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.8." + index));

            return inter;
        }

        public Interface GetUsageDetailsOfInterface(Interface Interface)
        {
            //Capturar a quantidade de pacotes de entrada
            int ifInUcastPkts = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.11." + Interface.Index));
            int ifInNUcastPkts = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.12." + Interface.Index));

            //Capturar a quantidade de pacotes de saida            
            int ifOutUcastPkts = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.17." + Interface.Index));
            int ifOutNUcastPkts = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.18." + Interface.Index));

            //Validar se o valor nao é zero para nao fazer a divisao
            if (ifInUcastPkts != 0 || ifInNUcastPkts != 0)
            {
                int ifInErrors = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.14." + Interface.Index));
                if (ifInErrors != 0)
                    Interface.ErrorRateIn = ifInErrors / (ifInUcastPkts + ifInNUcastPkts);

                int DiscardIn = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.13." + Interface.Index));
                if (DiscardIn != 0)
                    Interface.DiscardIn = DiscardIn / (ifInUcastPkts + ifInNUcastPkts);
            }
            if (ifOutUcastPkts != 0 || ifOutNUcastPkts != 0)
            {
                int ifOutErrors = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.20." + Interface.Index));
                if (ifOutErrors != 0)
                    Interface.ErrorRateOut = ifOutErrors / (ifOutUcastPkts + ifOutNUcastPkts);

                int DiscardOut = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.19." + Interface.Index));
                if (DiscardOut != 0)
                    Interface.DiscardOut = DiscardOut / (ifOutUcastPkts + ifOutNUcastPkts);
            }

            //Capturar os dados de uso da interface
            Interface.IfInOctets = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.10." + Interface.Index));
            Interface.IfOutOctets = int.Parse(_get.GetResponse("1.3.6.1.2.1.2.2.1.16." + Interface.Index));

            return Interface;
        }
        public int GetIndexOfInterfaces()
        {
            string index = _get.GetResponse("1.3.6.1.2.1.2.1.0");

            return int.Parse(index);
        }

    }
}

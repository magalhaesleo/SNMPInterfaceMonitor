using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Net;

namespace SNMPMonitor.Communication
{
    public class Get
    {
        private string ip;
        private int port;
        private string communit;
        private int timeOut;
        private readonly VersionCode snmpVersion;
        public Get(string ip, int port, string communit, int version, int timeOut)
        {            
            this.ip = ip;
            this.port = port;
            this.communit = communit;
            switch (version)
            {
                case 2:
                    snmpVersion = VersionCode.V2;
                    break;
                default:
                    snmpVersion = VersionCode.V1;
                    break;
            }
            this.timeOut = timeOut;
        }

        public string GetResponse(string oid)
        {             
            IList<Variable> result = Messenger.Get(snmpVersion, new IPEndPoint(IPAddress.Parse(ip), port),
             new OctetString(communit),
             new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
             timeOut);

            if (oid.Substring(0, oid.Length - 2) == "1.3.6.1.2.1.2.2.1.6")
            {
                string mac = "";
                try
                {
                    mac = ((OctetString)result[0].Data).ToPhysicalAddress().ToString();
                    for (int i = 2; i < mac.Length; i += 2)
                    {
                        mac = mac.Insert(i, "-");
                        i++;
                    }
                }
                catch (Exception)
                {
                }

                return mac;
            }

            return result[0].Data.ToString();
        }
    }
}

using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SNMPMonitor.Communication
{
    public class Get
    {
        public string GetResponseV1(string ip, int port, string communit, string oid, int timeout = 60000)
        {
            IList<Variable> result = Messenger.Get(VersionCode.V1, new IPEndPoint(IPAddress.Parse(ip), port),
             new OctetString(communit),
             new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
             timeout);

            return result[0].Data.ToString();
        }

        public string GetResponseV2(string ip, int port, string communit, string oid, int timeout = 60000)
        {
            IList<Variable> result = Messenger.Get(VersionCode.V2, new IPEndPoint(IPAddress.Parse(ip), port),
             new OctetString(communit),
             new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
             timeout);

            return result[0].Data.ToString();
        }
    }
}

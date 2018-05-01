using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System;
using System.Collections.Generic;
using System.Net;

namespace SNMPMonitor.Communication
{
    public class Get
    {
        private string _ip;
        private int _port;
        private string _communit;
        private int _timeOut;
        private int _tries;
        private readonly VersionCode _snmpVersion;
        public Get(string ip, int port, string communit, int version, int timeOut, int tries)
        {
            this._ip = System.Text.RegularExpressions.Regex.Replace(ip, "0*([0-9]+)", "${1}");
            this._port = port;
            this._communit = communit;
            this._tries = tries;

            switch (version)
            {
                case 2:
                    _snmpVersion = VersionCode.V2;
                    break;
                default:
                    _snmpVersion = VersionCode.V1;
                    break;
            }
            this._timeOut = timeOut;
        }

        public string GetResponse(string oid)
        {
            int retries = 0;

            while (retries < _tries)
            {
                 IList<Variable> result = Messenger.Get(_snmpVersion, new IPEndPoint(IPAddress.Parse(_ip), _port),
                 new OctetString(_communit),
                 new List<Variable> { new Variable(new ObjectIdentifier(oid)) },
                 _timeOut);

                if (oid.Substring(0, oid.LastIndexOf(".")) == "1.3.6.1.2.1.2.2.1.6")
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
                    if (mac.Length > 0)
                        return mac;
                }

                if (result.Count > 0)                
                    return result[0].Data.ToString();
       
                retries++;
            }
            return "";
        }
    }
}

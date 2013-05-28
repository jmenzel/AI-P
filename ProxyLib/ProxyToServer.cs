using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLib
{
    public class ProxyToServer : MarshalByRefObject, IProxyServer
    {
        public static RegisterServer registerServer { get; set; }

        public ProxyToServer()
        { }

        public void sendServerInfo(ServerInfo info)
        {
            registerServer(info);
        }

    }
}

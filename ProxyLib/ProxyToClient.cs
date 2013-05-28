using ProxyLib.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLib
{


    public class ProxyToClient : MarshalByRefObject, IProxyClient
    {
        public static GetServer getNextServer { get; set; }
        public static RegisterClient registerClient { get; set; }
        public static RegisteredServerCount serverCount { get; set; }

        public ProxyToClient()
        { }

        private static string buildConnectionString(ServerInfo info)
        {
            return "tcp://" + info.ip + ":" + info.servicePort + "/" + info.serviceName;
        }

        public bool anyServerAvailable()
        {
            return ProxyToClient.getNextServer().id != Guid.Empty;
        }

        public T getServiceHost<T>(ClientInfo info)
        {
            if (serverCount() == 0) return default(T);
            //Besten/Nächsten bekannten Server ermitteln
            ServerInfo server = ProxyToClient.getNextServer();


            //Client eintragen / aktualisieren
            ProxyToClient.registerClient(info, server);


            //ChannelSettings für Client & Server definieren
            IDictionary channelSettings = new Hashtable();
            channelSettings["name"] = Guid.NewGuid().ToString();
            channelSettings["username"] = "";
            channelSettings["password"] = "";

            //Channel erstellen
            TcpChannel channel = new TcpChannel(channelSettings, null, null);
            ChannelServices.RegisterChannel(channel, true);

            //Lazy IService com Server holen und an Client geben
            Lazy<T> s = new Lazy<T>(() => (T)Activator.GetObject(typeof(T), ProxyToClient.buildConnectionString(server)));
            return s.Value;
        }
    }

    
}

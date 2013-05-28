using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using ProxyLib;
using System.Security.Principal;
using ProxyLib.Services;

namespace ProxyService
{
    class ProxyService
    {
        private IDictionary<Guid, ServerInfo> registeredServer = new Dictionary<Guid, ServerInfo>();
        private IDictionary<Guid, ClientInfo> registeredClients = new Dictionary<Guid, ClientInfo>();

        public ProxyService(string serverSideServiceName, int serverSideServicePort, string clientSideServiceName, int clientSideServicePort)
        {
            //Define static Callbacks! Vor dem starten der Channels!
            ProxyToServer.registerServer = newServer;

            ProxyToClient.registerClient = newClient;
            ProxyToClient.getNextServer = nextServer;
            ProxyToClient.serverCount = () => registeredServer.Count;

            Console.Write("Starting Proxy... ");
            RegisterChannelToServers(serverSideServiceName, serverSideServicePort);
            RegisterChannelToClients(clientSideServiceName, clientSideServicePort);
            Console.WriteLine("Ready !");
            Console.WriteLine("Press any Key to Stop the Proxyserver...");
        }

        private void newClient(ClientInfo info)
        {
            registeredClients[info.id] = info;
            Console.WriteLine("New Client " + info.id + " -> " + info.ip + ", " + info.name + ", " + info.applicationUptimeTimestamp);
        }

        private ServerInfo nextServer()
        {
            foreach (var entry in this.registeredServer)
            {
                //TODO Take best Server
                return entry.Value;
            }
            return null;
        }

        private void newServer(ServerInfo info)
        {
            registeredServer[info.id] = info;

            Console.WriteLine("Server Message " + info.id + " -> " + info.name + ", " + info.ip + ", " + info.servicePort + ", " + info.serviceName);
        }

        static void RegisterChannelToServers(string serviceName, int servicePort)
        {
            SecurityIdentifier Sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            Hashtable ht = new Hashtable();
            ht["name"] = "ProxyServerChannel";
            ht["port"] = servicePort;

            TcpChannel channel = new TcpChannel(ht, null, provider);
            ChannelServices.RegisterChannel(channel, false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProxyToServer), serviceName, WellKnownObjectMode.Singleton);
        }

        static void RegisterChannelToClients(string serviceName, int servicePort)
        {
            Hashtable ht = new Hashtable();
            ht["name"] = "ProxyClientChannel";
            ht["port"] = servicePort;

            TcpChannel channel = new TcpChannel(ht, null, null);
            ChannelServices.RegisterChannel(channel, true);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProxyToClient), serviceName, WellKnownObjectMode.Singleton);
        }
    }
}
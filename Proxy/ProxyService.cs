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
using System.Threading;

namespace ProxyService
{
    class ProxyService
    {
        public const short SERVER_FAIL_TIME = 20;
        public const short SERVER_SESSION_INFO_CAPACITY = 50;


        private IDictionary<Guid, ServerSession> registeredServer = new Dictionary<Guid, ServerSession>();
        private IDictionary<Guid, uint> lastServerUpdate = new Dictionary<Guid, uint>();
        private IDictionary<Guid, ClientInfo> registeredClients = new Dictionary<Guid, ClientInfo>();
        private ISet<Guid> ignoredServer = new HashSet<Guid>();


        private bool checkServer;
        private Thread checkServerThread;

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

            checkServer = true;
            checkServerThread = new Thread(new ThreadStart(checkServerIsAvailable));
            checkServerThread.Start();
        }

        ~ProxyService()
        {
            checkServer = false;
            checkServerThread.Interrupt();
        }

        private void newClient(ClientInfo info)
        {
            //Aktuelle Nachricht speichern
            registeredClients[info.id] = info;

            //Timestamp der letzten Nachricht speichern
            lastServerUpdate[info.id] = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            Console.WriteLine("New Client " + info.id + " -> " + info.ip + ", " + info.name + ", " + info.applicationUptimeTimestamp);
        }

        private ServerInfo nextServer()
        {
            KeyValuePair<Guid, ServerSession> bestServer = registeredServer.Single(x=> x.Value.infoList.Last().cpuUsagePercent == registeredServer.Min(y => y.Value.infoList.Last().cpuUsagePercent));
            return bestServer.Value.infoList.Last();
        }

        private void newServer(ServerInfo info)
        {
            if(ignoredServer.Contains(info.id)) return;

            if(!registeredServer.ContainsKey(info.id)) registeredServer[info.id] = new ServerSession { id = info.id, status = ServerStatus.Online };
            if(registeredServer[info.id].infoList.Count > SERVER_SESSION_INFO_CAPACITY) registeredServer[info.id].infoList.RemoveAt(0);

            registeredServer[info.id].infoList.Add(info);


            Console.WriteLine("New Server " + info.id + " -> " + info.name + ", " + info.ip + ", " + info.servicePort + ", " + info.serviceName + ", " + info.cpuUsagePercent + ", " + info.memoryUsagePercent);
        }

        private void checkServerIsAvailable()
        {
            while (checkServer)
            {
                uint aktTimestamp = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                foreach (var server in lastServerUpdate)
                {
                    if ((aktTimestamp - server.Value) > SERVER_FAIL_TIME)
                    {
                        registeredServer.Remove(server.Key);
                    }
                }

                Thread.Sleep(1000);
            }
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

        public ServerInfo getServerById(Guid id)
        {
            return registeredServer[id].infoList.Last();
        }

        public IDictionary<Guid, ServerSession> getServerList()
        {
            return this.registeredServer;
        }

        public void addServerToIgnoreList(Guid serverId)
        {
            this.ignoredServer.Add(serverId);
        }

        public void removeServerFromIgnoreList(Guid serverId)
        {
            this.ignoredServer.Remove(serverId);
        }
    }
}
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
        public const short SERVER_SESSION_INFO_CAPACITY = 25;


        private IDictionary<Guid, ServerSession> registeredServer = new Dictionary<Guid, ServerSession>();
        private IDictionary<Guid, ClientInfo> registeredClients = new Dictionary<Guid, ClientInfo>();


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

        private void newClient(ClientInfo cInfo, ServerInfo sInfo)
        {
            //Aktuelle Nachricht speichern
            registeredClients[cInfo.id] = cInfo;
            registeredServer[sInfo.id].handeledClients.Add(cInfo.id);
            Console.WriteLine("Client " + cInfo.id + " -> " + cInfo.ip + ", " + cInfo.name + ", " + cInfo.applicationUptimeTimestamp);
        }

        private ServerInfo nextServer()
        {
            try
            {
                KeyValuePair<Guid, ServerSession> bestServer = registeredServer.Single((x => (x.Value.infoList.Last().cpuUsagePercent == registeredServer.Where(a => a.Value.status == ServerStatus.Online)
                                                                                                                                                      .Min(y => y.Value.infoList.Last().cpuUsagePercent))));
                return bestServer.Value.infoList.Last();
            }
            catch
            {
                return new ServerInfo(Guid.Empty, "", "", "", "", 0, 0, 0);
            }
        }

        private void newServer(ServerInfo info)
        {
            if (!registeredServer.ContainsKey(info.id))
            {
                //Check if "new Server" in list with old GUID
                var oldS = registeredServer.Where(x => { return (x.Value.infoList.Last().ip == info.ip)
                                                               && (x.Value.infoList.Last().servicePort == info.servicePort)
                                                               && (x.Value.infoList.Last().name == info.name)
                                                               && (x.Value.infoList.Last().serviceName == info.serviceName);});

                foreach (KeyValuePair<Guid, ServerSession> pair in oldS.ToArray())
                {
                    registeredServer.Remove(pair.Key);
                }

                registeredServer[info.id] = new ServerSession { id = info.id, status = ServerStatus.Online };
            }
            if (registeredServer[info.id].infoList.Count > SERVER_SESSION_INFO_CAPACITY) registeredServer[info.id].infoList.RemoveAt(0);
            if (registeredServer[info.id].status == ServerStatus.NotAvailable) registeredServer[info.id].status = ServerStatus.Online;
            registeredServer[info.id].infoList.Add(info);
            registeredServer[info.id].lastReceivedTimestamp = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            

            Console.WriteLine("Server " + info.id + " -> " + info.name + ", " + info.ip + ", " + info.servicePort + ", " + info.serviceName + ", " + info.cpuUsagePercent + ", " + info.memoryUsagePercent);
        }

        private void checkServerIsAvailable()
        {
            while (checkServer)
            {
                uint aktTimestamp = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

                foreach (var server in registeredServer)
                {
                    if ((aktTimestamp - server.Value.lastReceivedTimestamp) > SERVER_FAIL_TIME)
                    {
                        //registeredServer.Remove(server.Key);
                        registeredServer[server.Key].status = ServerStatus.NotAvailable;
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

        public ServerSession getServerById(Guid id)
        {
            return registeredServer[id];//.infoList.Last();
        }

        public IDictionary<Guid, ServerSession> getServerList()
        {
            return this.registeredServer;
        }

        public void ignoreServer(Guid serverId)
        {
            this.registeredServer[serverId].status = ServerStatus.Ignored;
        }

        public void activateServer(Guid serverId)
        {
            this.registeredServer[serverId].status = ServerStatus.Online;
        }
    }
}
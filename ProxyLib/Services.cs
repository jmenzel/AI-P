using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyLib.Services
{
    public delegate ServerInfo GetServer();
    public delegate void RegisterClient(ClientInfo cInfo, ServerInfo sInfo);
    public delegate int RegisteredServerCount();

    public delegate void RegisterServer(ServerInfo info);

    [Serializable()]
    public abstract class HostInfo
    {
        public Guid id { get; protected set; }
        public string name { get; protected set; }
        public string ip { get; protected set; }
    }

    [Serializable()]
    public class ClientInfo : HostInfo
    {
        public uint applicationUptimeTimestamp { get; set; }

        public ClientInfo(Guid id, string name, string ip, uint applicationUptimeTimestamp)
        {
            this.id = id;
            this.name = name;
            this.ip = ip;
            this.applicationUptimeTimestamp = applicationUptimeTimestamp;
        }
    }

    [Serializable()]
    public class ServerInfo : HostInfo
    {
        public uint serverUptimeTimestamp { get; set; }
        public uint cpuUsagePercent { get; set; }
        public uint memoryUsagePercent { get; set; }
        public string servicePort { get; set; }
        public string serviceName { get; set; }

        public ServerInfo(Guid id, string name, string ip, string servicePort, string serviceName, uint serverUptimeTimestamp, uint cpuUsagePercent, uint memoryUsagePercent)
        {
            this.id = id;
            this.name = name;
            this.ip = ip;
            this.servicePort = servicePort;
            this.serviceName = serviceName;
            this.serverUptimeTimestamp = serverUptimeTimestamp;
            this.cpuUsagePercent = cpuUsagePercent;
            this.memoryUsagePercent = memoryUsagePercent;
        }
    }

    [Serializable()]
    public class ServerSession
    {
        public Guid id { get; set; }
        public ServerStatus status { get; set; }
        public IList<ServerInfo> infoList = new List<ServerInfo>();
        public uint lastReceivedTimestamp { get; set; }
        public ISet<Guid> handeledClients = new HashSet<Guid>();
    }

    [Serializable()]
    public enum ServerStatus
    {
        NotAvailable,
        Ignored,
        Online
    }
}
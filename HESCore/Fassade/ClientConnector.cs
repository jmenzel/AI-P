﻿using ProxyLib;
using ProxyLib.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HES.Fassade
{
    public class ClientConnector
    {
        private IProxyServer proxy = null;
        private int proxyPort = 9000;
        private string proxyIp = "localhost";

        private int HESPort = 4820;

        private ServerInfo info = null;

        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private Thread updateThread;
        private bool sendUpdate;

        public ClientConnector()
        {
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            getCurrentCpuUsage();
            getAvailableRAM();

            info = new ServerInfo(Guid.NewGuid(), "HES Server", System.Net.Dns.GetHostName(), HESPort.ToString(), "Service", ((uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds), getCurrentCpuUsage(), getAvailableRAM());

            RegisterProxyChannel();
            RegisterClientChannel();

            sendUpdate = true;
            updateThread = new Thread(new ThreadStart(sendingServerStatus));
            updateThread.Start();

        }

        ~ClientConnector()
        {
            sendUpdate = false;
            updateThread.Interrupt();
        }

        private void RegisterClientChannel()
        {
            Hashtable ht = new Hashtable();
            ht["name"] = "ClientChannel";
            ht["port"] = 4820;

            TcpChannel channel = new TcpChannel(ht, null, null);
            ChannelServices.RegisterChannel(channel, true);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Fassade),
                "Service",
                WellKnownObjectMode.SingleCall);
        }

        private void RegisterProxyChannel()
        {
            TcpChannel channel = new TcpChannel(9003);
            ChannelServices.RegisterChannel(channel, false);

            object obj = Activator.GetObject(typeof(IProxyServer), "tcp://"+proxyIp+":"+proxyPort+"/ProxyServerService");
            proxy = (IProxyServer)obj;
            proxy.sendServerInfo(info);
        }

        private uint getCurrentCpuUsage()
        {
            return (uint)cpuCounter.NextValue();
        }

        private uint getAvailableRAM()
        {
            return (uint)ramCounter.NextValue();
        }

        private void sendingServerStatus()
        {
            while (sendUpdate)
            {
                System.Threading.Thread.Sleep(5000);
                info.cpuUsagePercent = getCurrentCpuUsage();
                info.memoryUsagePercent = getAvailableRAM();
                proxy.sendServerInfo(info);
            }
        }
    }
}

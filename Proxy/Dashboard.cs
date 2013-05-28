using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    partial class Dashboard : Form
    {
        private ProxyService.ProxyService proxy;
        private bool doUpdate;
        private Thread updateThread;

        public Dashboard(ProxyService.ProxyService p)
        {
            this.proxy = p;

            InitializeComponent();
            this.doUpdate = true;
            this.updateThread = new Thread(new ThreadStart(this.updateServerList));
            this.updateThread.Start();
        }

        private void fillServerList()
        {
            if (lb_serverList.InvokeRequired) lb_serverList.Invoke((Action)(() => { fillServerList(); }));
            else
            {
                object selected = lb_serverList.SelectedItem;

                lb_serverList.Items.Clear();
                foreach (var server in proxy.getServerList())
                {
                    this.lb_serverList.Items.Add(server.Key);
                }

                lb_serverList.SelectedItem = selected;
            }
        }

        private void lb_serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            setServerDetails(proxy.getServerById((Guid)lb_serverList.SelectedItem));
            gb_serverDetail.Visible = true;
        }

        private void setServerDetails(ServerInfo info)
        {
            string s = "";

            s += "GUID = " + info.id + Environment.NewLine;
            s += "Name = " + info.name + Environment.NewLine;
            s += "Host = " + info.ip + Environment.NewLine;
            s += "CPU % = " + info.cpuUsagePercent + Environment.NewLine;
            s += "RAM free MB = " + info.memoryUsagePercent + Environment.NewLine;

            this.ta_serverInfo.Text = s;
        }

        private void updateServerList()
        {
            while (doUpdate)
            {
                this.fillServerList();
                Thread.Sleep(1000);
            }
        }
    }
}

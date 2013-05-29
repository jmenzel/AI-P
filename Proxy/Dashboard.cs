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
        private Guid lastSelected;

        public Dashboard(ProxyService.ProxyService p)
        {
            this.proxy = p;

            InitializeComponent();
            this.doUpdate = true;
            this.updateThread = new Thread(new ThreadStart(this.updateServerList));
            this.updateThread.Start();
        }

        ~Dashboard()
        {
            this.doUpdate = false;
            this.updateThread.Interrupt();
            //TODO CHeck exception beim breakup
            Environment.Exit(0);
        }

        private void fillServerList()
        {
            if (lv_serverList.InvokeRequired) lv_serverList.Invoke((Action)(() => { fillServerList(); }));
            else
            {
                int selected = -1;
                if(lv_serverList.SelectedItems.Count > 0 ) selected = lv_serverList.SelectedIndices[0];

                lv_serverList.Items.Clear();
                foreach (var server in proxy.getServerList())
                {
                    this.lv_serverList.Items.Add(server.Key.ToString());

                    switch (server.Value.status)
                    {
                        case ServerStatus.Online: 
                            lv_serverList.FindItemWithText(server.Value.id.ToString()).BackColor = Color.LightGreen;
                            break;
                        case ServerStatus.Ignored:
                            lv_serverList.FindItemWithText(server.Value.id.ToString()).BackColor = Color.Yellow;
                            break;
                        case ServerStatus.NotAvailable:
                            lv_serverList.FindItemWithText(server.Value.id.ToString()).BackColor = Color.LightCoral;
                            break;
                        default:
                            break;
                    }
                }

                if (selected != -1) lv_serverList.Items[selected].Selected = true;

            }
        }

        private void setServerDetails(ServerSession session)
        {
            ServerInfo info = session.infoList.Last();
            string s = "";
            uint aktTimestamp = (uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;

            s += "GUID = " + info.id + Environment.NewLine;
            s += "Name = " + info.name + Environment.NewLine;
            s += "Host = " + info.ip + Environment.NewLine;
            s += "ServiceName = " + info.serviceName + Environment.NewLine;
            s += "ServicePort = " + info.servicePort + Environment.NewLine;
            s += "Handled Clients = " + session.handeledClients.Count() + Environment.NewLine;

            if (session.status != ServerStatus.NotAvailable)
            {
                s += "App Uptime = " + (aktTimestamp - info.serverUptimeTimestamp) + " Seconds" + Environment.NewLine;
                s += "CPU = " + info.cpuUsagePercent + " %" + Environment.NewLine;
                s += "Free RAM = " + info.memoryUsagePercent + " MB" + Environment.NewLine;
            }

            this.ta_serverInfo.Text = s;

            switch (session.status)
            {
                case ServerStatus.Online:
                    b_serverStatus.Text = "Ignore";
                    b_serverStatus.Enabled = true;
                    break;
                case ServerStatus.Ignored:
                    b_serverStatus.Text = "Activate";
                    b_serverStatus.Enabled = true;
                    break;
                case ServerStatus.NotAvailable:
                    b_serverStatus.Text = "Unavailable";
                    b_serverStatus.Enabled = false;
                    break;
                default:
                    break;
            }


            chartCpu.Series[0].Points.Clear();
            chartMem.Series[0].Points.Clear(); 

            foreach (ServerInfo value in session.infoList)
            {
                chartCpu.Series[0].Points.Add(value.cpuUsagePercent);
                chartMem.Series[0].Points.Add(value.memoryUsagePercent);
            }
        }

        private void updateServerList()
        {
            try
            {
                while (doUpdate)
                {
                    this.fillServerList();
                    Thread.Sleep(1000);
                }
            }
            catch
            { }
        }

        private void lv_serverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv_serverList.SelectedItems.Count == 0)
            {
                if (lastSelected != null) setServerDetails(proxy.getServerById(lastSelected));
                return;
            }
            lastSelected = Guid.Parse(lv_serverList.SelectedItems[0].Text);
            setServerDetails(proxy.getServerById(lastSelected));
            gb_serverDetail.Visible = true;
        }

        private void b_serverStatus_Click(object sender, EventArgs e)
        {
            switch (b_serverStatus.Text.ToLower())
            {
                case "ignore":
                    b_serverStatus.Enabled = false;
                    proxy.ignoreServer(lastSelected);
                    lv_serverList.FindItemWithText(lastSelected.ToString()).Selected = true;
                    break;
                case "activate":
                    b_serverStatus.Enabled = false;
                    proxy.activateServer(lastSelected);
                    lv_serverList.FindItemWithText(lastSelected.ToString()).Selected = true;
                    break;
                default:
                    break;
            }
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            doUpdate = false;
            updateThread.Interrupt();
            this.Dispose(true);
            Environment.Exit(0);
        }
    }
}

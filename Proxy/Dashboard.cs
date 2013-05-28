using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proxy
{
    public partial class Dashboard : Form
    {
        private ProxyService.ProxyService proxy;

        public Dashboard(ProxyService.ProxyService p)
        {
            this.proxy = p;

            InitializeComponent();

        }

        private void fillServerList()
        {
            foreach (var server in proxy.getServerList())
            {
                this.lb_serverList.Items.Add(server.Key);
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

            s += "GUID = " + info.id;
            s += "Name = " + info.name;
            s += "Host = " + info.ip;
            s += "CPU % = " + info.cpuUsagePercent;
            s += "RAM free MB = " + info.memoryUsagePercent;

            this.ta_serverInfo.Text = s;
        }
    }
}

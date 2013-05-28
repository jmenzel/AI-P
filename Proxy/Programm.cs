using Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyService
{
    class Programm
    {
        static void Main(string[] args)
        {

            ProxyService p = new ProxyService("ProxyServerService", 9000, "ProxyClientService", 4821);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Dashboard(p));

            Console.ReadKey();
        }
    }
}

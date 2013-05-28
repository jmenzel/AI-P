using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyService
{
    class Programm
    {
        static void Main(string[] args)
        {

            ProxyService p = new ProxyService("ProxyServerService", 9000, "ProxyClientService", 4821);

            Console.ReadKey();
        }
    }
}

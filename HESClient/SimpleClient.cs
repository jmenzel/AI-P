using HES.Fassade;
using ProxyLib;
using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace HESClient
{
    public class SimpleClient
    {
        private ClientInfo info = null;
        private IProxyClient proxy = null;

        public SimpleClient()
        {
            info = new ClientInfo(Guid.NewGuid(), "HES Simple Client", System.Net.Dns.GetHostName(), ((uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds));

            string location = "tcp://localhost:4821/ProxyClientService";

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, true);

            proxy = (IProxyClient)Activator.GetObject(typeof(IProxyClient), location);

            try
            {
                Console.WriteLine("Try to get IService instance");
                IHes hes = proxy.getServiceHost<IHes>(info);
                Console.WriteLine("Got it!");

                Console.WriteLine("Ladida");
                               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }


        }

        public static void Main(string[] args)
        {
            SimpleClient client = new SimpleClient();
            Console.ReadKey();

        }
    }
}

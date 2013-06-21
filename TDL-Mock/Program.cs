using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace TDL_Mock
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHost host = new WebServiceHost(typeof(TDLService), new Uri("http://localhost:8000/"));
            host.Faulted += host_Faulted;
            host.UnknownMessageReceived += host_UnknownMessageReceived;

            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(ITDL), new WebHttpBinding(), "itdl");

            host.Open();
            Console.WriteLine("ITDL Service is running");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
        }

        static void host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            Console.WriteLine("Unknown Message " + sender.ToString() + " : " + e.Message.ToString());
        }

        private static void host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("Error Faulted");
        }
    }
}

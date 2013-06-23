using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace TDL_Mock
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAdress = "http://localhost:8000/";
            var config = new HttpSelfHostConfiguration(baseAdress);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            Console.WriteLine("Instantiating the Server...");

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Server is Running Now ... @ " + baseAdress);
                Console.ReadLine();
            }

        }
    }
}

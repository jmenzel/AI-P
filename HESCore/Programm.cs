using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES
{
    class Programm
    {
        private const string default_service_name = "HES-Server";
        private const int default_service_port = 4820;

        static void Main(string[] args)
        {
            string service_name = "";
            int service_port = -1;
            
            try
            {
                if (args.Length == 2)
                {
                    service_name = args[0];
                    service_port = Convert.ToInt32(args[1]);
                }
            }
            catch
            {
                Console.WriteLine("Failed parsing prameters\n Using default values...");
                service_name = default_service_name;
                service_port = default_service_port;
            }

            Console.Write("Starting HES Service with Name '" + service_name + "' on Port '" + service_port + "' ...");

            HES.Core.Core hes = new Core.Core(service_name, service_port);

            Console.WriteLine(" ready!");
            Console.WriteLine("Press any Key to terminate...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

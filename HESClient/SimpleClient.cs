using HES.Fassade;
using HES.Kunde.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using HES.TransportComp.Repository.Entity;
using ProxyLib;
using ProxyLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HESClient
{
    public class SimpleClient
    {
        private ClientInfo info = null;
        private IProxyClient proxy = null;
        private IHes IHes = null;

        public SimpleClient()
        {
            info = new ClientInfo(Guid.NewGuid(), "HES Simple Client", System.Net.Dns.GetHostName(), ((uint)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds));

            string location = "tcp://localhost:4821/ProxyClientService";

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel, true);



            proxy = (IProxyClient)Activator.GetObject(typeof(IProxyClient), location);

            try
            {
                while (!proxy.anyServerAvailable())
                {
                    Console.WriteLine("Try to get IService instance");
                    Thread.Sleep(1000);
                }
                IHes = proxy.getServiceHost<IHes>(info);
                Console.WriteLine("Got it!");

                Console.WriteLine("Ladida");
                               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
            }

            startSzenario();

        }

        private void startSzenario()
        {
            #region Komponenten initialisieren

            var prodLaptop = IHes.erstelleProdukt(new ProduktDetailsTyp(new ProduktNummerTyp("425097364"), "Laptop X750", 1200D));
            var prodFestplatte = IHes.erstelleProdukt(new ProduktDetailsTyp(new ProduktNummerTyp("09876528635"), "Festplatte Toshiba J200", 250.49));
            var prodKabel = IHes.erstelleProdukt(new ProduktDetailsTyp(new ProduktNummerTyp("2389765935"), "Kabel HDMI", 12.99));
            IDictionary<ProduktNummerTyp, int> produkteFuerAngbeot;
            
            IHes.erstelleKunden("Buskulic", "Dino", DateTime.Parse("26.05.1989"), KundenLevel.HighOrder, "Test 1", "20539", "Hamburg", "Deutschland");
            IHes.erstelleKunden("Hans-Peter", "Arsch", DateTime.Parse("26.05.1989"), KundenLevel.Potentiell, "Test 1", "20539", "Hamburg", "Deutschland");
            IHes.erstelleKunden("MamaUndPapa", "hattenMichNichtLieb", DateTime.Parse("26.05.1989"), KundenLevel.Regulaer, "Test 1", "20539", "Hamburg", "Deutschland");

            var kunde0 = IHes.getKundeByKundenNr(new KundenNrTyp("0"));
            var kunde1 = IHes.getKundenByName("Buskulic").ElementAt(0);
            var kunde2 = IHes.getKundenByName("Hans-Peter").ElementAt(0);

            #endregion

            #region Erfolgszenario

            Console.WriteLine("HighOrder Kunde " + kunde0.name + " aus " + kunde0.ort + ",\n" + "möchte ein Angebot für 500 Laptops und 2000 Festplatten");
            Console.WriteLine("\n...Erstelle Angebot für Kunde: " + kunde0.name + " KD_NR: " + kunde0.kundenNr.value);
            produkteFuerAngbeot = new Dictionary<ProduktNummerTyp, int>();
            produkteFuerAngbeot.Add(prodFestplatte, 2000);
            produkteFuerAngbeot.Add(prodLaptop, 500);
            var angebot_neu = IHes.erstelleAngebot(DateTime.Now, DateTime.Parse("01.07.2013"), 0.0, kunde0, produkteFuerAngbeot);

            Console.WriteLine("Angebot erstellt:\n" + angebot_neu);
            Console.WriteLine("\nKunde akzeptiert das Angbeot...\n...Auftrag erstellen:");

            var auftrag_neu = IHes.erstelleAuftrag(angebot_neu, false, DateTime.Now);

            Console.WriteLine("\nAuftrag erstellt: \n" + IHes.holeAuftrag(auftrag_neu));
            //Verändert nichts am Lager da wir davon ausgehen das alles immer auf Lager liegt! (A2)
            var warenausgangsMeldungLaptops = IHes.erstelleWarenausgang(IHes.getProdukt(prodLaptop), 500);
            var warenausgangsMeldungFestplatte = IHes.erstelleWarenausgang(IHes.getProdukt(prodFestplatte), 2000);

            Console.WriteLine("\n...Warenausgänge erstellt: " + warenausgangsMeldungLaptops.mNummer + "\n" + warenausgangsMeldungFestplatte);
            Console.WriteLine("\n...Erstelle Transportauftrag: ");

            var transportAuftrag = IHes.erstelleTransportauftrag(new LiefernummerTyp("LN_1"), DateTime.Parse("25.05.2013"), true, DateTime.Parse("25.05.2013"), "FEDEX", auftrag_neu);

            Console.WriteLine("Transportauftrag erstellt: " + IHes.getTransportAuftrag(transportAuftrag));

            var rechnung_1 = IHes.erstelleRechnung(IHes.holeAuftrag(auftrag_neu));

            var r = IHes.getRechnung(rechnung_1);

            Console.WriteLine("\nRechnung erstellt:\n" + r);

            string _input = "";
            do
            {
                _input = Console.ReadLine();

                Console.WriteLine(IHes.getRechnung(rechnung_1));
                Console.WriteLine();

            }
            while (_input.ToLower() != "exit");

            #endregion
 
        }

        public static void Main(string[] args)
        {
            SimpleClient client = new SimpleClient();
            Console.ReadKey();

        }
    }
}

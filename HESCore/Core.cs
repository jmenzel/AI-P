using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Kunde;
using HES.Kunde.Repository.Entity;
using HES.Lager;
using HES.Lager.Produkt.Repository.Entity;
using HES.TransportComp.Repository.Entity;
using HES.Core.Persistance;
using NHibernate;
using HES.TransportComp;
using HES.AuftragserfassungComp;

namespace HES.Core
{
    public class Core
    {
        ISessionFactory db;

        //IKunde kunde;
        ILager lager;
        ITransport transport;
        IAuftragserfassung auftragserfassung;
        IKunde kunden;

        public Core()
        {
            db = Database.CreateSessionFactory();

            lager = LagerComp.getLagerComp(db);
            //kunde = KundenComp.getKundenComp();

            //KundeTyp kundeA = kunde.getKundeByKundenNr(new KundenNrTyp("asdpigknwrhg"));
            lager.erstelleProdukt(new ProduktDetailsTyp("Kabel A"));
            lager.erstelleProdukt(new ProduktDetailsTyp("Kabel B"));
            lager.erstelleProdukt(new ProduktDetailsTyp("Kabel C"));
            
            foreach (var prod in lager.getProdukte())
            {
                Console.WriteLine(prod.prodNr + " - " + prod.name);
            }

            //----------------------------------------------------------------
            transport = TransportKomp.getTransportKomp(db);
            transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");
            transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");
            transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");

            foreach (var trans in transport.getTransportauftraege())
            {
                Console.WriteLine(trans.nr.nr + " - " + trans.transportDienstleister + " - " + trans.lieferDatum);
            }
            //-------------------------------------------------------------------
            kunden = KundenKomp.getKundenComp(db);

            kunden.erstelleKunden("Buskulic", "Dino", DateTime.Parse("26.05.1989"), KundenLevel.HighOrder, "Test 1", "20539", "Hamburg", "Deutschland");
            kunden.erstelleKunden("Hans-Peter", "Arsch", DateTime.Parse("26.05.1989"), KundenLevel.Potentiell, "Test 1", "20539", "Hamburg", "Deutschland");
            kunden.erstelleKunden("MamaUndPapa", "hattenMichNichtLieb", DateTime.Parse("26.05.1989"), KundenLevel.Regulaer, "Test 1", "20539", "Hamburg", "Deutschland");

            var kunde0 = kunden.getKundeByKundenNr(new KundenNrTyp("0"));
            var kunde1 = kunden.getKundenByName("Buskulic").ElementAt(0);
            var kunde2 = kunden.getKundenByName("Hans-Peter").ElementAt(0);


            //-------------------------------------------------------------------
            auftragserfassung = AuftragserfassungKomp.getAuftragskomponenteComp(db);
            var angebotNr1 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 388.34, kunde1);
            var angebotNr2 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 9978.9872394, kunde1);
            var angebotNr3 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 923939.12, kunde2);

            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr1)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde1.kundenNr).name);
            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr2)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde1.kundenNr).name);
            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr3)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde2.kundenNr).name);
    
        }
    }
}

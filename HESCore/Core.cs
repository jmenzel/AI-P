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
using RechnungComp;

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
        IRechnung rechnung;

        public Core()
        {
            #region Komponenten erstellen
            db = Database.CreateSessionFactory();

            lager = LagerComp.getLagerComp(db);
            kunden = KundenKomp.getKundenComp(db);
            auftragserfassung = AuftragserfassungKomp.getAuftragskomponenteComp(db);
            transport = TransportKomp.getTransportKomp(db);
            rechnung = RechnungKomp.getRechnungKomp(db);
            #endregion

            #region Komponenten initialisieren
            
            var prodLaptop = lager.erstelleProdukt(new ProduktDetailsTyp("Laptop X750"));
            var prodFestplatte = lager.erstelleProdukt(new ProduktDetailsTyp("Festplatte Toshiba J200"));
            var prodKabel = lager.erstelleProdukt(new ProduktDetailsTyp("Kabel HDMI"));
            IDictionary<ProduktNummerTyp,int> produkteFuerAngbeot;
            //foreach (var prod in lager.getProdukte())
            //{
            //    Console.WriteLine(prod.prodNr + " - " + prod.name);
            //}

            //----------------------------------------------------------------
            //transport = TransportKomp.getTransportKomp(db);
            //transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");
            //transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");
            //transport.erstelleTransportauftrag(new LiefernummerTyp(""), DateTime.Now, true, DateTime.Now, "Dienstleister 1");

            //foreach (var trans in transport.getTransportauftraege())
            //{
            //    Console.WriteLine(trans.nr.nr + " - " + trans.transportDienstleister + " - " + trans.lieferDatum);
            //}
            //-------------------------------------------------------------------

            kunden.erstelleKunden("Buskulic", "Dino", DateTime.Parse("26.05.1989"), KundenLevel.HighOrder, "Test 1", "20539", "Hamburg", "Deutschland");
            kunden.erstelleKunden("Hans-Peter", "Arsch", DateTime.Parse("26.05.1989"), KundenLevel.Potentiell, "Test 1", "20539", "Hamburg", "Deutschland");
            kunden.erstelleKunden("MamaUndPapa", "hattenMichNichtLieb", DateTime.Parse("26.05.1989"), KundenLevel.Regulaer, "Test 1", "20539", "Hamburg", "Deutschland");

            var kunde0 = kunden.getKundeByKundenNr(new KundenNrTyp("0"));
            var kunde1 = kunden.getKundenByName("Buskulic").ElementAt(0);
            var kunde2 = kunden.getKundenByName("Hans-Peter").ElementAt(0);


            //-------------------------------------------------------------------
            //var angebotNr1 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 388.34, kunde1,);
            //var angebotNr2 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 9978.9872394, kunde1);
            //var angebotNr3 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 923939.12, kunde2);

            //Console.WriteLine(auftragserfassung.holeAngebot((angebotNr1)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde1.kundenNr).name);
            //Console.WriteLine(auftragserfassung.holeAngebot((angebotNr2)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde1.kundenNr).name);
            //Console.WriteLine(auftragserfassung.holeAngebot((angebotNr3)).nr.nr + " - zu Kunden: " + kunden.getKundeByKundenNr(kunde2.kundenNr).name);
            #endregion

            #region Erfolgszenario

            Console.WriteLine("HighOrder Kunde " + kunde0.name + " aus " + kunde0.ort + ",\n" + "möchte ein Angebot für 500 Laptops und 2000 Festplatten");
            Console.WriteLine("\n...Erstelle Angebot für Kunde: " + kunde0.name + " KD_NR: " + kunde0.kundenNr.value);
            produkteFuerAngbeot = new Dictionary<ProduktNummerTyp, int>();
            produkteFuerAngbeot.Add(prodFestplatte, 2000);
            produkteFuerAngbeot.Add(prodLaptop, 500);
            var angebot_neu = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Parse("01.07.2013"), 0.0, kunde0, produkteFuerAngbeot);

            Console.WriteLine("Angebot erstellt:\n" + angebot_neu);
            Console.WriteLine("\nKunde akzeptiert das Angbeot...\n...Auftrag erstellen:");

            var auftrag_neu = auftragserfassung.erstelleAuftrag(angebot_neu, false, DateTime.Now);

            Console.WriteLine("\nAuftrag erstellt: \n" + auftragserfassung.holeAuftrag(auftrag_neu));
            //Verändert nichts am Lager da wir davon ausgehen das alles immer auf Lager liegt! (A2)
            var warenausgangsMeldungLaptops = lager.erstelleWarenausgang(lager.getProdukt(prodLaptop), 500);
            var warenausgangsMeldungFestplatte = lager.erstelleWarenausgang(lager.getProdukt(prodFestplatte), 2000);

            Console.WriteLine("\n...Warenausgänge erstellt: " + warenausgangsMeldungLaptops + "\n" + warenausgangsMeldungFestplatte);
            Console.WriteLine("\n...Erstelle Transportauftrag: ");

            var transportAuftrag = transport.erstelleTransportauftrag(new LiefernummerTyp("LN_1"), DateTime.Parse("25.05.2013"), true, DateTime.Parse("25.05.2013"), "FEDEX",auftrag_neu);

            Console.WriteLine("Transportauftrag erstellt: " + transport.getTransportAuftrag(transportAuftrag));
            
            var rechnung_1 = rechnung.erstelleRechnung(auftragserfassung.holeAuftrag(auftrag_neu));
            Console.WriteLine("\nRechnung erstellt:\n" + rechnung.getRechnung(rechnung_1));

            #endregion
        }
    }
}

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
            auftragserfassung = AuftragserfassungKomp.getAuftragskomponenteComp(db);
            var angebotNr1 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 388.34, new KundenNrTyp("blah"));
            var angebotNr2 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 9978.9872394, new KundenNrTyp("blah"));
            var angebotNr3 = auftragserfassung.erstelleAngebot(DateTime.Now, DateTime.Now, 923939.12, new KundenNrTyp("blah"));

            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr1)));
            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr2)));
            Console.WriteLine(auftragserfassung.holeAngebot((angebotNr3)));
    
        }
    }
}

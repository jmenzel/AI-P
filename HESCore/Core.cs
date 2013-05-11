using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Kunde;
using HES.Kunde.Repository.Entity;
using HES.Lager;
using HES.Lager.Produkt.Repository.Entity;
using HES.Core.Persistance;
using NHibernate;

namespace HES.Core
{
    public class Core
    {
        ISessionFactory db;

        //IKunde kunde;
        ILager lager;

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
        }
    }
}

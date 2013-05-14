using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Produkt.Repository.Entity;
using NHibernate.Criterion;
using HES.Lager.Repository.Entity;

namespace HES.Lager.Produkt.Repository
{
    class ProduktRepo : ICompProdukt
    {
        string te = "A_";

        public ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod)
        {
            ProduktDetails pd = new ProduktDetails(new ProduktNummerTyp(te += "A"), prod.name);

            //TODO Prüfen ob Produktnummer vergeben
            //Wenn nicht, eine erstellen (vorm speichern)

            using (var session = LagerComp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(pd.asTyp());
                transaction.Commit();
            }

            return pd.prodNr;
        }

        public ProduktDetailsTyp[] getProdukte()
        {
            using (var session = LagerComp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(ProduktDetailsTyp)).List<ProduktDetailsTyp>().ToArray();
            }
        }


        public ProduktDetailsTyp getProdukt(ProduktNummerTyp prodNr)
        {
            using (var session = LagerComp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(ProduktDetailsTyp)).Add(Restrictions.Like("prodNr", prodNr)).List<ProduktDetailsTyp>().ElementAt(0);
            }
        }

        //NOT IMPLEMENTED da Produkte immer auf Lager
        public MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl)
        {
            //TODO, prüfe ob Produkte auf Lager sind und erstelle dann einen Warenausgang
            return new MeldungsNummerTyp("_");
        }
    }
}

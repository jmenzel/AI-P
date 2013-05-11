using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Produkt.Repository.Entity;

namespace HES.Lager.Produkt.Repository
{
    class ProduktRepo : ICompProdukt
    {
        string te = "";

        public string erstelleProdukt(ProduktDetailsTyp prod)
        {
            //ProduktDetails pd = ProduktDetails.fromTyp(prod);

            ProduktDetails pd = new ProduktDetails(te += "A", prod.name);

            //TODO Prüfen ob Produktnummer vergeben
            //Wenn nicht, eine erstellen (vorm speichern)

            using (var session = LagerComp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(pd.asTyp());
                transaction.Commit();
            }

            return prod.prodNr;
        }

        public ProduktDetailsTyp[] getProdukte()
        {
            using (var session = LagerComp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(ProduktDetailsTyp)).List<ProduktDetailsTyp>().ToArray();
            }
        }
    }
}

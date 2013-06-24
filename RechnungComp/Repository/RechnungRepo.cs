using HES.AuftragserfassungComp.Repository.Entity;
using NHibernate.Criterion;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository
{
    class RechnungRepo : IRechnung
    {
        public RechnungRepo() { }

        public RechnungsNrTyp erstelleRechnung(AuftragTyp auftrag)
        {
            using (var session = RechnungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var maxID = session.CreateCriteria(typeof(RechnungsTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                var nr = new RechnungsNrTyp(maxID != null ? Convert.ToString(maxID) : "0");
                RechnungsTyp rechnung = new RechnungsTyp(nr, auftrag, DateTime.Now, false);
                rechnung.setStatus(RechnungStatus.OFFEN);

                session.SaveOrUpdate(rechnung);
                transaction.Commit();

                return nr;
            }
        }


        public RechnungsTyp getRechnung(RechnungsNrTyp nr)
        {
            using (var session = RechnungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var ret = session.CreateCriteria(typeof(RechnungsTyp)).Add(Restrictions.Eq("nr", nr)).UniqueResult<RechnungsTyp>();
                Console.WriteLine("Got a -> " + ret.ToString());
                return ret;
            } 

        }


        public IList<ZahlungseingangTyp> getZahlungseingaenge(RechnungsNrTyp rnr)
        {
            using (var session = RechnungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(ZahlungseingangTyp)).Add(Restrictions.Like("zuRechnungsNr", rnr)).List<ZahlungseingangTyp>();
            } 
        }

        public void setRechnungStatus(RechnungsNrTyp nr, RechnungStatus status)
        {
            RechnungsTyp rechnung = getRechnung(nr);

            using (var session = RechnungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                rechnung.setStatus(status);
                session.Update(rechnung);
                transaction.Commit();
            } 
        }


        public void setRechnungStatus(string nr, RechnungStatus status)
        {
            throw new NotImplementedException();
        }


        public bool zahlungseingangBuchen(double betrag, String nr)
        {
            RechnungsNrTyp rnr = new RechnungsNrTyp(nr);

            using (var session = RechnungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(new ZahlungseingangTyp(rnr, betrag));
                transaction.Commit();

                return true;
            }
            //return false;
        }
    }
}

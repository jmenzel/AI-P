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
            
                session.SaveOrUpdate(new RechnungsTyp(nr,auftrag, DateTime.Now, false));
                transaction.Commit();

                return nr;
            }
        }
    }
}

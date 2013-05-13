using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using NHibernate.Criterion;

namespace HES.AuftragserfassungComp.Repository
{
    class AuftragserfassungRepo : IAuftragserfassung
    {
        public AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundenNrTyp kunde)
        {
            AngebotNrTyp angebotNr;

            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                //Holt sich die letzte ID aus der Tabele und erstellt die nächste TransportNummer
                //Allerdings nicht so schön weil man nicht sicher stellen kann das es auch wirklich die Max ID ist - auf jeden Fall nicht ThreadSicher!
                var maxID = session.CreateCriteria(typeof(AngebotTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                angebotNr = new AngebotNrTyp(maxID != null ? Convert.ToString(maxID) : "0");

                AngebotTyp angebot = new AngebotTyp(angebotNr, gueltigAb, gueltigBis, preis, kunde);
                session.SaveOrUpdate(angebot);
                transaction.Commit();
            }

            return angebotNr;
        }

        public AngebotTyp holeAngebot(AngebotNrTyp nr)
        {   
            //Was wenn die Query fehl schlägt??? Bzw. CastException??
            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var  retValue = session.CreateCriteria(typeof(AngebotTyp)).Add(Restrictions.Like("nr", nr));
                return (AngebotTyp)retValue;
            }   
        }


        //GEHT NICHT WEIL KUNDEN NOCH ERSTELLT WERDEN MÜSSEN!!! PENIS PENIS PENIS
        public AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr,bool istAbgeschlosse, DateTime erstelltAm)
        {
            AuftragNrTyp auftragNr;

            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                //Holt sich die letzte ID aus der Tabele und erstellt die nächste Nummer
                //Allerdings nicht so schön weil man nicht sicher stellen kann das es auch wirklich die Max ID ist - auf jeden Fall nicht ThreadSicher!
                var maxID = session.CreateCriteria(typeof(AuftragTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                auftragNr = new AuftragNrTyp(maxID != null ? Convert.ToString(maxID) : "0");

                AuftragTyp auftrag = new AuftragTyp(auftragNr, nr, istAbgeschlosse, erstelltAm);
                session.SaveOrUpdate(auftrag);
                transaction.Commit();
            }

            return auftragNr;
        }

        //TODO
        public void markiereAuftrag(AuftragNrTyp auftrag, AuftragStatusTyp status)
        {
            throw new NotImplementedException();
        }

        
    }
}

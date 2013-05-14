using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using NHibernate.Criterion;
using HES.Lager.Repository.Entity;

namespace HES.AuftragserfassungComp.Repository
{
    class AuftragserfassungRepo : IAuftragserfassungIntern
    {
        /// <summary>
        /// Speichert ein neues Angebot in der Datenbank
        /// </summary>
        /// <param name="gueltigAb"></param>
        /// <param name="gueltigBis"></param>
        /// <param name="preis"></param>
        /// <param name="kundeNr">ForeignKey Beziehung auf einen Kunden</param>
        /// <returns>NULL if SaveOrUpdate Fails else AngebotNrTyp for der persistent AngebotTyp</returns>
        public AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kunde)
        {
            AngebotNrTyp angebotNr = null;

            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {

                try
                {
                    //Holt sich die letzte ID aus der Tabele und erstellt die nächste TransportNummer
                    //Allerdings nicht so schön weil man nicht sicher stellen kann das es auch wirklich die Max ID ist - auf jeden Fall nicht ThreadSicher!
                    var maxID = session.CreateCriteria(typeof(AngebotTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                    angebotNr = new AngebotNrTyp(maxID != null ? Convert.ToString(maxID) : "0");

                    AngebotTyp angebot = new AngebotTyp(angebotNr, gueltigAb, gueltigBis, preis, kunde);
                    session.SaveOrUpdate(angebot);
                    transaction.Commit();
                }


                catch (NHibernate.Exceptions.GenericADOException ex)
                {
                    Console.WriteLine("ADOException persisting new Angebot!" + ex);
                }
            }
                return angebotNr;
        }

        public AngebotTyp holeAngebot(AngebotNrTyp nr)
        {   
            //Was wenn die Query fehl schlägt??? Bzw. CastException??
            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(AngebotTyp)).Add(Restrictions.Like("nr", nr)).List<AngebotTyp>().ElementAt(0);
            }   
        }


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




        public AuftragTyp holeAuftrag(AuftragNrTyp auftragNr)
        {
            using (var session = AuftragserfassungKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
            var x =  session.CreateCriteria(typeof(AuftragTyp)).Add(Restrictions.Like("nr", auftragNr)).List<AuftragTyp>().ElementAt(0);
                return x;
            } 
        }
    }
}

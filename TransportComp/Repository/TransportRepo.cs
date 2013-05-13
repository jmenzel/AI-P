using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;
using NHibernate.Criterion;

namespace HES.TransportComp.Repository
{
    class TransportRepo : ITransport
    {
        public TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister)
        {
            TransportauftragNrTyp transNr;

            using (var session = TransportKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                //Holt sich die letzte ID aus der Tabele und erstellt die nächste TransportNummer
                //Allerdings nicht so schön weil man nicht sicher stellen kann das es auch wirklich die Max ID ist - auf jeden Fall nicht ThreadSicher!
                var maxID = session.CreateCriteria(typeof(TransportauftragTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                transNr = new TransportauftragNrTyp(maxID != null ? Convert.ToString(maxID) : "0");

                TransportauftragTyp transportauftrag = new TransportauftragTyp(liefernummer,  transNr, ausgangsDatum, lieferungErfolgt, lieferDatum, transportDienstleister);

                session.SaveOrUpdate(transportauftrag);
                transaction.Commit();
            }

            return transNr;

        }

        public TransportauftragTyp[] getTransportauftraege()
        {
            using (var session = TransportKomp.getDB().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(TransportauftragTyp)).List<TransportauftragTyp>().ToArray();
            }
        }

        public LiefernummerTyp erstelleLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }

        public void markiereLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }
    }
}

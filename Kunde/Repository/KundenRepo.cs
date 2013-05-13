using HES.Kunde.Repository.Entity;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository
{
    class KundenRepo : IKunde
    {

        public KundenNrTyp erstelleKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strasse, String plz, string ort, string land)
        {
            KundenNrTyp kundenNr;

            using (var session = KundenKomp.getDb().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                //Holt sich die letzte ID aus der Tabele und erstellt die nächste Nummer
                //Allerdings nicht so schön weil man nicht sicher stellen kann das es auch wirklich die Max ID ist - auf jeden Fall nicht ThreadSicher!
                var maxID = session.CreateCriteria(typeof(KundeTyp)).SetProjection(Projections.Max("ID")).UniqueResult();
                kundenNr = new KundenNrTyp(maxID != null ? Convert.ToString(maxID) : "0");

                KundeTyp kunde = new KundeTyp(kundenNr, level, vorname, nachname, geburtsdatum, strasse, ort, plz, land);
                session.SaveOrUpdate(kunde);
                transaction.Commit();
            }

            return kundenNr;
        }

        public bool loescheKunden(KundenNrTyp nr)
        {
            //Wahrscheinlich garnicht nötig..?
            try
            {
                using (var session = KundenKomp.getDb().OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    //Musst rollback the Error??
                    session.Delete("from KundeTyp kunde where kunde.kundenNr = nr", nr, NHibernate.NHibernateUtil.AnsiString);
                    transaction.Commit();
                    return true;
                }

            }
            catch
            {
                return false;
            }

        }

        public bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land)
        {
            throw new NotImplementedException();
        }

        public IList<KundeTyp> getKundenByName(string name)
        {
            using (var session = KundenKomp.getDb().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria<KundeTyp>().Add(Restrictions.Like("name", name)).List<KundeTyp>();
            }
        }


        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            using (var session = KundenKomp.getDb().OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.CreateCriteria(typeof(KundeTyp)).Add(Restrictions.Like("kundenNr",nr)).List<KundeTyp>().ElementAt(0);
            }
        }

        public bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land)
        {
            throw new NotImplementedException();
        }
    }
}

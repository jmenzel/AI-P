using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository
{
    class KundenRepo
    {

        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            throw new NotImplementedException();
        }


        public KundenNrTyp createKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land)
        {
            throw new NotImplementedException();
        }

        public bool deleteKunde(KundenNrTyp nr)
        {
            throw new NotImplementedException();
        }

        public bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land)
        {
            throw new NotImplementedException();
        }

        public IList<KundeTyp> getKundenByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

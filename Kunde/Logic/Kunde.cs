using HES.Kunde.Repository;
using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Logic
{
    class Kunde : IKunde
    {
        KundenRepo repo = new KundenRepo();

        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            return repo.getKundeByKundenNr(nr);
        }


        public KundenNrTyp createKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land)
        {
            return repo.createKunden(nachname, vorname, geburtsdatum, level, strase, plz, ort, land);
        }

        public bool deleteKunde(KundenNrTyp nr)
        {
            return repo.deleteKunde(nr);
        }

        public bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land)
        {
            return repo.updateKunde(nr, nachname, vorname, geburtsdatum, level, strase, plz, ort, land);
        }

        public IList<KundeTyp> getKundenByName(string name)
        {
            return repo.getKundenByName(name);
        }
    }
}

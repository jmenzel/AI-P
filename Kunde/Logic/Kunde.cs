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


        public KundenNrTyp erstelleKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land)
        {
            return repo.erstelleKunden(nachname, vorname, geburtsdatum, level, strase, plz, ort, land);
        }

        public bool loescheKunden(KundenNrTyp nr)
        {
            return repo.loescheKunden(nr);
        }


        public IList<KundeTyp> getKundenByName(string name)
        {
            return repo.getKundenByName(name);
        }


        public bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strasse, string plz, string ort, string land)
        {
            return repo.updateKunde(nr, nachname, vorname, geburtsdatum, level, strasse, plz, ort, land);
        }
    }
}

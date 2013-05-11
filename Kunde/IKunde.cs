using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde
{
    public interface IKunde
    {
        KundeTyp getKundeByKundenNr(KundenNrTyp nr);
        KundenNrTyp createKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land);
        bool deleteKunde(KundenNrTyp nr);
        bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, int plz, string ort, string land);
        IList<KundeTyp> getKundenByName(string name);
    }
}

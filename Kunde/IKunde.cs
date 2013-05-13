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
        KundenNrTyp erstelleKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land);
        bool loescheKunden(KundenNrTyp nr);
        bool updateKunde(KundenNrTyp nr, string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land);
        IList<KundeTyp> getKundenByName(string name);
    }
}

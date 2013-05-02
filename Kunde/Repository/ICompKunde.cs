using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository
{
    interface ICompKunde
    {
        KundeTyp getKundeByKundenNr(KundenNrTyp nr);
        KundenNrTyp createKunden(); // TODO: Felder hinzufügen
        bool deleteKunde();
        bool updateKunde(); // TODO: Felder hinzufügen
        IList<KundeTyp> getKundenByName(string name);
    }
}

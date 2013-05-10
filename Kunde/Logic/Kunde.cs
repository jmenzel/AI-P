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
        ICompKunde repo = new KundenRepo();

        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            return repo.getKundeByKundenNr(nr);
        }
    }
}

using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository
{
    class KundenRepo : ICompKunde
    {

        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            Entity.Kunde _tmp = null;

            return _tmp.asKundeTyp();
        }


        public KundenNrTyp createKunden()
        {
            throw new NotImplementedException();
        }

        public bool deleteKunde()
        {
            throw new NotImplementedException();
        }

        public bool updateKunde()
        {
            throw new NotImplementedException();
        }

        public IList<KundeTyp> getKundenByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

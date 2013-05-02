using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Kunde;
using HES.Kunde.Repository.Entity;


namespace HESCore
{
    public class Class1
    {
        IKunde kunde = KundenComp.getKundenComp();

        public Class1()
        {
            KundeTyp kundeA = kunde.getKundeByKundenNr(new KundenNrTyp("asdpigknwrhg"));

        }
    }
}

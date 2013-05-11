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
        
    }
}

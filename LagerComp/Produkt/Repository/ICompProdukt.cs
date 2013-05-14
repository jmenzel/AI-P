using HES.Lager.Produkt.Repository.Entity;
using HES.Lager.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Produkt.Repository
{
    interface ICompProdukt
    {
        ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod);
        ProduktDetailsTyp[] getProdukte();
        ProduktDetailsTyp getProdukt(ProduktNummerTyp prodNr);
        MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl);
        
    }
}

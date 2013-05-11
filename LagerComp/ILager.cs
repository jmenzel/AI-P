using HES.Lager.Produkt.Repository.Entity;
using HES.Lager.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager
{
    public interface ILager
    {
        MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl);
        MeldungsNummerTyp erstelleWareneingang(ProduktDetailsTyp prod, int Anzahl, object lieferSchein);
        bool pruefeLagerbestand(ProduktNummerTyp prod, int Anzahl);
        ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod);
        ProduktDetailsTyp[] getProdukte();
    }
}

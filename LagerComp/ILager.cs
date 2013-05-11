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
        string erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl);
        string erstelleWareneingang(ProduktDetailsTyp prod, int Anzahl, object lieferSchein);
        bool pruefeLagerbestand(ProduktDetailsTyp prod, int Anzahl);
        string erstelleProdukt(ProduktDetailsTyp prod);
        ProduktDetailsTyp[] getProdukte();
    }
}

using LagerComp.Produkt.Repository.Entity;
using LagerComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerComp
{
    public interface ILager
    {
        MeldungsNummerTyp erstelleWarenausgang(ProduktNummerTyp prod, int Anzahl);
        MeldungsNummerTyp erstelleWareneingang(ProduktNummerTyp prod, int Anzahl);
        bool pruefeLagerbestand(ProduktNummerTyp prod, int Anzahl);
        ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod);
    }
}

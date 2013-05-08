using EinkaufComp.Lieferant.Repository.Entity;
using LagerComp.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinkaufComp
{
    public interface IEinkauf
    {
        void bestelleProdukt(ProduktNummerTyp prod, LieferantNummerTyp lieferant, int Anzahl);
        void addProduktVerfuegbarCallback(ProduktNummerTyp prod, Callbacks.ProduktVerfuegbar cb);

    }
}

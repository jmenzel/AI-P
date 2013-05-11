using HES.Lager.Produkt.Repository.Entity;
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
    }
}

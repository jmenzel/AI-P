using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Produkt.Repository.Entity
{
    public class ProduktNummerTyp
    {
        public string prodNr { get; private set; }

        public ProduktNummerTyp(string nr)
        {
            this.prodNr = nr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Produkt.Repository.Entity
{
    class ProduktDetails : ProduktDetailsTyp
    {
        public ProduktDetails(string name)
            : base(name)
        {

        }

        public ProduktDetails(ProduktNummerTyp prodNr, string name)
            : base(prodNr, name)
        {

        }

        public static ProduktDetails fromTyp(ProduktDetailsTyp typ)
        {
            return new ProduktDetails(typ.prodNr, typ.name);
        }
    }
}

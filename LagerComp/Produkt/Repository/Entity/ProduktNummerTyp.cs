using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Produkt.Repository.Entity
{
    public class ProduktNummerTyp
    {
        public virtual string prodNr { get; protected set; }

        public ProduktNummerTyp(string nr)
        {
            this.prodNr = nr;
        }

        protected ProduktNummerTyp()
        { }

        public override string ToString()
        {
            return prodNr;
        }
    }
}

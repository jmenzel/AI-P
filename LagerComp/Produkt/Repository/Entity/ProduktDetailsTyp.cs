using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Produkt.Repository.Entity
{
    public class ProduktDetailsTyp
    {
        public virtual string prodNr { get; protected set; }
        public virtual string name { get; protected set; }

        protected ProduktDetailsTyp()
        {
            prodNr = "";
            name = "";
        }

        public ProduktDetailsTyp(string name)
        {
            this.name = name;
        }

        public ProduktDetailsTyp(string nr, string name)
        {
            this.prodNr = nr;
            this.name = name;
        }

        public virtual ProduktDetailsTyp asTyp()
        {
            return new ProduktDetailsTyp(this.prodNr, this.name);
        }
    }
}

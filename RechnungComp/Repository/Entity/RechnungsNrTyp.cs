using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    public class RechnungsNrTyp
    {
        public virtual string rNr { get; protected set; }

        public RechnungsNrTyp(string nr)
        {
            this.rNr = nr;
        }

        protected RechnungsNrTyp() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    public class RechnungsNrTyp
    {
        private readonly String contraction = "RB_";
        public virtual string rNr { get; protected set; }

        public RechnungsNrTyp(string nr)
        {
            this.rNr = contraction + nr;
        }

        protected RechnungsNrTyp() { }

        public override string ToString()
        {
            return "Nr: " + rNr;
        }
    }
}

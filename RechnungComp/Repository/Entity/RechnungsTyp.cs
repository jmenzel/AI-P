using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    public class RechnungsTyp
    {
        public virtual int ID { get; protected set; }
        public virtual RechnungsNrTyp nr { get; protected set; }
        public virtual DateTime RechnungsDatum { get; protected set; }
        public virtual bool IstBezahlt { get; protected set; }

        public RechnungsTyp(RechnungsNrTyp rNr, DateTime datum, bool istBezahlt)
        {
            this.nr = rNr;
            this.RechnungsDatum = datum;
            this.IstBezahlt = istBezahlt;
        }

        protected RechnungsTyp() { }
    }
}

using HES.AuftragserfassungComp.Repository.Entity;
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
        public virtual AuftragTyp fuerAuftrag { get; protected set; }

        public RechnungsTyp(RechnungsNrTyp rNr,AuftragTyp fuerAuftrag, DateTime datum, bool istBezahlt)
        {
            this.nr = rNr;
            this.RechnungsDatum = datum;
            this.IstBezahlt = istBezahlt;
            this.fuerAuftrag = fuerAuftrag;
        }

        protected RechnungsTyp() { }

        public override string ToString()
        {
            return "Rechnungsnummer: " + nr.ToString()
                + "\nRechnungsDatum: " + RechnungsDatum
                + "\nBezahlt: " + IstBezahlt;
        }
    }
}

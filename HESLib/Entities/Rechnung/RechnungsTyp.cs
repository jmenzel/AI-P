using HES.AuftragserfassungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    [Serializable()]
    public class RechnungsTyp
    {
        public virtual int ID { get; protected set; }
        public virtual RechnungsNrTyp nr { get; protected set; }
        public virtual DateTime RechnungsDatum { get; protected set; }
        public virtual bool IstBezahlt { get; protected set; }
        public virtual AuftragTyp fuerAuftrag { get; protected set; }
        public virtual IList<ZahlungseingangTyp> zahlungseingaenge { get; protected set; }
        public virtual RechnungStatus status { get; protected set; }
        public virtual double preis { get; protected set; }

        public RechnungsTyp(RechnungsNrTyp rNr,AuftragTyp fuerAuftrag, DateTime datum, bool istBezahlt)
        {
            this.nr = rNr;
            this.RechnungsDatum = datum;
            this.IstBezahlt = istBezahlt;
            this.fuerAuftrag = fuerAuftrag;
            this.preis = fuerAuftrag.preis;
            this.zahlungseingaenge = new List<ZahlungseingangTyp>();
        }

        //Könnte man in den Konstruktor setzten..war nur zu faul zum refactoren
        public virtual void setStatus(RechnungStatus status)
        {
            this.status = status;
        }

        protected RechnungsTyp() { }

        public override string ToString()
        {
            return "Rechnungsnummer: " + nr.ToString()
                + "\nRechnungsDatum: " + RechnungsDatum
                + "\nStatus: " + status;
        }
    }
}

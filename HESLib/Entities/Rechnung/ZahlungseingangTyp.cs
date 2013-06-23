using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    [Serializable()]
    public class ZahlungseingangTyp
    {
        public virtual int id { get; protected set; }
        public virtual double betrag { get; protected set; }
        public virtual RechnungsNrTyp zuRechnungsNr { get; protected set; }

        //Hibernate
        protected ZahlungseingangTyp() {}

        public ZahlungseingangTyp(RechnungsNrTyp nr, double Betrag)
        {
            this.betrag = betrag;
            this.zuRechnungsNr = nr;
        }

    }
}

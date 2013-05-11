using HES.Lager.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Repository.Entity
{
    public class MeldungsDetailsTyp
    {
        public virtual int ID { get; protected set; }
        public virtual MeldungsNummerTyp mNr { get; protected set; }
        public virtual ProduktDetailsTyp prod { get; protected set; }
        public virtual DateTime date { get; protected set; }
        public virtual int menge { get; protected set; }
        public virtual string lieferSchein { get; protected set; }

        public MeldungsDetailsTyp(ProduktDetailsTyp prod, DateTime date, int menge, string lieferSchein)
        {
            this.prod = prod;
            this.date = date;
            this.menge = menge;
            this.lieferSchein = lieferSchein;
        }

        protected MeldungsDetailsTyp() { }
    }
}

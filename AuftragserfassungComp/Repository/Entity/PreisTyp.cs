using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class PreisTyp
    {
        public virtual double preis { get; protected set; }

        public PreisTyp(double preis)
        {
            this.preis = preis;
        }

        protected PreisTyp() { }
    }

}

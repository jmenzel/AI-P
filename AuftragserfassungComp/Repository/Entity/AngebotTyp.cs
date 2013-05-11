using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AngebotTyp
    {
         public virtual int ID { get; protected set; }
         public virtual AngebotNummerTyp nr { get; protected set; }
         public virtual DateTime gueltigAb { get; protected set; }
         public virtual DateTime gueltigBis { get; protected set; }
         public virtual double preis { get; protected set; }

         public AngebotTyp(AngebotNummerTyp nr, DateTime gueltigAb, DateTime gueltigBis, double preis)
         {
             this.nr = nr;
             this.gueltigAb = gueltigAb;
             this.gueltigBis = gueltigBis;
             this.preis = preis;
         }

         protected AngebotTyp() { }
    }
}

using HES.Kunde.Repository.Entity;
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
         public virtual AngebotNrTyp nr { get; protected set; }
         public virtual DateTime gueltigAb { get; protected set; }
         public virtual DateTime gueltigBis { get; protected set; }
         public virtual double preis { get; protected set; }
         public virtual KundenNrTyp fuerKunde { get; protected set; }

         public AngebotTyp(AngebotNrTyp nr, DateTime gueltigAb, DateTime gueltigBis, double preis, KundenNrTyp kunde)
         {
             this.nr = nr;
             this.gueltigAb = gueltigAb;
             this.gueltigBis = gueltigBis;
             this.preis = preis;
             this.fuerKunde = kunde;
         }

         protected AngebotTyp() { }
    }
}

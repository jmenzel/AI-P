using HES.Kunde.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using HES.Lager.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    [Serializable()]
    public class AngebotTyp
    {
         public virtual int ID { get; protected set; }
         public virtual AngebotNrTyp nr { get; protected set; }
         public virtual DateTime gueltigAb { get; protected set; }
         public virtual DateTime gueltigBis { get; protected set; }
         public virtual double gesamtPreis { get; protected set; }
         public virtual KundeTyp kunde { get; protected set; }
         public virtual IDictionary<ProduktNummerTyp, int> produkte { get; protected set; }
        
         public AngebotTyp(AngebotNrTyp nr, DateTime gueltigAb, DateTime gueltigBis, double addPreis, KundeTyp kunde, IDictionary<ProduktNummerTyp, int> prod)
         {
             this.nr = nr;
             this.gueltigAb = gueltigAb;
             this.gueltigBis = gueltigBis;
             this.gesamtPreis = addPreis;
             this.kunde = kunde;
             this.produkte = prod;
         }

         protected AngebotTyp() { }

         public override string ToString()
         {
             return "Angebotnr: " + nr + "\n Gültig ab: " + gueltigAb + "\nGültig bis: " + gueltigBis + "\nPreis: " + gesamtPreis + "\nFür Kunde: " + kunde.ToString(); 
         }
    }
}

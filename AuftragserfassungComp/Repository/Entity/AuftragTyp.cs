using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AuftragTyp
    {
        public virtual int ID { get; protected set; }
        public virtual AuftragNummerTyp nr { get; protected set; }
        //public virtual AuftragStatusTyp status { get; protected set; }
        public virtual AngebotTyp gehoertZuAngebot { get; protected set; }
        public virtual Boolean istAbgeschlossen { get; protected set; }
        public virtual DateTime erstelltAm { get; protected set; }

        public AuftragTyp(AuftragNummerTyp nr, AngebotTyp angebot, bool istAbgeschlossen, DateTime erstelltAm)
        {
            this.nr = nr;
            this.gehoertZuAngebot = angebot;
            this.istAbgeschlossen = istAbgeschlossen;
            this.erstelltAm = erstelltAm;
        }

        protected AuftragTyp() { }
    
    }
}

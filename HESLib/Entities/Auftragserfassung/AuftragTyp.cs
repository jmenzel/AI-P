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
        public virtual AuftragNrTyp nr { get; protected set; }
        public virtual AngebotNrTyp gehoertZuAngebot { get; protected set; }
        public virtual Boolean istAbgeschlossen { get; protected set; }
        public virtual DateTime erstelltAm { get; protected set; }

        public AuftragTyp(AuftragNrTyp nr, AngebotNrTyp angebot, bool istAbgeschlossen, DateTime erstelltAm)
        {
            this.nr = nr;
            this.gehoertZuAngebot = angebot;
            this.istAbgeschlossen = istAbgeschlossen;
            this.erstelltAm = erstelltAm;
        }

        protected AuftragTyp() { }

        public override string ToString()
        {
            return "Auftrag mit Nummer: " + nr.ToString() + " aus Angebot mit Nummer: " + gehoertZuAngebot.ToString()
                + "\nErstellt am: " + erstelltAm
                + "\n Auftrag abgeschlossen: " + istAbgeschlossen;
                
        }
    }
}

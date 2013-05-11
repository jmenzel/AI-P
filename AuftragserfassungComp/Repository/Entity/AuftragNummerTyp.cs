using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AuftragNummerTyp
    {
        public String nr { get; protected set; }

        //TODO: Auftragnummer prüfen und dann erst erstellen!
        public AuftragNummerTyp(String nr)
        {
            this.nr = checkAuftragNummer(nr);
        }

        protected AuftragNummerTyp() { }

        private String checkAuftragNummer(String nr)
        {
            return "";
        }
    }
}

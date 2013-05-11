using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AngebotNummerTyp
    {
        public String nr { get; protected set; }

        public AngebotNummerTyp(String nr)
        {
            this.nr = checkAngebotNummer(nr);
        }

        protected AngebotNummerTyp() { }

        //TODO: Nummer prüfen!
        private String checkAngebotNummer(String nr)
        {
            return "";
        }
    }
}

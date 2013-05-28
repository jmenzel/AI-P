using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    [Serializable()]
    public class AuftragNrTyp
    {
        
        private readonly String contraction = "AF_";
        public virtual String nr { get; protected set; }

        //Nummern werden beim persistieren geprüft!
        public AuftragNrTyp(String nr)
        {
            this.nr = contraction + nr;
        }

        protected AuftragNrTyp() { }

        public override string ToString()
        {
            return "Nr: " + nr;
        }
    }
}

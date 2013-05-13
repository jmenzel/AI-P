using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp.Repository.Entity
{
    public class TransportauftragNummerTyp
    {

        public virtual String nr { get; protected set; }

        public TransportauftragNummerTyp(String nr)
        {
            this.nr = nr;
        }

        protected TransportauftragNummerTyp() { }
    }
}

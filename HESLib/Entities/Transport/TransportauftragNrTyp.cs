using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp.Repository.Entity
{
    [Serializable()]
    public class TransportauftragNrTyp
    {
        private readonly String contraction = "TR_";
        public virtual String nr { get; set; }

        public TransportauftragNrTyp(String nr)
        {
            this.nr = contraction + nr;
        }

        protected TransportauftragNrTyp() { }

        public override string ToString()
        {
            return "Nr: " + nr;
        }
    }
}

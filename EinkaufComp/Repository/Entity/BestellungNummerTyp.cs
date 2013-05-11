using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinkaufComp.Repository.Entity
{
    public class BestellungNummerTyp
    {
        public virtual string nr { get; protected set; }

        public BestellungNummerTyp(string nr)
        {
            this.nr = nr;
        }

        protected BestellungNummerTyp() { }
    }
}

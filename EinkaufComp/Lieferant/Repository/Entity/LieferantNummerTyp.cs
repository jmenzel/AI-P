using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinkaufComp.Lieferant.Repository.Entity
{
    public class LieferantNummerTyp
    {
        public virtual string Nr { get; protected set; }

        public LieferantNummerTyp(string nr)
        {
            this.Nr = nr;
        }

        protected LieferantNummerTyp() { }
    }
}

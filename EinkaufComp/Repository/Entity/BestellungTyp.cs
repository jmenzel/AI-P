using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinkaufComp.Repository.Entity
{
    public class BestellungTyp
    {
        public virtual BestellungNummerTyp nr { get; protected set; }
        public virtual DateTime Bestelldatum { get; protected set; }
        public virtual int Menge { get; protected set; }
        public virtual bool Freigabe { get; protected set; }

        public BestellungTyp(BestellungNummerTyp nr, DateTime datum, int Menge, bool Freigabe)
        {
            this.nr = nr;
            this.Bestelldatum = datum;
            this.Menge = Menge;
            this.Freigabe = Freigabe;
        }

        protected BestellungTyp() { }
    }
}

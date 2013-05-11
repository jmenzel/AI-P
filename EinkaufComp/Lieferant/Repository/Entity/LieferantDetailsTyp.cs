using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EinkaufComp.Lieferant.Repository.Entity
{
    public class LieferantDetailsTyp
    {
        public virtual int ID { get; protected set; }
        public virtual LieferantNummerTyp nr { get; protected set; }
        public virtual string name { get; protected set; }
        public virtual string hausnr { get; protected set; }
        public virtual string strasse { get; protected set; }
        public virtual string ort { get; protected set; }
        public virtual string plz { get; protected set; }
        public virtual string land { get; protected set; }

        public LieferantDetailsTyp(LieferantNummerTyp nr,string name, string hausnr, string strasse, string ort, string plz, string land)
        {
            this.nr = nr;
            this.name = name;
            this.hausnr = hausnr;
            this.strasse = strasse;
            this.ort = ort;
            this.plz = plz;
            this.land = land;
        }

        protected LieferantDetailsTyp() { }
    }
}

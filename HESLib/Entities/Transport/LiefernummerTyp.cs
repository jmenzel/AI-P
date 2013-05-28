using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp.Repository.Entity
{
    public class LiefernummerTyp
    {
        public virtual String nr { get; protected set; }

        //TODO: Nummer validieren!
        public LiefernummerTyp(string nr)
        {
            this.nr = nr;
        }

        protected LiefernummerTyp() { }
    }
}

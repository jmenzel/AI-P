using HES.Lager.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Repository.Entity
{
    [Serializable()]
    public class MeldungsNummerTyp
    {
        public virtual string mNummer { get; protected set; }

        public MeldungsNummerTyp(string nr)
        {
            this.mNummer = nr;
        }

        protected MeldungsNummerTyp() { }
    }
}

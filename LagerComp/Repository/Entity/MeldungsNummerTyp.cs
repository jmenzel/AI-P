using HES.Lager.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager.Repository.Entity
{
    public class MeldungsNummerTyp
    {
        public string mNummer { get; private set; }

        public MeldungsNummerTyp(string nr)
        {
            this.mNummer = nr;
        }
    }
}

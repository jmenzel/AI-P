using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository.Entity
{
    public class KundenNrTyp
    {
        public string value { get; private set;}

        /// <summary>
        /// Repräsentiert eine Kundennr
        // TODO: Vorbedingung bestimmen
        /// </summary>
        /// <param name="nr"></param>
        public KundenNrTyp(string nr)
        {
            this.value = nr;
        }

    }
}

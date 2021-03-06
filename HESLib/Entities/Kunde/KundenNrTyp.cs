﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository.Entity
{
    [Serializable()]
    public class KundenNrTyp
    {
        private readonly String contraction = "KD_";
        public virtual string value { get; protected set;}

        /// <summary>
        /// Repräsentiert eine Kundennr
        // TODO: Vorbedingung bestimmen
        /// </summary>
        /// <param name="nr"></param>
        public KundenNrTyp(string nr)
        {
            this.value = contraction + nr;
        }

        protected KundenNrTyp() { }

    }
}

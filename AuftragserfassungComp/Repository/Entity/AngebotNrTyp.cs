﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AngebotNrTyp
    {
        private readonly String contraction = "AN_";
        public virtual String nr { get; protected set; }

        public AngebotNrTyp(String nr)
        {
            this.nr = contraction + nr;
        }

        protected AngebotNrTyp() { }

    }
}

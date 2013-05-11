﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository.Entity
{
    public class AngebotTyp
    {
         public virtual AngebotNummerTyp nr { get; protected set; }
         public virtual DateTime gueltigAb { get; protected set; }
         public virtual DateTime gueltigBis { get; protected set; }
         public virtual PreisTyp preis { get; protected set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Repository.Entity
{
    [Serializable()]
    public enum RechnungStatus
    {
        OFFEN,
        BEGLICHEN,
        TEIL_BEGLICHEN
    }
}

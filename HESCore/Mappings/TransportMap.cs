using FluentNHibernate.Mapping;
using HES.TransportComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{

    public class TransportNrMap : ClassMap<TransportauftragNrTyp>
    {
        public TransportNrMap()
        {
            Id(x => x.nr);
        }
    }

    public class LieferNrMap : ClassMap<LiefernummerTyp>
    {
        public LieferNrMap()
        {
            Id(x => x.nr);
        }

    }

    public class TransportMap : ClassMap<TransportauftragTyp>
    {
        public TransportMap()
        {
            Id(x => x.ID);
            References(x => x.nr).Cascade.All().Not.LazyLoad();
            Map(x => x.lieferDatum);
            Map(x => x.ausgangsDatum);
            Map(x => x.lieferungErfolg);
            Map(x => x.transportDienstleister);
        }

    }
}

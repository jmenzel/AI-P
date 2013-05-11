using FluentNHibernate.Mapping;
using HES.AuftragserfassungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{

    class AngebotNummerMap : ClassMap<AngebotNummerTyp>
    {
        public AngebotNummerMap()
        {
            Id(x => x.nr);
        }
    }

    class AngebotMap : ClassMap<AngebotTyp>
    {
        public AngebotMap()
        {
            Id(x => x.ID);
            References(x => x.nr).Cascade.All().Not.LazyLoad();
            Map(x => x.gueltigAb);
            Map(x => x.gueltigBis);
            Map(x => x.preis);
        }
    }
}

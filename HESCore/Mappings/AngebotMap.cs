using FluentNHibernate.Mapping;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{

    class AngebotNummerMap : ClassMap<AngebotNrTyp>
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
            Map(x => x.gesamtPreis);
            HasMany(x => x.produkte).AsEntityMap("produknummer_id").Element("count");
            HasOne(x => x.kunde).Constrained().ForeignKey().Not.LazyLoad();
        }
    }
}

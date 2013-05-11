using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Produkt.Repository.Entity;

namespace HES.Core.Mappigns
{
    public class ProduktMap : ClassMap<ProduktDetailsTyp>
    {
        public ProduktMap()
        {
            Id(x => x.ID);
            //HasOne(x => x.prodNr).Cascade.All();
            References(x => x.prodNr).Cascade.All().Not.LazyLoad();
            Map(x => x.name);
        }
    }

    public class ProduktNummerMap : ClassMap<ProduktNummerTyp>
    {
        public ProduktNummerMap()
        {
            Id(x => x.prodNr);
        }
    }
}

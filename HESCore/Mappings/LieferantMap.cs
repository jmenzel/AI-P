using EinkaufComp.Lieferant.Repository.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{
    public class LieferantMap : ClassMap<LieferantDetailsTyp>
    {
        public LieferantMap()
        {
            Id(x => x.ID);
            References(x => x.nr).Cascade.All().Not.LazyLoad();
            Map(x => x.hausnr);
            Map(x => x.land);
            Map(x => x.name);
            Map(x => x.ort);
            Map(x => x.plz);
            Map(x => x.strasse);
        }
    }

    public class LieferantNrMap : ClassMap<LieferantNummerTyp>
    {
        public LieferantNrMap()
        {
            Id(x => x.Nr);
        }
    }
}

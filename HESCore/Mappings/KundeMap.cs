using FluentNHibernate.Mapping;
using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{

    public class KundenNrMapping : ClassMap<KundenNrTyp>
    {
        public KundenNrMapping()
        {
            Id(x => x.value);
        }
    }

    public class KundeMap : ClassMap<KundeTyp>
    {
        public KundeMap()
        {
            Id(x => x.ID);
            References(x => x.kundenNr).Cascade.All().Not.LazyLoad();
            Map(x => x.level);
            Map(x => x.vorname);
            Map(x => x.name);
            Map(x => x.geburtstag);
            Map(x => x.hausnr);
            Map(x => x.strasse);
            Map(x => x.ort);
            Map(x => x.plz);
            Map(x => x.land);
        }
    }
}

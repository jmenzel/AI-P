using FluentNHibernate.Mapping;
using HES.AuftragserfassungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{
    
    public class AuftragsNummerMap : ClassMap<AuftragNrTyp>
    {
        public AuftragsNummerMap()
        {
            Id(x => x.nr);
        }
    }
    
    public class AuftragMap : ClassMap<AuftragTyp>
    {
        public AuftragMap()
        {
            Id(x => x.ID);
            References(x => x.nr).Cascade.All().Not.LazyLoad();
            Map(x => x.istAbgeschlossen);
            Map(x => x.erstelltAm);
        }
    }

}

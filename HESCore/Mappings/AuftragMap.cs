using FluentNHibernate.Mapping;
using HES.AuftragserfassungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{
    public class AuftragsNummerMap : ClassMap<AuftragNummerTyp>
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
            Id(x => x.nr);
            Map(x => x.istAbgeschlossen);
            Map(x => x.erstelltAm);
            Map(x => x.gehoertZuAngebot);
        }
    }

}

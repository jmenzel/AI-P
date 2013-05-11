using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Repository.Entity;

namespace HES.Mappings
{
    public class LagerMap : ClassMap<MeldungsDetailsTyp>
    {
        public LagerMap()
        {
            Id(x => x.ID);
            References(x => x.mNr).Cascade.All().Not.LazyLoad();
            Map(x => x.date);
            Map(x => x.menge);
            Map(x => x.lieferSchein);
            HasOne(x => x.prod).Constrained().ForeignKey();
        }
    }

    public class MeldungsNummerMap : ClassMap<MeldungsNummerTyp>
    {
        public MeldungsNummerMap()
        {
            Id(x => x.mNummer);
        }
    }
}
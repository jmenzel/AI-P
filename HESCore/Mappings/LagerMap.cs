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
            Id(x => x.mNr);
            Map(x => x.date);
            Map(x => x.menge);
            Map(x => x.lieferSchein);
            HasOne(x => x.prod).Constrained().ForeignKey();
        }
    }
}
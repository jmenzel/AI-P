using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stud.Verwaltung.Entities;


namespace Stud.Verwaltung.Mappings
{
    public class NotenKontoMap : ClassMap<NotenKonto>
    {
        public NotenKontoMap()
        {
            Id(x => x.ID);
            Map(x => x.Gesamtnote);
            HasOne(x => x.Stud).Constrained().ForeignKey();
        }
    }
}

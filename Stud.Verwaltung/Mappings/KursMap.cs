using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stud.Verwaltung.Entities;


namespace Stud.Verwaltung.Mappings
{
    public class KursMap : ClassMap<Kurs>
    {
        public KursMap()
        {
            Id(x => x.ID);
            Map(x => x.Title);
            References(x => x.Stud);
            HasManyToMany(x => x.BuchEmpfehlung).Cascade.All().Table("KursBuch");
        }
    }
}

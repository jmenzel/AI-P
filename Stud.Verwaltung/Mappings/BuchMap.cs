using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stud.Verwaltung.Entities;


namespace Stud.Verwaltung.Mappings
{
    public class BuchMap : ClassMap<Buch>
    {
        public BuchMap()
        {
            Id(x => x.ID);
            Map(x => x.Titel);
            HasManyToMany(x => x.EmpfohlenFuer).Cascade.All().Inverse().Table("KursBuch");
        }
    }
}

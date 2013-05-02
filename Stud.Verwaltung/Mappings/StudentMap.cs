using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stud.Verwaltung.Entities;

namespace Stud.Verwaltung.Mappings
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.ID);
            Map(x => x.Name);
            HasMany(x => x.KursListe).Cascade.SaveUpdate();
            HasOne(x => x.NKonto).Cascade.SaveUpdate();
        }
    }
}

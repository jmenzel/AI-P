using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Produkt.Repository.Entity;

namespace HES.Core.Mappigns
{
    public class ProduktMap : ClassMap<ProduktDetailsTyp>
    {
        public ProduktMap()
        {
            Id(x => x.prodNr);
            Map(x => x.name);
        }
    }
}

using FluentNHibernate.Mapping;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{
    class ZahlungseingangTypMap : ClassMap<ZahlungseingangTyp>
    {
        public ZahlungseingangTypMap()
        {
            Id(x => x.id);
            Map(x => x.betrag);
            References<RechnungsTyp>(x => x.zuRechnungsNr);
        }
    }
}

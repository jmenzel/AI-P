using FluentNHibernate.Mapping;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Mappings
{
    public class RechnungsMap : ClassMap<RechnungsTyp>
    {

        public RechnungsMap()
        {
            Id(x => x.ID);
            References(x => x.nr).Cascade.All().Not.LazyLoad();
            Map(x => x.IstBezahlt);
            Map(x => x.RechnungsDatum);
            Map(x => x.status);
            Map(x => x.preis);
            HasOne(x => x.fuerAuftrag).ForeignKey().Not.LazyLoad();
            HasMany(x => x.zahlungseingaenge).Cascade.All().Not.LazyLoad();
        }
    }

    public class RechnungsNrMap : ClassMap<RechnungsNrTyp>
    {
        public RechnungsNrMap()
        {
            Id(x => x.rNr);
        }
    }
}
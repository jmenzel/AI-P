using HES.AuftragserfassungComp.Repository.Entity;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp
{
    public interface IRechnung
    {
        RechnungsNrTyp erstelleRechnung(AuftragTyp auftrag);
        RechnungsTyp getRechnung(RechnungsNrTyp nr);
        Boolean zahlungseingangBuchen(Double betrag, RechnungsNrTyp nr);
        IList<ZahlungseingangTyp> getZahlungseingaenge(RechnungsNrTyp rnr);
        void setRechnungStatus(RechnungsNrTyp nr, RechnungStatus status);
    }
}

using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
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
    }
}

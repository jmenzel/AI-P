using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp
{
    /// <summary>
    /// Schnittstelle für die Auftragserfassung
    /// </summary>
    interface IAuftragserfassung
    {
        AngebotNummerTyp erstelleAngebot(AngebotTyp angebot, KundenNrTyp kunde);
        AngebotTyp holeAngebot(AngebotNummerTyp nr);
        AuftragNummerTyp erstelleAuftrag(AngebotNummerTyp nr);
        void markiereAuftrag(AuftragNummerTyp auftrag, AuftragStatusTyp status);
    }
}

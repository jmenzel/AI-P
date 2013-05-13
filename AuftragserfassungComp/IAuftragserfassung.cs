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
    public interface IAuftragserfassung
    {
        AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kundeNr);
        AngebotTyp holeAngebot(AngebotNrTyp nr);
        AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr,bool istAbgeschlossen, DateTime erstelltAm);
        void markiereAuftrag(AuftragNrTyp auftrag, AuftragStatusTyp status);
    }
}

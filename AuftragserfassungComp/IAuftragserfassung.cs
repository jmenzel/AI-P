using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using HES.Lager.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Lager.Produkt.Repository.Entity;

namespace HES.AuftragserfassungComp
{
    /// <summary>
    /// Schnittstelle für die Auftragserfassung
    /// </summary>
    public interface IAuftragserfassung
    {
        AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kundeNr,IDictionary<ProduktNummerTyp,int> produktListe);
        AngebotTyp holeAngebot(AngebotNrTyp nr);
        AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr,bool istAbgeschlossen, DateTime erstelltAm);
        AuftragTyp holeAuftrag(AuftragNrTyp auftragNr);
        void markiereAuftrag(AuftragNrTyp auftrag, AuftragStatusTyp status);
    }
}

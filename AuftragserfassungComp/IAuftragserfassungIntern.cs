using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp
{
    interface IAuftragserfassungIntern
    {
        AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kundeNr, IDictionary<ProduktNummerTyp, int> prod);
        AngebotTyp holeAngebot(AngebotNrTyp nr);
        AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr, bool istAbgeschlossen, DateTime erstelltAm);
        AuftragTyp holeAuftrag(AuftragNrTyp auftragNr);
        void markiereAuftrag(AuftragNrTyp auftrag, AuftragStatusTyp status);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using HES.AuftragserfassungComp.Repository;

namespace HES.AuftragserfassungComp.Logic
{
    class Auftragserfassung : IAuftragserfassung
    {
        IAuftragserfassung repo = new AuftragserfassungRepo();

        public AngebotNummerTyp erstelleAngebot(AngebotTyp angebot, KundenNrTyp kunde)
        {
            return repo.erstelleAngebot(angebot, kunde);
        }

        public AngebotTyp holeAngebot(AngebotNummerTyp nr)
        {
            return repo.holeAngebot(nr);
        }

        public AuftragNummerTyp erstelleAuftrag(AngebotNummerTyp nr)
        {
            return repo.erstelleAuftrag(nr);
        }

        public void markiereAuftrag(AuftragNummerTyp auftrag, AuftragStatusTyp status)
        {
             repo.markiereAuftrag(auftrag, status);
        }
    }
}

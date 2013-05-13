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

        public Auftragserfassung() { }

        public AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kunde)
        {
            return repo.erstelleAngebot(gueltigAb,gueltigBis,preis,kunde);
        }

        public AngebotTyp holeAngebot(AngebotNrTyp nr)
        {
            return repo.holeAngebot(nr);
        }

        public AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr,bool istAbgeschlosse, DateTime erstelltAm)
        {
            return repo.erstelleAuftrag(nr,istAbgeschlosse,erstelltAm);
        }

        public void markiereAuftrag(AuftragNrTyp auftrag, AuftragStatusTyp status)
        {
             repo.markiereAuftrag(auftrag, status);
        }

    }
}

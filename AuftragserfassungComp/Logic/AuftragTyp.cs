using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Logic
{
    class AuftragTyp : IAuftragserfassung
    {
        public Repository.Entity.AngebotNummerTyp erstelleAngebot(Repository.Entity.AngebotTyp angebot, Kunde.Repository.Entity.KundenNrTyp kunde)
        {
            throw new NotImplementedException();
        }

        public Repository.Entity.AngebotTyp holeAngebot(Repository.Entity.AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public Repository.Entity.AuftragNummerTyp erstelleAuftrag(Repository.Entity.AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public void markiereAuftrag(Repository.Entity.AuftragNummerTyp auftrag, Repository.Entity.AuftragStatusTyp status)
        {
            throw new NotImplementedException();
        }
    }
}

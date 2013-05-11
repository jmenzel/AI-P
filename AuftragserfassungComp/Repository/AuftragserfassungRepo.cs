using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;

namespace HES.AuftragserfassungComp.Repository
{
    class AuftragserfassungRepo : IAuftragserfassung
    {
        public AngebotNummerTyp erstelleAngebot(Entity.AngebotTyp angebot, KundenNrTyp kunde)
        {
            throw new NotImplementedException();
        }

        public AngebotTyp holeAngebot(AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public AuftragNummerTyp erstelleAuftrag(AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public void markiereAuftrag(Entity.AuftragNummerTyp auftrag, Entity.AuftragStatusTyp status)
        {
            throw new NotImplementedException();
        }
    }
}

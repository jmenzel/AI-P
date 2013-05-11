using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.AuftragserfassungComp.Repository
{
    class AuftragserfassungRepo : IAuftragserfassung
    {
        public Entity.AngebotNummerTyp erstelleAngebot(Entity.AngebotTyp angebot, Kunde.Repository.Entity.KundenNrTyp kunde)
        {
            throw new NotImplementedException();
        }

        public Entity.AngebotTyp holeAngebot(Entity.AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public Entity.AuftragNummerTyp erstelleAuftrag(Entity.AngebotNummerTyp nr)
        {
            throw new NotImplementedException();
        }

        public void markiereAuftrag(Entity.AuftragNummerTyp auftrag, Entity.AuftragStatusTyp status)
        {
            throw new NotImplementedException();
        }
    }
}

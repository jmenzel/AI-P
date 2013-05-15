using HES.AuftragserfassungComp.Repository.Entity;
using RechnungComp.Repository;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp.Logic
{
    class Rechnung : IRechnung
    {
        IRechnung rechnungRepo;

        public Rechnung()
        {
            rechnungRepo = new RechnungRepo();
        }


        public RechnungsNrTyp erstelleRechnung(AuftragTyp auftrag)
        {
            return rechnungRepo.erstelleRechnung(auftrag);
        }


        public RechnungsTyp getRechnung(RechnungsNrTyp nr)
        {
            return rechnungRepo.getRechnung(nr);
        }
    }
}

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


        public bool zahlungseingangBuchen(double betrag, String nr)
        {
            RechnungsNrTyp rnr = new RechnungsNrTyp(nr);

            double preis = getRechnung(rnr).preis;
            var alleZahlungen = getZahlungseingaenge(rnr);
            Double alleBetraege = alleZahlungen.Sum(x => x.betrag);

            if(preis <= alleBetraege + betrag)
                setRechnungStatus(rnr, RechnungStatus.BEGLICHEN);
            else if(alleBetraege + betrag > 0)
                setRechnungStatus(rnr, RechnungStatus.TEIL_BEGLICHEN);
            else
                setRechnungStatus(rnr, RechnungStatus.OFFEN);

            return rechnungRepo.zahlungseingangBuchen(betrag, nr);
        }


        public IList<ZahlungseingangTyp> getZahlungseingaenge(RechnungsNrTyp rnr)
        {
            return rechnungRepo.getZahlungseingaenge(rnr);
        }

        public void setRechnungStatus(RechnungsNrTyp nr, RechnungStatus status)
        {
            rechnungRepo.setRechnungStatus(nr, status);
        }
    }
}

using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using HES.Lager.Repository.Entity;
using HES.TransportComp.Repository.Entity;
using RechnungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Fassade
{
    public class Fassade : MarshalByRefObject, IHes
    {
        public static Core.Core hesCore;

        public Fassade()
        { }

        public MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl)
        {
            return hesCore.getLagerComp().erstelleWarenausgang(prod, Anzahl);
        }

        public ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod)
        {
            return hesCore.getLagerComp().erstelleProdukt(prod);
        }

        public KundenNrTyp erstelleKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land)
        {
            return hesCore.getKundeComp().erstelleKunden(nachname, vorname, geburtsdatum, level, strase, plz, ort, land);
        }

        public KundeTyp getKundeByKundenNr(KundenNrTyp nr)
        {
            return hesCore.getKundeComp().getKundeByKundenNr(nr);
        }

        public IList<KundeTyp> getKundenByName(string name)
        {
            return hesCore.getKundeComp().getKundenByName(name);
        }

        public AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kundeNr, IDictionary<ProduktNummerTyp, int> produktListe)
        {
            return hesCore.getAuftragserfassungComp().erstelleAngebot(gueltigAb, gueltigBis, preis, kundeNr, produktListe);
        }

        public AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr, bool istAbgeschlossen, DateTime erstelltAm)
        {
            return hesCore.getAuftragserfassungComp().erstelleAuftrag(nr, istAbgeschlossen, erstelltAm);
        }

        public AuftragTyp holeAuftrag(AuftragNrTyp auftragNr)
        {
            return hesCore.getAuftragserfassungComp().holeAuftrag(auftragNr);
        }

        public TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, string transportDienstleister, AuftragNrTyp auftrag)
        {
            return hesCore.getTransportComp().erstelleTransportauftrag(liefernummer, ausgangsDatum, lieferungErfolgt, lieferDatum, transportDienstleister, auftrag);
        }

        public TransportauftragTyp getTransportAuftrag(TransportauftragNrTyp nr)
        {
            return hesCore.getTransportComp().getTransportAuftrag(nr);
        }

        public RechnungsNrTyp erstelleRechnung(AuftragTyp auftrag)
        {
            return hesCore.getRechnungComp().erstelleRechnung(auftrag);
        }


        public ProduktDetailsTyp getProdukt(ProduktNummerTyp prodNr)
        {
            return hesCore.getLagerComp().getProdukt(prodNr);
        }


        public RechnungsTyp getRechnung(RechnungsNrTyp nr)
        {
            return hesCore.getRechnungComp().getRechnung(nr);
        }
    }
}

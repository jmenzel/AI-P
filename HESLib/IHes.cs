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
    public interface IHes
    {
        #region Lager
        MeldungsNummerTyp erstelleWarenausgang(ProduktDetailsTyp prod, int Anzahl);
        ProduktNummerTyp erstelleProdukt(ProduktDetailsTyp prod);
        #endregion

        #region Kunde
        KundenNrTyp erstelleKunden(string nachname, string vorname, DateTime geburtsdatum, KundenLevel level, string strase, string plz, string ort, string land);
        KundeTyp getKundeByKundenNr(KundenNrTyp nr);
        IList<KundeTyp> getKundenByName(string name);

        
        #endregion

        #region Auftragserfassung
        AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kundeNr, IDictionary<ProduktNummerTyp, int> produktListe);
        AuftragNrTyp erstelleAuftrag(AngebotNrTyp nr, bool istAbgeschlossen, DateTime erstelltAm);
        AuftragTyp holeAuftrag(AuftragNrTyp auftragNr);
        
        #endregion

        #region Transport
        TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister, AuftragNrTyp auftrag);
        TransportauftragTyp getTransportAuftrag(TransportauftragNrTyp nr);        
        #endregion

        #region Rechnung
        RechnungsNrTyp erstelleRechnung(AuftragTyp auftrag);
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Repository.Entity;
using HES.Kunde.Repository.Entity;
using HES.AuftragserfassungComp.Repository;
using HES.Lager.Repository.Entity;
using HES.Lager.Produkt.Repository.Entity;
using HES.Lager;

namespace HES.AuftragserfassungComp.Logic
{
    class Auftragserfassung : IAuftragserfassung
    {
        IAuftragserfassungIntern repo = new AuftragserfassungRepo();
        private ILager lagerKomp = LagerComp.getLagerComp(LagerComp.getDB());

        public Auftragserfassung() { }

        //Der Preis wird hier berechnet und nach unten gereicht, damit die Entity davon nichts mitbekommt
        public AngebotNrTyp erstelleAngebot(DateTime gueltigAb, DateTime gueltigBis, double preis, KundeTyp kunde,IDictionary<ProduktNummerTyp, int> produktListe)
        {
            return repo.erstelleAngebot(gueltigAb,gueltigBis,getGesamtPreis(produktListe,preis),kunde);
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

        public AuftragTyp holeAuftrag(AuftragNrTyp auftragNr)
        {
            return repo.holeAuftrag(auftragNr);
        }

        #region Private Logic Methoden
 
        /// <summary>
        /// Holt sich den Preis des jeweiligen Produktes aus dem Lager und summiert den Preis
        /// für die Anzahl der Produkte
        /// </summary>
        /// <param name="produktListe"></param>
        /// <param name="zusatzKosten"></param>
        /// <returns></returns>
        private double getGesamtPreis(IDictionary<ProduktNummerTyp, int> produktListe, double zusatzKosten)
        {
            double gesamtPreis = 0;

            foreach (KeyValuePair<ProduktNummerTyp,int> pair in produktListe)
            {
                gesamtPreis += (lagerKomp.getProdukt(pair.Key).preis * pair.Value);
            }
            return gesamtPreis + zusatzKosten;
        }

        #endregion
    }
}

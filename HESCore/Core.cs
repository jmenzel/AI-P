using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.Kunde;
using HES.Kunde.Repository.Entity;
using HES.Lager;
using HES.Lager.Produkt.Repository.Entity;
using HES.TransportComp.Repository.Entity;
using HES.Core.Persistance;
using NHibernate;
using HES.TransportComp;
using HES.AuftragserfassungComp;
using RechnungComp;
using HES.Fassade;

namespace HES.Core
{
    public class Core
    {
        private ISessionFactory db;

        private ILager lager;
        private ITransport transport;
        private IAuftragserfassung auftragserfassung;
        private IKunde kunden;
        private IRechnung rechnung;

        private ClientConnector connector;


        public Core(string server_name, int port)
        {
            #region Komponenten erstellen
            db = Database.CreateSessionFactory();

            lager = LagerComp.getLagerComp(db);
            kunden = KundenKomp.getKundenComp(db);
            auftragserfassung = AuftragserfassungKomp.getAuftragskomponenteComp(db);
            transport = TransportKomp.getTransportKomp(db);
            rechnung = RechnungKomp.getRechnungKomp(db);
            #endregion

            #region Fassade erstellen
            Fassade.Fassade.hesCore = this;
            connector = new ClientConnector(server_name, port);
            #endregion
        }

        public ILager getLagerComp()
        {
            return lager;
        }

        public ITransport getTransportComp()
        {
            return transport;
        }

        public IAuftragserfassung getAuftragserfassungComp()
        {
            return auftragserfassung;
        }

        public IKunde getKundeComp()
        {
            return kunden;
        }

        public IRechnung getRechnungComp()
        {
            return rechnung;
        }
    }
}

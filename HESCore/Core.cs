﻿using System;
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
using HESCommunicationLib.Transport;
using HESCommunicationLib;

namespace HES.Core
{
    public class Core
    {
        #region RabbitMQ Parameter

        private readonly String hostname = "localhost";
        private readonly String queuename = "HAPSAR";
       
        #endregion

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


            ITDLConnector tdl = new TDLConnector();
            tdl.setAuftragserfassungComp(auftragserfassung);

            transport = TransportKomp.getTransportKomp(db, tdl);

            rechnung = RechnungKomp.getRechnungKomp(db);
            //HAPSAR Connector
            HAPSARConnector hapsar = new HAPSARConnector(rechnung, hostname, queuename);
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
            if (transport == null) Console.WriteLine("Transport null?!?!");
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

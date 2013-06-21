using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;
using HES.TransportComp.Repository;
using HES.AuftragserfassungComp.Repository.Entity;
using HESCommunicationLib;

namespace HES.TransportComp.Logic
{
    class Transportauftrag : ITransport
    {
        private TransportRepo repo;
        private TDLConnector tdl;

        public Transportauftrag(TDLConnector tdl)
        {
            this.tdl = tdl;
            repo = new TransportRepo();
        }

        public TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister,AuftragNrTyp auftrag)
        {
            var tdNr = repo.erstelleTransportauftrag(liefernummer, ausgangsDatum, lieferungErfolgt, lieferDatum, transportDienstleister,auftrag);
            tdl.putTransportauftrag(repo.getTransportAuftrag(tdNr));
            return tdNr;
        }

        public TransportauftragTyp[] getTransportauftraege()
        {
            return repo.getTransportauftraege();
        }

        public LiefernummerTyp erstelleLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }

        public void markiereLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }

        public TransportauftragTyp getTransportAuftrag(TransportauftragNrTyp nr)
        {
            return repo.getTransportAuftrag(nr);
        }
    }
}

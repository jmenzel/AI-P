using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;
using HES.TransportComp.Repository;

namespace HES.TransportComp.Logic
{
    class Transportauftrag : ITransport
    {
        private TransportRepo repo;

        public Transportauftrag()
        {
            repo = new TransportRepo();
        }

        public TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister)
        {
            return repo.erstelleTransportauftrag(liefernummer, ausgangsDatum, lieferungErfolgt, lieferDatum, transportDienstleister);
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

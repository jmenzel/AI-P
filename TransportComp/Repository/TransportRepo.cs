using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;

namespace HES.TransportComp.Repository
{
    class TransportRepo : ITransport
    {
        public TransportauftragTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, TransportauftragNummerTyp nr, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister)
        {
            throw new NotImplementedException();
        }

        public LiefernummerTyp erstelleLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }

        public void markiereLieferung(LieferdetailsTyp lieferung)
        {
            throw new NotImplementedException();
        }
    }
}

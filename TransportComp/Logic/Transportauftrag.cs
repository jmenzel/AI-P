﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;
using HES.TransportComp.Repository;

namespace HES.TransportComp.Logic
{
    public class Transportauftrag : ITransport
    {
        private TransportRepo repo = new TransportRepo();
        

        public TransportauftragTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, TransportauftragNummerTyp nr, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister)
        {
            return repo.erstelleTransportauftrag(liefernummer, nr, ausgangsDatum, lieferungErfolgt, lieferDatum, transportDienstleister);
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

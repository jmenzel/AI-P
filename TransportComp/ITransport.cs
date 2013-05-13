using HES.TransportComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp
{
    /// <summary>
    /// Schnittstelle für die Transportkomponente
    /// </summary>
    interface ITransport
    {
        TransportauftragTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, TransportauftragNummerTyp nr, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister);
        LiefernummerTyp erstelleLieferung(LieferdetailsTyp lieferung);
        void markiereLieferung(LieferdetailsTyp lieferung);
    }
}

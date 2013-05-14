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
    public interface ITransport
    {
        TransportauftragNrTyp erstelleTransportauftrag(LiefernummerTyp liefernummer, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister);
        //Macht erstmal keinen Sinn, nur Testhalber um zu sehen was da drin steckt!
        TransportauftragTyp getTransportAuftrag(TransportauftragNrTyp nr);
        TransportauftragTyp[] getTransportauftraege();
        LiefernummerTyp erstelleLieferung(LieferdetailsTyp transportauftrag);
        void markiereLieferung(LieferdetailsTyp lieferung);
    }
}

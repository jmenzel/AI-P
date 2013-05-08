using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.TransportComp.Repository.Entity;

namespace HES.TransportComp.Logic
{
    class Transportauftrag : ITransport
    {
        public TransportauftragTyp erstelleTransportauftrag(LiefernummerTyp nur)
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

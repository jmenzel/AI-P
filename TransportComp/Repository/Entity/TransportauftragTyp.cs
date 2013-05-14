using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp.Repository.Entity
{
    public class TransportauftragTyp
    {
        public virtual int ID { get; protected set; }
        public virtual LiefernummerTyp lieferNummer { get; protected set; }
        public virtual TransportauftragNrTyp nr { get; protected set; }
        public virtual DateTime ausgangsDatum { get; protected set; }
        public virtual bool lieferungErfolg { get; protected set; }
        public virtual DateTime lieferDatum { get; protected set; }
        //Hier evlt. KundeTyp oder eigenen LieferanteTyp?
        public virtual String transportDienstleister { get; protected set; }


        public TransportauftragTyp(LiefernummerTyp liefernummer, TransportauftragNrTyp nr, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister)
        {
            this.lieferNummer = lieferNummer;
            this.nr = nr;
            this.ausgangsDatum = ausgangsDatum;
            this.lieferungErfolg = lieferungErfolg;
            this.lieferDatum = lieferDatum;
            this.transportDienstleister = transportDienstleister;
        }

        protected TransportauftragTyp() { }

        public override string ToString()
        {
            return "Liefernummer: " + lieferNummer
                + "\nTransportnummer: " + nr.ToString()
                + "\nAusgangsdatum: " + ausgangsDatum.Date
                + "\nLieferdatum: " + lieferDatum.Date
                + "\nTransportdienstleister: " + transportDienstleister;
        }
    }
}

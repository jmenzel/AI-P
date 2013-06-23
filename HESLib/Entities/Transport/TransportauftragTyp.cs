using HES.AuftragserfassungComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.TransportComp.Repository.Entity
{
    [Serializable()]
    public class TransportauftragTyp
    {
        public virtual int ID { get; set; }
        public virtual LiefernummerTyp lieferNummer { get; set; }
        public virtual TransportauftragNrTyp nr { get; set; }
        public virtual DateTime ausgangsDatum { get; set; }
        public virtual bool lieferungErfolg { get; set; }
        public virtual DateTime lieferDatum { get; set; }
        //Hier evlt. KundeTyp oder eigenen LieferanteTyp?
        public virtual String transportDienstleister { get; set; }
        public virtual AuftragNrTyp auftrag { get; set; }


        public TransportauftragTyp(LiefernummerTyp liefernummer, TransportauftragNrTyp nr, DateTime ausgangsDatum, bool lieferungErfolgt, DateTime lieferDatum, String transportDienstleister,AuftragNrTyp auftrag)
        {
            this.lieferNummer = lieferNummer;
            this.nr = nr;
            this.ausgangsDatum = ausgangsDatum;
            this.lieferungErfolg = lieferungErfolg;
            this.lieferDatum = lieferDatum;
            this.transportDienstleister = transportDienstleister;
            this.auftrag = auftrag;
        }

        protected TransportauftragTyp() { }

        public override string ToString()
        {
            return "Liefernummer: " + lieferNummer
                + "\nTransportnummer: " + nr.ToString()
                + "\nAuftragsnummer: " + auftrag.ToString()
                + "\nAusgangsdatum: " + ausgangsDatum.Date
                + "\nLieferdatum: " + lieferDatum.Date
                + "\nTransportdienstleister: " + transportDienstleister;
        }
    }
}

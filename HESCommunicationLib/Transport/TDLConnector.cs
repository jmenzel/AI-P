using HES.AuftragserfassungComp;
using HES.Kunde;
using HES.Lager;
using HES.TransportComp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HESCommunicationLib.Transport
{
    public class TDLConnector : ITDLConnector
    {
        private HttpClient client;

        private IKunde kunde;
        private IAuftragserfassung auftrag;
        private ILager lager;

        public TDLConnector()
        {
            client =  new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void putTransportauftrag(TransportauftragTyp ta)
        {
            //Create Auftrag Object

            var auft = auftrag.holeAuftrag(ta.auftrag);
            var angebot = auftrag.holeAngebot(auft.gehoertZuAngebot);
            var customer = angebot.kunde;

            Auftrag a1 = new Auftrag()
            {
                AuftragNr = ta.nr.nr,
                ExtLieferNr = ta.lieferNummer.nr,
                Ausgeliefert = false,
                AusgeliefertDate = new DateTime(1970, 01, 01),
                DestName = customer.name,
                DestFirstName = customer.vorname,
                DestStreet = customer.strasse,
                DestCity = customer.ort,
                DestPLZ = customer.plz,
                DestHouseNr = "",
            };





            var resp_a1 = client.PostAsJsonAsync<Auftrag>("api/Auftrag", a1).Result;
        }

        public void setKundenComp(IKunde kunde)
        {
            this.kunde = kunde;
        }

        public void setAuftragserfassungComp(IAuftragserfassung auftrag)
        {
            this.auftrag = auftrag;
        }

        public void setLagerComp(HES.Lager.ILager lager)
        {
            this.lager = lager;
        }
    }
}

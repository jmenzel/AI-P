using HES.AuftragserfassungComp;
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

        private IAuftragserfassung auftrag;

        public TDLConnector()
        {
            client =  new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void putTransportauftrag(TransportauftragTyp ta)
        {
            //Create Auftrag Object

            if (auftrag == null) Console.WriteLine("AuftragKomp is null");
            
            var auft = auftrag.holeAuftrag(ta.auftrag);

            if (auft == null) Console.WriteLine("Hole Auftrag schlug fehl -> " + ta.auftrag.ToString());

            var angebot = auftrag.holeAngebot(auft.gehoertZuAngebot);

            if (angebot == null) Console.WriteLine("Hole Angebot schlug fehl -> " + auft.gehoertZuAngebot.ToString());

            var customer = angebot.kunde;

            if (customer == null) Console.WriteLine("Customer is null -> " + auft.ToString());


            Auftrag a1 = new Auftrag()
            {
                AuftragNr = ta.nr.nr,
                ExtLieferNr = (ta.lieferNummer != null) ? ta.lieferNummer.nr : "",
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

        public void setAuftragserfassungComp(IAuftragserfassung auftrag)
        {
            this.auftrag = auftrag;
        }

    }
}

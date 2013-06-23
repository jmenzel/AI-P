using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using TDL_REST_Service.Models;


namespace Rest_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8000/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var a1 = new Auftrag()
            {
                ExtLieferNr = "LN_asfgbbabkabshfv",
                AuftragNr = "AN_245kajbfd",
                DestName = "Menzel",
                DestFirstName = "Jan",
                DestStreet = "Malzweg",
                DestHouseNr = "2",
                DestPLZ = "20535",
                DestCity = "Hamburg",
                Ausgeliefert = false,
                AusgeliefertDate = new DateTime(1970, 1, 1),
            };

            var a2 = new Auftrag()
            {
                ExtLieferNr = "LN_aetjadbddgdgj",
                AuftragNr = "AN_sfgj659aedh",
                DestName = "Menzel",
                DestFirstName = "Jan",
                DestStreet = "Malzweg",
                DestHouseNr = "2",
                DestPLZ = "20535",
                DestCity = "Hamburg",
                Ausgeliefert = false,
                AusgeliefertDate = new DateTime(1970, 1, 1),
            };

            var resp_a1 = client.PostAsJsonAsync<Auftrag>("api/Auftrag", a1).Result;
            var resp_a2 = client.PostAsJsonAsync<Auftrag>("api/Auftrag", a2).Result;

            Uri a1_uri = resp_a1.Headers.Location;
            Uri a2_uri = resp_a2.Headers.Location;

            if (resp_a1.IsSuccessStatusCode) Console.WriteLine("A1 Created at " + a1_uri.ToString());
            else Console.WriteLine("A1 not Created -> " + resp_a1.StatusCode.ToString());

            if (resp_a2.IsSuccessStatusCode) Console.WriteLine("A2 Created at " + a2_uri.ToString());
            else Console.WriteLine("A2 not Created -> " + resp_a2.StatusCode.ToString());


            //List all Auftraege
            HttpResponseMessage response = client.GetAsync("api/Auftrag").Result;

            if (response.IsSuccessStatusCode)
            {
                var auftrag_list = response.Content.ReadAsAsync<IEnumerable<Auftrag>>().Result;

                foreach (var auftrag in auftrag_list)
                {
                    Console.WriteLine("AuftragNr: " + auftrag.AuftragNr);
                    Console.WriteLine("An: " + auftrag.DestFirstName + " " + auftrag.DestName);
                    Console.WriteLine(" ----------------------------- ");
                }
            }



            Console.ReadLine();
        }
    }
}

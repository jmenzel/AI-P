using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDL_REST_Service.Models
{
    public class Auftrag
    {
        public int Id { get; set; }
        public string ExtLieferNr { get; set; }
        public string AuftragNr { get; set; }
        public string DestName { get; set; }
        public string DestFirstName { get; set; }
        public string DestStreet { get; set; }
        public string DestHouseNr { get; set; }
        public string DestPLZ { get; set; }
        public string DestCity { get; set; }
        public bool Ausgeliefert { get; set; }
        public DateTime AusgeliefertDate { get; set; }
    }
}
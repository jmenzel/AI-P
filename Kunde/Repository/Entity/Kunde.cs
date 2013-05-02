using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository.Entity
{
    class Kunde
    {
        public KundenNrTyp kundenNr { get; set; }
        public KundenLevel level { get; set; }
        public string name { get; set; }
        public string hausnr { get; set; }
        public string strasse { get; set; }
        public string ort { get; set; }
        public string plz { get; set; }
        public string land { get; set; }

        public KundeTyp asKundeTyp()
        {
            return new KundeTyp
            {

            };
        }
    
    }


    public enum KundenLevel
    {
        Potentiell,
        Regulaer,
        HighOrder
    }
}

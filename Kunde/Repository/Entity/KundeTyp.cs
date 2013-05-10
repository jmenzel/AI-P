using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository.Entity
{
    public class KundeTyp
    {
        public KundenNrTyp kundenNr { get; private set; }
        public KundenLevel level { get; private set; }
        public string vorname { get; private set; }
        public string name { get; private set; }
        public DateTime geburtstag { get; private set; }
        public string hausnr { get; private set; }
        public string strasse { get; private set; }
        public string ort { get; private set; }
        public int plz { get; private set; }
        public string land { get; private set; }

    }
}

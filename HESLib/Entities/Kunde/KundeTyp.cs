using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde.Repository.Entity
{
    public class KundeTyp
    {
        public virtual int ID { get; protected set; }
        public virtual KundenNrTyp kundenNr { get; protected set; }
        public virtual KundenLevel level { get; protected set; }
        public virtual string vorname { get; protected set; }
        public virtual string name { get; protected set; }
        public virtual DateTime geburtstag { get; protected set; }
        public virtual string strasse { get; protected set; }
        public virtual string ort { get; protected set; }
        public virtual string plz { get; protected set; }
        public virtual string land { get; protected set; }

        public KundeTyp(KundenNrTyp nr, KundenLevel lvl, string vorname, string name, DateTime geb, string strasse, string ort, string plz, string land)
        {
            this.kundenNr = nr;
            this.level = lvl;
            this.vorname = vorname;
            this.name = name;
            this.geburtstag = geb;
            this.strasse = strasse;
            this.ort = ort;
            this.plz = plz;
            this.land = land;
        }

        protected KundeTyp() { }

        public override string ToString()
        {
            return "Kundennr.: " + kundenNr
                + "\nVorname: " + vorname
                + "\nNachname: " + name
                + "\nStraße: " + strasse
                + "\nOrt: " + ort
                + "\nPlz: " + plz
                + "\nLand: " + land;
        }
    }


}

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
        public virtual string hausnr { get; protected set; }
        public virtual string strasse { get; protected set; }
        public virtual string ort { get; protected set; }
        public virtual string plz { get; protected set; }
        public virtual string land { get; protected set; }
    
    
    }


}

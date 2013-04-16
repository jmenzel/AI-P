using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud.Verwaltung.Entities
{
    public class Buch
    {
        public virtual int ID { get; protected set; }
        public virtual string Titel { get; set; }
        public virtual IList<Kurs> EmpfohlenFuer { get; set; }


        public Buch()
        {
            EmpfohlenFuer = new List<Kurs>();
        }

    }
}

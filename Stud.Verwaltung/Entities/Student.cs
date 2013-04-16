using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud.Verwaltung.Entities
{
    public class Student
    {
        public virtual int ID { get; protected set; }
        public virtual string Name { get; set; }
        public virtual NotenKonto NKonto { get; set; }
        public virtual IList<Kurs> KursListe { get; set; }

        public Student()
        {
            KursListe = new List<Kurs>();
        }

        public virtual void AddKurs(Kurs k)
        {
            this.KursListe.Add(k);
            k.Stud = this;
        }

        public virtual void DeleteKurs(Kurs k)
        {
            this.KursListe.Remove(k);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud.Verwaltung.Entities
{
    public class Kurs
    {
        public virtual int ID { get; protected set; }
        public virtual string Title { get; set; }
        public virtual Student Stud { get; set; }
        public virtual IList<Buch> BuchEmpfehlung { get; set; }

        public Kurs()
        {
            BuchEmpfehlung = new List<Buch>();
        }

        public virtual void AddBuchEmpfehlung(Buch b)
        {
            this.BuchEmpfehlung.Add(b);
        }

        public virtual void DeleteBuchEmpfehlung(Buch b)
        {
            this.BuchEmpfehlung.Remove(b);
        }
    }
}

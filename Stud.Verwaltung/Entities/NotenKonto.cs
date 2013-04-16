using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud.Verwaltung.Entities
{
    public class NotenKonto
    {
        public virtual int ID { get; protected set; }
        public virtual int Gesamtnote { get; set; }
        public virtual Student Stud { get; set; }
    }
}

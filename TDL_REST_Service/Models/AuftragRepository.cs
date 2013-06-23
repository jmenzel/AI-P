using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TDL_REST_Service.Models
{
    public class AuftragRepository : IAuftragRepository
    {
        private List<Auftrag> auftraege = new List<Auftrag>();

        private int _nextId = 1;

        public IEnumerable<Auftrag> GetAll()
        {
            return auftraege;
        }

        public Auftrag Get(int id)
        {
            return auftraege.Find(a => a.Id == id);
        }

        public Auftrag Add(Auftrag item)
        {
            if (item == null) throw new ArgumentNullException("item");

            item.Id = _nextId++;
            auftraege.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            auftraege.RemoveAll(a => a.Id == id);
        }

        public bool Update(Auftrag item)
        {
            if (item == null) throw new ArgumentNullException("item");
            
            int index = auftraege.FindIndex(a => a.Id == item.Id);
            if (index == -1) return false;

            auftraege.RemoveAt(index);
            auftraege.Add(item);

            return true;
        }
    }
}
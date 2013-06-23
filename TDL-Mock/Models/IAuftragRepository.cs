using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL_REST_Service.Models
{
    public interface IAuftragRepository
    {
        IEnumerable<Auftrag> GetAll();
        Auftrag Get(int id);
        Auftrag Add(Auftrag item);
        void Remove(int id);
        bool Update(Auftrag item);
    }
}

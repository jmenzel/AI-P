using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDL_Mock
{
    public class TDLService : ITDL
    {
        public string test(string s)
        {
            return "Test -> " + s.ToUpper();
        }

        public string test2(string s, string bla)
        {
            return "Test -> " + s.ToUpper() + "--" + bla.ToUpper();
        }
    }
}

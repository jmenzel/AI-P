using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde
{
    public static class KundenComp
    {

        public static IKunde getKundenComp()
        {
            return new Logic.Kunde();
        }
    }
}

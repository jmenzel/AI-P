using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Kunde
{
    public static class KundenKomp
    {

        public static IKunde getKundenComp()
        {
            return new Logic.Kunde();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Logic;

namespace HES.AuftragserfassungComp
{
    class AuftragserfassungComp
    {
        public static IAuftragserfassung getAuftragskomponenteComp()
        {
            return new Logic.Auftragserfassung();
        }
    }
}

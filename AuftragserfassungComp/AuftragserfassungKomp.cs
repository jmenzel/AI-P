using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HES.AuftragserfassungComp.Logic;
using NHibernate;

namespace HES.AuftragserfassungComp
{
    public class AuftragserfassungKomp
    {
        static ISessionFactory db;

        public static IAuftragserfassung getAuftragskomponenteComp(ISessionFactory db)
        {
            AuftragserfassungKomp.db = db;
            return new Logic.Auftragserfassung();
        }
        
        public static ISessionFactory getDB()
        {
            return AuftragserfassungKomp.db;
        }

    }
}

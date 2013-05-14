using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechnungComp
{
    public static class RechnungKomp
    {
        static ISessionFactory db;

        public static ISessionFactory getDB()
        {
            return RechnungKomp.db;
        }

        public static IRechnung getRechnungKomp(ISessionFactory db)
        {
            RechnungKomp.db = db;
            return new Logic.Rechnung();
        }

    }
}

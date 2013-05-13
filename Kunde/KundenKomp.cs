using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace HES.Kunde
{
    public static class KundenKomp
    {
        static ISessionFactory db;

        public static IKunde getKundenComp(ISessionFactory db)
        {
            KundenKomp.db = db;
            return new Logic.Kunde();
        }

        public static ISessionFactory getDb()
        {
            return KundenKomp.db;
        }
    }
}

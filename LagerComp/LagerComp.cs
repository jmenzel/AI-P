using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Lager
{
    public static class LagerComp
    {
        static ISessionFactory db;

        public static ISessionFactory getDB()
        {
            return LagerComp.db;
        }

        public static ILager getLagerComp(ISessionFactory db)
        {
            LagerComp.db = db;
            return new Logic.Lager();
        }
    }
}

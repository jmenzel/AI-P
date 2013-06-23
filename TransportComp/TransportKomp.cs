using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using HESCommunicationLib;
using HESCommunicationLib.Transport;

namespace HES.TransportComp
{
    public static class TransportKomp
    {
        static ISessionFactory db;

        public static ISessionFactory getDB()
        {
            return TransportKomp.db;
        }

        //public static ITransport getTransportKomp(ISessionFactory db)
        public static ITransport getTransportKomp(ISessionFactory db, ITDLConnector tdl)
        {
           TransportKomp.db = db;
           return new Logic.Transportauftrag(tdl);
        }

             
    }
}

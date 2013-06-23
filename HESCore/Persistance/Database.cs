using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HES.Core.Persistance
{
    static class Database
    {
        const string DB_NAME = "HES.db";

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                //.Database(SQLiteConfiguration.Standard.UsingFile(DB_NAME))
                .Database(MySQLConfiguration.Standard.ConnectionString(x => x.Server("localhost").Database("HES").Username("root").Password("")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Core>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        public static void BuildSchema(Configuration config)
        {
            //new SchemaExport(config).SetDelimiter(";").Execute(true, true, false);
            new SchemaUpdate(config).Execute(true, true);
            //if (File.Exists(DB_NAME)) File.Delete(DB_NAME);
            //new SchemaExport(config).Create(false, true);
        }
    }
}

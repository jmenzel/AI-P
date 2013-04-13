using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using Examples.FirstProject.Entities;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.IO;
using NHibernate.Tool.hbm2ddl;

namespace Examples.FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {

            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                /*
                using (var transaction = session.BeginTransaction())
                {
                    var barginBasin = new Store { Name = "Bargin Basin" };
                    var superMart = new Store { Name = "SuperMart" };

                    var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                    var fish = new Product { Name = "Fish", Price = 4.49 };
                    var milk = new Product { Name = "Milk", Price = 0.79 };
                    var bread = new Product { Name = "Bread", Price = 1.29 };
                    var cheese = new Product { Name = "Cheese", Price = 2.10 };
                    var waffles = new Product { Name = "Waffles", Price = 2.41 };

                    var daisy = new Employee { FirstName = "Daisy", LastName = "Harrison" };
                    var jack = new Employee { FirstName = "Jack", LastName = "Torrance" };
                    var sue = new Employee { FirstName = "Sue", LastName = "Walkters" };
                    var bill = new Employee { FirstName = "Bill", LastName = "Traft" };
                    var joan = new Employee { FirstName = "Joan", LastName = "Pope" };

                    AddProductsToStore(barginBasin, potatoes, fish, milk, bread, cheese);
                    AddProductsToStore(superMart, bread, cheese, waffles);

                    AddEmployeesToStore(barginBasin, daisy, jack, sue);
                    AddEmployeesToStore(superMart, bill, joan);

                    session.SaveOrUpdate(barginBasin);
                    session.SaveOrUpdate(superMart);

                    transaction.Commit();
                }
                */

                using (session.BeginTransaction())
                {
                    var stores = session.CreateCriteria(typeof(Store)).List<Store>();

                    foreach (var store in stores)
                    {
                        Console.WriteLine(store.Name);
                        Console.WriteLine(string.Join(", ", store.Products.Select(x => x.Name)));
                        Console.WriteLine(string.Join(", ", store.Staff.Select(x => x.FirstName + " " + x.LastName)));
                    }
                }

                Console.ReadKey();


            }

        }

        public static void AddProductsToStore(Store store, params Product[] products)
        {
            foreach (var product in products)
            {
                store.AddProduct(product);
            }
        }

        public static void AddEmployeesToStore(Store store, params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                store.AddEmployee(employee);
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                //.Database(SQLiteConfiguration.Standard.UsingFile("firstProject.db"))
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(c => c.Is("data source=firstProject.sdf")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                //.ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            //if (File.Exists("firstProject.db")) File.Delete("firstProject.db");
            //if (File.Exists("firstProject.sdf")) File.Delete("firstProject.sdf");

            new SchemaExport(config).Create(false, true);
        }
    }
}

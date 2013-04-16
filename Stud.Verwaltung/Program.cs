using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Stud.Verwaltung.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stud.Verwaltung
{
    class Program
    {
        const string DB_NAME = "StudVerwaltung.db";


        static void Main(string[] args)
        {
            var sessionFactory = CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {

                #region Entitäten erstellen
                using (var transaction = session.BeginTransaction())
                {
                    var Hans = new Student { Name = "Hans", NKonto = new NotenKonto { Gesamtnote = 9 } };
                    var Kurt = new Student { Name = "Kurt", NKonto = new NotenKonto { Gesamtnote = 13 } };
                    var Anne = new Student { Name = "Anne", NKonto = new NotenKonto { Gesamtnote = 11 } };
                    var Lisa = new Student { Name = "Lisa", NKonto = new NotenKonto { Gesamtnote = 10 } };

                    Hans.NKonto.Stud = Hans;
                    Kurt.NKonto.Stud = Kurt;
                    Anne.NKonto.Stud = Anne;
                    Lisa.NKonto.Stud = Lisa;


                    var kunst = new Kurs { Title = "Kunst" };
                    var ital = new Kurs { Title = "Italienisch" };
                    var musik = new Kurs { Title = "Musik" };
                    var span = new Kurs { Title = "Spanisch" };
                    var phys = new Kurs { Title = "Physik" };
                    var chem = new Kurs { Title = "Chemie" };

                    var bchem = new Buch { Titel = "Chemie Grundlagen" };
                    var bspan = new Buch { Titel = "Spanisch für Anfänger" };

                    AddBuchToKurs(chem, bchem);
                    AddBuchToKurs(span, bspan);

                    AddKursToStudent(Hans, kunst, musik);
                    AddKursToStudent(Kurt, phys, chem);
                    AddKursToStudent(Anne, ital);
                    AddKursToStudent(Lisa, span);

                    session.SaveOrUpdate(Hans);
                    session.SaveOrUpdate(Kurt);
                    session.SaveOrUpdate(Lisa);
                    session.SaveOrUpdate(Anne);

                    transaction.Commit();
                }

                #endregion

                printDataContent(session);

                #region Entitäten berarbeiten
                using (var transaction = session.BeginTransaction())
                {
                    var hans = session.CreateCriteria(typeof(Student))
                        .Add(Restrictions.Eq("Name", "Hans"))
                        .UniqueResult<Student>();

                    hans.NKonto.Gesamtnote = 8;

                    var lisa = session.CreateCriteria(typeof(Student))
                        .Add(Restrictions.Eq("Name", "Lisa"))
                        .UniqueResult<Student>();

                    lisa.Name = "Lisa Lotta";

                    var musik = session.CreateCriteria(typeof(Kurs))
                        .Add(Restrictions.Eq("Title", "Musik"))
                        .UniqueResult<Kurs>();

                    musik.AddBuchEmpfehlung(new Buch { Titel = "Notenlesen leicht gemacht" });

                    session.SaveOrUpdate(hans);
                    session.SaveOrUpdate(lisa);
                    session.SaveOrUpdate(musik);

                    transaction.Commit();

                }
                #endregion

                printDataContent(session);

            }

            Console.ReadKey();
        }

        private static void printDataContent(ISession session)
        {
            using (var transaction = session.BeginTransaction())
            {
                var studenten = session.CreateCriteria(typeof(Student)).List<Student>();

                foreach (var student in studenten)
                {
                    Console.WriteLine(student.Name + " hat Note " + student.NKonto.Gesamtnote);

                    foreach (var kurs in student.KursListe)
                    {
                        Console.WriteLine(" - Besucht " + kurs.Title + " mit folgenden Buchempfehlungen: ");

                        foreach (var buch in kurs.BuchEmpfehlung)
                        {
                            Console.WriteLine("    -   " + buch.Titel);
                        }
                    }
                    Console.WriteLine("");
                }

            }
        }


        private static void AddBuchToKurs(Kurs k, params Buch[] b)
        {
            foreach (var buch in b)
            {
                k.AddBuchEmpfehlung(buch);
            }
        }

        private static void AddKursToStudent(Student s, params Kurs[] k)
        {
            foreach (var kurs in k)
            {
                s.AddKurs(kurs);
            }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DB_NAME))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists(DB_NAME)) File.Delete(DB_NAME);
            new SchemaExport(config).Create(false, true);
        }
    }
}

using Data.Ef;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingFolder = Environment.CurrentDirectory;
            var dbPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;

            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

            PrepareData();

            var http = new HttpClient();
            var r1 = http.GetAsync(@"http://localhost:21152/restier/TablePerHierarchyEntitySet/Domain.DerivedType1").Result;
            var r2 = http.GetAsync(@"http://localhost:21152/restier/TablePerHierarchyEntitySet/Domain.DerivedType1/").Result;
        }

        private static void PrepareData()
        {
            var db = new RestierDbContext();
            var existingEntities = db.TablePerHierarchyEntitySet.ToArray();
            if (!existingEntities.OfType<DerivedType1>().Any())
            {
                var dt1 = new DerivedType1() { Id = -10, MyProperty1 = 123.456m };
                db.Set<HierarchyRoot>().Add(dt1);
            }
            if (!existingEntities.OfType<DerivedType2>().Any())
            {
                var dt2 = new DerivedType2() { Id = -10, MyProperty2 = "qwerty" };
                db.Set<HierarchyRoot>().Add(dt2);
            }
            db.SaveChanges();
        }
    }
}

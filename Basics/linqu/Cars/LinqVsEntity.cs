using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Cars
{
    public static class LinqVsEntity
    {
    
        public static void InsertCarsDb()
        {
            var cars = ProcessCsv("fuel.csv");
            var db = new CarDb();

            if (!db.Cars.Any())
            {
                foreach (var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }
        
        public static void QueryCarsDb()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;

            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;

            var query2 = db.Cars.OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Take(10);

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{car.Name}:\t{car.Combined}");
            }

        }

        public static void QueryAndGroup()
        {
            var db = new CarDb();

            db.Database.Log = Console.WriteLine;

            var query = db.Cars.GroupBy(c => c.Manufacturer)
                            .Select(g => new {
                                Manufacturer = g.Key,
                                Cars = g.OrderByDescending(c => c.Combined).Take(2)
                            }
                            );

            var query2 = from car in db.Cars
                         group car by car.Manufacturer into manufacturer
                         select new
                         {
                             Manufacturer = manufacturer.Key,
                             Cars = (from car in manufacturer
                                     orderby car.Combined descending
                                     select car).Take(2)
                         };


            foreach (var group in query)
            {
                Console.WriteLine(group.Manufacturer);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"{car.Name}:\t{car.Combined}");
                }
            }
                   
        }

        public static void IQuerableDemo()
        {
            Func<int, int> square = x => x * x;
            Expression<Func<int, int, int>> add = (x, y) => x + y;

            Func<int, int, int> add2 = add.Compile();

            add.Compile();

            var result = add.Compile()(2, 3); 
            result = add2(2, 3);
            result = square(9);

        }


        public static IEnumerable<Car> ProcessCsv(string path) 
        {
            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(l => l.Length > 1)
                        .Select(l => Car.ParseFromCsvLine(l))
                        .ToList();
        }
    }
}

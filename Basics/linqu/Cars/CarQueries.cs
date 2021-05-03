using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Cars
{
    public static class CarQueries
    {
        public static void Queries()
        {
            var cars = ProcessCsvFileWithCarsChainedLinq("fuel.csv");
            var cars2 = ProcessCsvFileWithCarsClassicLinq("fuel.csv");
            var manufacturers = ProcessCsvWithManufacturers("manufacturers.csv");

            //------------- 1. Order by many columns
            var query1A = cars.OrderByDescending(fuel => fuel.Combined)
                                .ThenByDescending(n => n.Name)
                                .Take(10);

            var query1B = (from car in cars
                           orderby car.Combined descending, car.Name descending
                           select car).Take(10);

            foreach (var car in query1A)
            {
                Console.WriteLine($"{car.Name} - {car.Manufacturer}: {car.Combined}");
            }

            //------------- 2. Lambda in first
            var query2 = cars.OrderByDescending(c => c.Combined)
                             .ThenByDescending(c => c.Name)
                             .First(c => c.Manufacturer == "BMW");

            if (query2 != null) Console.WriteLine(query2.Name);

            //------------- 3. Special fileter
            var query3a = cars.Any(c => c.Manufacturer == "Ford");
            var query3b = cars.All(c => c.Manufacturer == "Ford");
            var query3c = cars.Contains(new Car());

            //------------- 4.Anonymous types
            var query4 = cars.Select(c => new { c.Name, c.Highway });
            foreach (var item in query4)
            {
                Console.WriteLine(item.Highway);
            }

            //------------- 5. SelectMany - sequence of sequence
            // wrpowadzenie
            string sample = "Harvey";
            IEnumerable<char> sample2 = "Harvey";

            var query5 = cars.SelectMany(c => c.Name)
                             .OrderBy(c => c);

            foreach (var character in query5)
            {
                Console.WriteLine(character);
            }

            //------------- 6. Inner join
            // query style with anonymous type
            var query6A =
                    from car in cars
                    join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                    orderby car.Combined descending, manufacturer.Country ascending
                    select new
                    {
                        manufacturer.Country,
                        car.Name,
                        car.Combined
                    };

            // extensions
            var query6B =
                cars.Join(manufacturers,
                             c => c.Manufacturer,
                             m => m.Name,
                             (c, m) => new
                             {
                                 c.Name,
                                 c.Combined,
                                 m.Country
                             })
                      .OrderByDescending(c => c.Combined).ThenBy(m => m.Country);

            // query style, join on many keys
            var query6C =
                    from car in cars
                    join manufacturer in manufacturers
                        on new { car.Manufacturer, car.Year }
                        equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                    orderby car.Combined descending, manufacturer.Country ascending
                    select new
                    {
                        car.Name,
                        car.Combined,
                        manufacturer.Country
                    };

            // extension, join on many keys
            var query6D =
                    cars.Join(manufacturers,
                            c => new { c.Manufacturer, c.Year },
                            m => new { Manufacturer = m.Name, m.Year },
                            (c, m) => new { c.Combined, c.Name, m.Country })
                        .OrderByDescending(c => c.Combined).ThenBy(m => m.Country);


            //------------- 7. Grouping
            var query7A =
                from car in cars
                group car by car.Manufacturer.ToLower() into manufacturer
                orderby manufacturer.Key ascending
                select manufacturer;

            var query7B =
                cars.GroupBy(c => c.Manufacturer).OrderBy(g => g.Key);

            foreach (var group in query7A)
            {
                Console.WriteLine($"{group.Key} has {group.Count()} cars and two most esfficient are: ");
                foreach (var car in group.Take(2))
                {
                    Console.WriteLine($"\t{car.Name}: {car.Combined}");
                }
            }

            //------------- 8. Joining and grouping
            var query8A =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                    into carGroup
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };

            var query8B =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                    (m, g) => new
                    {
                        Manufacturer = m,

                    });

            foreach (var group in query8A)
            {
                Console.WriteLine(group.Manufacturer.Country);
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name}\t:{car.Combined}");
                }
            }

            //------------- 9. grouping results
            var query9A =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                    into carGroup
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                } into result
                group result by result.Manufacturer.Country;

            var query9B =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer,
                                    (m, g) => new
                                    {
                                        Manufacturer = m,

                                    })
                              .GroupBy(m => m.Manufacturer.Country);

            foreach (var group in query8A)
            {
                Console.WriteLine(group.Manufacturer.Country);
                foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t{car.Name}\t:{car.Combined}");
                }
            }

            //------------- 10. aggregation
            var query10A =
                    from car in cars
                    group car by car.Manufacturer into carGroup
                    select new
                    {
                        Car = carGroup.Key,
                        Cnt = carGroup.Count(),
                        Max = carGroup.Max(c => c.Combined),
                        Min = carGroup.Min(c => c.Combined),
                        Avg = carGroup.Average(c => c.Combined)
                    } into result
                    orderby result.Max descending
                    select result;

            //extension method but not effective since collection looped 3times
            var query10B =
                    cars.GroupBy(c => c.Manufacturer)
                    .Select(g =>
                    {
                        return new
                        {
                            Car = g.Key,
                            Max = g.Max(c => c.Combined),
                            Min = g.Min(c => c.Combined),
                            Avg = g.Average(c => c.Combined)
                        };
                    });

            //more effective extension with stats class
            var query10C =
                    cars.GroupBy(c => c.Manufacturer)
                    .Select(g =>
                    {
                        var result = g.Aggregate(new CarStats(),
                                                   (acc, c) => acc.Accumulate(c),
                                                   acc => acc.Compute());

                        return new
                        {
                            Car = g.Key,
                            Max = result.Max,
                            Min = result.Min,
                            Avg = result.Avg
                        };
                    })
                    .OrderByDescending(r => r.Max);

            foreach (var manufacturer in query10A)
            {
                Console.WriteLine(manufacturer.Car);
                Console.WriteLine($"sample size: {manufacturer.Cnt}");
                Console.WriteLine($"\tMax: {manufacturer.Max}");
                Console.WriteLine($"\tMin: {manufacturer.Min}");
                Console.WriteLine($"\tAvg: {manufacturer.Avg}");
            }
        }

        private static List<Car> ProcessCsvFileWithCarsChainedLinq(string path)
        {
            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(line => line.Length > 1)
                        .Select(Car.ParseFromCsvLine)
                        .ToList();
        }

        private static List<Car> ProcessCsvFileWithCarsClassicLinq(string path)
        {
            var query = from car in File.ReadAllLines(path).Skip(1)
                        where car.Length > 1
                        select Car.ParseFromCsvLine(car);
            return query.ToList();
        }

        public static IEnumerable<Car> ProcessCsvFileWithCarsWithExtensionMethod(string path)
        {
            return File.ReadAllLines(path).Skip(1).Where(l => l.Length > 1).ToCar();
        }

        private static IEnumerable<Car> ToCar(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var carToParse = line.Split(",");

                yield return new Car()
                {
                    Year = int.Parse(carToParse[0]),
                    Manufacturer = carToParse[1],
                    Name = carToParse[2],
                    Displaycements = double.Parse(carToParse[3]),
                    Cylinders = int.Parse(carToParse[4]),
                    City = int.Parse(carToParse[5]),
                    Highway = int.Parse(carToParse[6]),
                    Combined = int.Parse(carToParse[7])
                };
            }
        }

        public static List<Manufacturer> ProcessCsvWithManufacturers(string path)
        {
            var query = File.ReadAllLines(path)
                            .Where(l => l.Length > 1)
                            .Select(l =>
                            {
                                var columns = l.Split(",");
                                return new Manufacturer()
                                {
                                    Name = columns[0],
                                    Country = columns[1],
                                    Year = int.Parse(columns[2])
                                };
                            });
            return query.ToList();
        }   
    }
}

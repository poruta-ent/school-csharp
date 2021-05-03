using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Car
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displaycements { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }

        internal static Car ParseFromCsvLine(string line)
        {
            var carToParse = line.Split(",");
            return new Car()
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

    public class CarStats
    {
        public CarStats()
        {
            Max = Int32.MaxValue;
            Min = Int32.MinValue;
        }

        public CarStats Accumulate(Car car)
        {
            Count += 1;
            Total += car.Combined;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStats Compute()
        {
            Avg = Total / Count;
            return this;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
        public double Avg { get; set; }
    }
}

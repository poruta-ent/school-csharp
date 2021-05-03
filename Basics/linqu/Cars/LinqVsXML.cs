using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Cars
{
    public static class LinqVsXML
    {
        public static void CreateXMLWithoutAttributes()
        {
            var cars = ProcessCsv("fuel.csv");

            var doc = new XDocument();
            var root = new XElement("Cars");
            foreach(var car in cars)
            {
                var carElement = new XElement("Car");
                var name = new XElement("Name", car.Name);
                var combined = new XElement("Combined", car.Combined);

                carElement.Add(name);
                carElement.Add(combined);
                root.Add(carElement);
            }
            doc.Add(root);
            doc.Save("fuelNoAtt.xml");
        }

        public static void CreateXMLWithAttributes()
        {
            var cars = ProcessCsv("fuel.csv");

            var doc = new XDocument();
            var root = new XElement("Cars");

            var elements = from car in cars
                           select new XElement("Car",
                                        new XAttribute("Name", car.Name),
                                        new XAttribute("Combined", car.Combined),
                                        new XAttribute("Manufacturer", car.Manufacturer));

            root.Add(elements);
            doc.Add(root);
            doc.Save("fuelAtt.xml");
        }

        public static void CreateXMLWithNamespace()
        {
            var cars = ProcessCsv("fuel.csv");

            var document = new XDocument();
            var ns = (XNamespace)"https://pluralsight.com/cars/2016";
            var ex = (XNamespace)"https://pluralsight.com/cars/2016/ex";
            var root = new XElement(ns + "Cars");

            var elements = from car in cars
                                            //inny namespace dla elementów
                           select new XElement(ns + "Car",
                                    new XAttribute("Name", car.Name),
                                    new XAttribute("Combined", car.Combined),
                                    new XAttribute("Manufacturer", car.Manufacturer));

            //dodajemy alias
            root.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
        }

        public static void QueryXML()
        {
            var ns = (XNamespace)"https://pluralsight.com/cars/2016";
            var ex = (XNamespace)"https://pluralsight.com/cars/2016/ex";

            var document = XDocument.Load("fuelAtt.xml");

            //jak są namespaces to trzeba szukać z nimi
            var cars = from element in document.Element(ns + "Cars")?.Elements(ex + "Car")
                                                                   //?? dodaję, żeby where nie działał na nullu                                                        
                                                                   ?? Enumerable.Empty<XElement>()
                       where element.Attribute("Manufacturer")?.Value == "BMW"
                       select element.Attribute("Name").Value;


            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

        }


        public static IEnumerable<Car> ProcessCsv(string path)
        {
            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(l => l.Length > 1)
                        .Select(Car.ParseFromCsvLine)
                        .ToList();
        }
    }
}

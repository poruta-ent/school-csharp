using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSource = new CsvReader(@"C:\repos\School\Pop by Largest Final.csv");
            var listToDisplayA = dataSource.ReadNFirstCountries(10,',');
            foreach (var country in listToDisplayA)
            {
                //Console.WriteLine($"{country.Population:### ### ### ###}\t{country.Name}".Trim());
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
            var listToDisplayB = dataSource.ReadAllCountries(',');
            foreach (var country in listToDisplayB)
            {
                //Console.WriteLine($"{country.Population:### ### ### ###}\t{country.Name}".Trim());
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }
    }
}

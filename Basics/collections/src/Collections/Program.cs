using System;
using System.Linq;

namespace Collections
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        public static void DisplayMenu()
        {
        
            var dataSource = new CsvReader(@"C:\repos\School\Pop by Largest Final.csv");
            
            while (1 == 1)
            {
                Console.WriteLine("1  - Display 10 first countries");
                Console.WriteLine("2  - Display all countries from list");
                Console.WriteLine("3  - Display all countries from dict");
                Console.WriteLine("4  - Display country by code");
                Console.WriteLine("5  - Define N and display N countries");
                Console.WriteLine("6  - Display in batches");
                Console.WriteLine("7  - Display in batches in reverse order");
                Console.WriteLine("8  - Clear all with coma in name");
                Console.WriteLine("9  - Linq");
                Console.WriteLine("10 - Dictionary of countries");
                Console.WriteLine("11 - TTT");
                Console.WriteLine("99 - Clear screen");
                Console.WriteLine("0  - Exit");
            
                if (int.TryParse(Console.ReadLine(), out int selectedOption))
                {
                    switch (selectedOption)
                    {
                        case 0:
                            return;
                        case 1:
                            DisplayNFirstCountries(dataSource);
                            break;
                        case 2:
                            DisplayAllCountriesFromList(dataSource);
                            break;
                        case 3:
                            DisplayAllCountriesFromDict(dataSource);
                            break;
                        case 4:
                            DisplayCountryByCode(dataSource);
                            break;
                        case 5:
                            DisplayCountriesNDefinedByUser(dataSource);
                            break;
                        case 6:
                            DisplayCountriesInBatches(dataSource);
                            break;
                        case 7:
                            DisplayCountriesInBatchesInReverseOrder(dataSource);
                            break;
                        case 8:
                            ClearAllWithComasAndDisplay(dataSource);
                            break;
                        case 9:
                            CollectionsWithLinq(dataSource);
                            break;
                        case 10:
                            DictionaryOfLists(dataSource);
                            break;
                        case 11:
                            PlayTTT();
                            break;
                        case 99:
                            Console.Clear();
                            break;
                        default:
                            System.Console.WriteLine("Provide valid input!");
                            break;        
                    }
                }
                else
                {
                    System.Console.WriteLine("Provide valid input!");
                }
            }
        }

        

        public static void DisplayNFirstCountries(CsvReader dataSource)
        {
            var listToDisplayA = dataSource.ReadNFirstCountries(10,',');
            foreach (var country in listToDisplayA)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public static void  DisplayAllCountriesFromList(CsvReader dataSource)
        {
            var listToDisplayB = dataSource.ReadAllCountriesToList(',');
            foreach (var country in listToDisplayB)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public static void DisplayAllCountriesFromDict(CsvReader dataSource)
        {
            var dictonaryWithCountries = dataSource.ReadAllCountriesToDict(',');
            foreach (var country in dictonaryWithCountries.Values)
            {
                Console.WriteLine(country.Code + " - " + country.Name);
            }
        }

        public static void DisplayCountryByCode(CsvReader dataSource)
        {
            var dictonaryWithCountries = dataSource.ReadAllCountriesToDict(',');
            if (dictonaryWithCountries.TryGetValue(Console.ReadLine(), out var countryByCode))
            {
                Console.WriteLine(countryByCode.Name + " - " + countryByCode.Population);
            }
            else
            {
                Console.WriteLine($"There's no country with such code!");
            }
        }

        public static void DisplayCountriesNDefinedByUser(CsvReader dataSource, bool inBatches)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            var maxCountries = countries.Count;
            var readyToDisplay = false;
            var countriesToDisplay = 0;
            do
            {
                Console.Write("How much: ");
                readyToDisplay = int.TryParse(Console.ReadLine(), out countriesToDisplay);
            } while (!readyToDisplay);

            int i;            
            for (i = 0; i < Math.Min(countriesToDisplay,maxCountries); i++)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(countries[i].Population).PadLeft(15)}: {countries[i].Name}");
            }
            Console.WriteLine($"\n{i} countries displayed.\n");
        }

        public static void DisplayCountriesNDefinedByUser(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            var readyToDisplay = false;
            var countriesToDisplay = 0;
            do
            {
                Console.Write("How much: ");
                readyToDisplay = int.TryParse(Console.ReadLine(), out countriesToDisplay);
            } while (!readyToDisplay);

            int i;            
            for (i = 0; i < Math.Min(countriesToDisplay,countries.Count); i++)
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(countries[i].Population).PadLeft(15)}: {countries[i].Name}");
            }
            Console.WriteLine($"\n{i} countries displayed.\n");
        }

    public static void DisplayCountriesInBatches(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            var readyToDisplay = false;
            var countriesToDisplay = 0;
            do
            {
                Console.Write("How much: ");
                readyToDisplay = int.TryParse(Console.ReadLine(), out countriesToDisplay);
            } while (!readyToDisplay);

            int i;            
            for (i = 0; i < countries.Count; i++)
            {
                if (i > 0 && (i % countriesToDisplay == 0))
                {
                    Console.Write("Press enter to continue or anything else to quit: ");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{i + 1}:\t");
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(countries[i].Population).PadLeft(15)}: {countries[i].Name}");
            }
            Console.WriteLine($"\n{i} countries displayed.\n");
        }

        public static void DisplayCountriesInBatchesInReverseOrder(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            var readyToDisplay = false;
            var countriesToDisplay = 0;
            do
            {
                Console.Write("How much: ");
                readyToDisplay = int.TryParse(Console.ReadLine(), out countriesToDisplay);
            } while (!readyToDisplay);

            int i;            
            for (i = countries.Count - 1; i >= 0; i--)
            {
                if (i <= countries.Count - 1 - countriesToDisplay && ((countries.Count - 1 - i) % countriesToDisplay == 0))
                {
                    Console.Write("Press enter to continue or anything else to quit: ");
                    if (Console.ReadLine() != "")
                    {
                        break;
                    }
                }
                Console.WriteLine($"{i + 1}:\t{PopulationFormatter.FormatPopulation(countries[i].Population).PadLeft(15)}: {countries[i].Name}");
            }
            Console.WriteLine($"\n{i} countries displayed.\n");
        }

        public static void ClearAllWithComasAndDisplay(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            countries.RemoveAll(x=>x.Name.Contains(","));
            foreach (var country in countries)
            {
                Console.WriteLine($"{country.Name}");
            }
        }

        public static void CollectionsWithLinq(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToList(',');
            foreach (var country in countries.Where(x=>x.Population>10000000 && x.Population<30000000).Take(10).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
            }
        }

        public static void DictionaryOfLists(CsvReader dataSource)
        {
            var countries = dataSource.ReadAllCountriesToDictByRegion(',');
            Console.WriteLine("Available regions: ");
            foreach (var region in countries.Keys)
            {
                Console.Write($"{region} ");
            }
            Console.Write("\nType region to display: ");
            var code = Console.ReadLine();
            if (countries.ContainsKey(code))
            {
                foreach (var country in countries[code])
                {
                    Console.WriteLine(country.Name);
                }
            }
        }

        public static void PlayTTT()
        {
            TicTacToeGame TTTplay = new TicTacToeGame();
            TTTplay.PlayGame();
        }

    }
}

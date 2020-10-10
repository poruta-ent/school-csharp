using System;
using System.IO;
using System.Collections.Generic;

namespace Collections
{
    public class CsvReader
    {
        private string _csvFilePath;

        public CsvReader(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public List<Country> ReadAllCountries(char delimeter)
        {
            List<Country> countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                string headerLine = sr.ReadLine();
                while((headerLine = sr.ReadLine())!=null)
                {
                    countries.Add(CountryFromLine(headerLine, delimeter));
                }
            }
            return countries;

        }

        public Country[] ReadNFirstCountries(int nFirstCountries, char delimeter)
        {
            Country[] countries = new Country[nFirstCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                string headerLine = sr.ReadLine();
                for (int i = 0; i < nFirstCountries; i++)
                {
                    countries[i] = CountryFromLine(sr.ReadLine(), delimeter);
                }
            }    
            return countries;
        }

        public Country CountryFromLine(string lineWithCountry, char delimeter)
        {
            string[] countryData = lineWithCountry.Split(delimeter);
            string name;
            string code;
            string region;
            string textPopulation;
            switch(countryData.Length)
            {
                case 4:
                    name = countryData[0];
                    code = countryData[1];
                    region = countryData[2];
                    textPopulation = countryData[3];
                    break;
                case 5:
                    name = (countryData[0] + ", " + countryData[1]).Replace("\"", null).Trim();
                    code = countryData[2];
                    region = countryData[3];
                    textPopulation = countryData[4];
                    break;
                default:
                    throw new Exception($"Can't parse country from {lineWithCountry}");

            }
            
            int.TryParse(textPopulation, out int population);
            return new Country(name, code, region, population);
        }

    }
}
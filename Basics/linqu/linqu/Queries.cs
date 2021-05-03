using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace linqu.queries
{
    public class Movie
    {
        public string Title { get; set; }
        public float Rating { get; set; }
        private int _releaseYear;
        public int ReleaseYear 
        {
            get
            {
                Console.WriteLine($"Getting release year for {Title}.");
                return _releaseYear;
            }
            set
            {
                _releaseYear = value;
            }
        }

        public List<Movie> GetListOfMovies()
        {
            return new List<Movie>()
            {
                new Movie() {Title = "Terminator 2: Judgement Day", Rating = 8.5f, ReleaseYear = 1991},
                new Movie() {Title = "Annabele", Rating = 5.4f, ReleaseYear = 2014},
                new Movie() {Title = "Miami Vice", Rating = 6.0f, ReleaseYear = 2006},
                new Movie() {Title = "Fight Club", Rating = 8.8f, ReleaseYear = 1999}
            };
        }
    }

    public static class LinqQueries
    {
        public static void QueryMovies()
        {

            Console.WriteLine("");
            Console.WriteLine("Linqu:");
            var queryLinq = new Movie().GetListOfMovies()
                                    .Where(m => m.ReleaseYear < 2000)
                                    .OrderByDescending(m => m.Rating);

            foreach (var movie in queryLinq)
            {
                Console.WriteLine($"{movie.Title}\t{movie.ReleaseYear}\t{movie.Rating}");
            }

            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Filter:");
            var queryIEnExt = new Movie().GetListOfMovies()
                                    .Filter(m => m.ReleaseYear < 2000);
            foreach (var movie in queryIEnExt)
            {
                Console.WriteLine($"{movie.Title}\t{movie.ReleaseYear}\t{movie.Rating}");
            }

            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("FilterYield:");
            var queryIEnExt2 = new Movie().GetListOfMovies()
                                    .FilterY(m => m.ReleaseYear < 2000);
            foreach (var movie in queryIEnExt2)
            {
                Console.WriteLine($"{movie.Title}\t{movie.ReleaseYear}\t{movie.Rating}");
            }

            Console.WriteLine("");
            Console.WriteLine("---");
            Console.WriteLine("");

            Console.WriteLine("Top from indefinite loop:");
            var queryIndLoop = LinquExtensions.RandomInfiniteLoop().Take(5);
            foreach (var item in queryIndLoop)
            {
                Console.WriteLine($"{item}");
            }
        }

    }

    public static class LinquExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var result = new List<T>();

            foreach (var item in source)
            {
                if(predicate(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<T> FilterY<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<double> RandomInfiniteLoop()
        {
            var random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }
    }
}

using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var stephBook = new Book("Steph's book");

            while (true)
            {
                Console.Clear();
                Console.Write($"{stephBook.GradesNo} added. Enter new or 'q' to quit and calculate stats: ");
                var input = Console.ReadLine();
                if (input == "q")   
                {
                    break;
                }
                try
                {
                    stephBook.AddGrade(double.Parse(input));    
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            stephBook.ShowStats();

        }
    }
}

using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook stephBook = new DiskBook("Steph's book");
            stephBook.GradeAdded += OnGradeAdded;
            stephBook.GradeAdded += OnGradeAdded;
            stephBook.GradeAdded -= OnGradeAdded;
            stephBook.GradeAdded += OnGradeAdded;

            EnterGrades(stephBook);
            stephBook.GetStats().ShowStats(stephBook.Name);
        }


        private static void EnterGrades(IBook stephBook)
        {
            while (true)
            {
                //Console.Clear();
                //Console.Write($"{stephBook.GradesNo} added. Enter new or 'q' to quit and calculate stats: ");
                Console.Write($"Enter new or 'q' to quit and calculate stats: ");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    stephBook.AddGrade(double.Parse(input));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
       static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("subscribed event");
        }
        
    }
}

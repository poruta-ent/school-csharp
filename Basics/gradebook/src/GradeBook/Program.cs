using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var stephBook = new Book("Steph's book");
            stephBook.AddGrade(12.9);
            stephBook.AddGrade(7.3);
            stephBook.AddGrade(19.7);
            stephBook.AddGrade(2.1);
            stephBook.ShowStats();

        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            Name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Stats GetStats()
        {
            var bookStats = new Stats();
            bookStats.Average = 0.0;
            bookStats.High = 0.0;
            bookStats.Low = 0.0;

            if (grades.Count > 0)
            {
                bookStats.High = double.MinValue;
                bookStats.Low = double.MaxValue;
            
                foreach (var grade in grades)
                {
                    bookStats.High = Math.Max(grade, bookStats.High);
                    bookStats.Low = Math.Min(grade, bookStats.Low);
                    bookStats.Average += grade;
                }

                bookStats.Average /= grades.Count; 

                switch(bookStats.Average)
                {
                    case var d when d > 90.0:
                        bookStats.LetterGrade = 'A';
                        break;
                    case var d when d > 80.0:
                        bookStats.LetterGrade = 'B';
                        break;
                    case var d when d > 70.0:
                        bookStats.LetterGrade = 'C';
                        break;
                    case var d when d > 60.0:
                        bookStats.LetterGrade = 'D';
                        break;
                    case var d when d > 50.0:
                        bookStats.LetterGrade = 'E';
                        break;
                    default:
                        bookStats.LetterGrade = 'F';
                        break;
                }
            }
            return bookStats;
        }

        public void ShowStats()
        {
            var bookStats = GetStats();
            Console.WriteLine($"{Name} stats:");
            Console.WriteLine($"\thighest grade:\t{bookStats.High:N1}");
            Console.WriteLine($"\tlowest grade:\t{bookStats.Low:N1}");
            Console.WriteLine($"\taverage grade:\t{bookStats.Average:N1}");
            Console.WriteLine($"\tsummary letter grade:\t{bookStats.LetterGrade}");
        }

        private List<double> grades;
        public string Name;
        public int GradesNo 
        { 
            get
            {
                return grades.Count;
            }
        }
    }

    

}
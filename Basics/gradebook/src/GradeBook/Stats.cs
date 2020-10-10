using System;

namespace GradeBook
{
    public class Stats
    {
        public Stats()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Accumulated = 0.0;
            Count = 0;
        }
        public double Average
        {
            get
            {
                return Count == 0 ? 0 : Accumulated / Count;
            }
        }
        public double High;
        public double Low;
        public char LetterGrade
        {
            get
            {
                switch(Average)
                {
                    case var d when d > 90.0:
                        return 'A';
                    case var d when d > 80.0:
                        return 'B';
                    case var d when d > 70.0:
                        return 'C';             
                    case var d when d > 60.0:
                        return 'D';
                    case var d when d > 50.0:
                        return 'E';
                    default:
                        return 'F';
                }
            }            
        }
        private double Accumulated;
        private int Count;

        public void RecalculateStats(double newData)
        {
            High = Math.Max(High, newData);
            Low = Math.Min(Low, newData);
            Accumulated += newData;
            Count++;
        }

        public void ShowStats(string statsTitle)
        {
            Console.WriteLine($"{statsTitle} stats:");
            Console.WriteLine($"\thighest grade:\t{High:N1}");
            Console.WriteLine($"\tlowest grade:\t{Low:N1}");
            Console.WriteLine($"\taverage grade:\t{Average:N1}");
            Console.WriteLine($"\tsummary letter grade:\t{LetterGrade}");
        }
    }
}
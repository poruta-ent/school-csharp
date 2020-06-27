using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public double HighGrade() 
        { 
            grades.Sort();
            return grades[grades.Count-1];
        }

        public double LowGrade() 
        { 
            return grades[0];
        }

        public double AverageGrade() 
        { 
            var sum = 0.0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            if (grades.Count>0)
            {
                return sum / grades.Count;
            }
            else
            {
                return 0.0;
            }
            
        }

        public void ShowStats()
        {
            Console.WriteLine($"{name} stats:");
            Console.WriteLine($"\thighest grade:\t{HighGrade():N1}");
            Console.WriteLine($"\tlowest grade:\t{LowGrade():N1}");
            Console.WriteLine($"\taverage grade:\t{AverageGrade():N1}");
        }

        private List<double> grades;
        private string name;
    }

    

}
using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Stats GetStats();
        string Name {get;}
        event GradeAddedDelegate GradeAdded; 
    }
 
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Stats GetStats();  
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            writer.WriteLine(grade);
            if (GradeAdded!=null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        public override Stats GetStats()
        {
            var bookStats = new Stats();
            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    bookStats.RecalculateStats(double.Parse(line));
                    line = reader.ReadLine();
                }
            }
            return bookStats;
        }
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        }
        public override void AddGrade(double grade)
        {
            grades.Add(grade);
            if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }
        public override event GradeAddedDelegate GradeAdded;
        public override Stats GetStats()
        {
            var bookStats = new Stats();
            foreach (var grade in grades)
            {
                bookStats.RecalculateStats(grade);
            }
            return bookStats;
        }

        private List<double> grades;
       
        public int GradesNo 
        { 
            get
            {
                return grades.Count;
            }
        }
    }

    

}
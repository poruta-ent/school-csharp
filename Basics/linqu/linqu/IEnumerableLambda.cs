using System;
using System.Collections.Generic;
using System.Linq;

namespace linqu
{

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public Employee[] GetArrayOfEmps()
        {
            return new Employee[]
            {
                new Employee() {Id = 1, Name = "Stefan"},
                new Employee() {Id = 2, Name = "Marian"},
                new Employee() {Id = 3, Name = "Roman"}
            };
        }

        public List<Employee> GetListOfEmps()
        {
            return new List<Employee>()
            {
                new Employee() {Id = 4, Name = "Tadeusz"},
                new Employee() {Id = 5, Name = "Henry"}
            };
        }

    }

    public static class IEnumerableToLinqu
    {
        public static void IterateThroughIEnumarable()
        {
            IEnumerable<Employee> devs = new Employee().GetArrayOfEmps();
            IEnumerable<Employee> sales = new Employee().GetListOfEmps();

            IEnumerator<Employee> enumerator = devs.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
            enumerator = sales.GetEnumerator();
            while(enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
        }

        public static void FromNamedToLambda()
        {
            IEnumerable<Employee> devs = new Employee().GetArrayOfEmps();

            //named method
            foreach (var dev in devs.Where(NameStartsWithR))
            {
                Console.WriteLine(dev.Name);
            }
            //delegate
            foreach (var dev in devs.Where(delegate (Employee e) { return e.Name.StartsWith("R"); }))
            {
                Console.WriteLine(dev.Name);
            }
            //lambda
            foreach(var dev in devs.Where(e => e.Name.StartsWith("R")))
            {
                Console.WriteLine(dev.Name);
            }
        }

        public static bool NameStartsWithR(Employee e)
        {
            return e.Name.StartsWith("R");
        }
    }
}
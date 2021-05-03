using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Cars
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //LinqVsXML.CreateXMLWithoutAttributes();
            //LinqVsXML.CreateXMLWithAttributes();
            //LinqVsXML.QueryXML();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            LinqVsEntity.InsertCarsDb();
        }
    }
}

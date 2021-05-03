using Shared;
using System;
using System.Collections.Generic;

using static System.Console;


namespace DateReal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IdentifyOverlappingDates.Display();
            Write("\n*************************\n");
            RelativeTimeHowLongAgo.Display();
            Write("\n*************************\n");
            WorkingWithBirthdays.Display();
            Write("\n*************************\n");
            DatesInFiles.SaveSessionsToFile();
        }


    }
}

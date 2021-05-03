using System;
using System.Globalization;

namespace DateTimeFund
{
    class Program
    {
        static void Main(string[] args)
        {
            DateAndTimeBasics();
            DateAndTimeCalcs();
        }

        public static void DateAndTimeBasics()
        {
            var now = DateTime.Now;

            //określanie utc
            var utc = DateTime.UtcNow;
            Console.WriteLine($"a utc:\t\t{utc}");

            //mapowanie now na wybrany timezoe
            TimeZoneInfo sydneyZone = TimeZoneInfo.FindSystemTimeZoneById("E. Australia Standard Time");
            var sydneyTime = TimeZoneInfo.ConvertTime(now, sydneyZone);

            Console.WriteLine($"u nas to:\t{now}");
            Console.WriteLine($"a w sidnej:\t{sydneyTime}");
            Console.WriteLine();

            //DateTimeOffset - powinieneś używać zamiast DateTime
            Console.WriteLine(DateTime.Now);
            Console.WriteLine(DateTimeOffset.Now);
            Console.WriteLine();

            //wylistuj wszyskie time zone z takim samym offsetem do utc jak twoja
            var time = DateTimeOffset.Now;

            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.GetUtcOffset(time) == time.Offset) Console.WriteLine(timeZone.DisplayName);
            }
            Console.WriteLine();

            //wylistuj wszyskie time zone z takim samym offsetem do utc jak ta 10h po twojej
            var time2 = DateTimeOffset.Now.ToOffset(TimeSpan.FromHours(10));

            foreach (var timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                if (timeZone.GetUtcOffset(time) == time2.Offset) Console.WriteLine(timeZone.DisplayName);
            }
            Console.WriteLine();

            //proste parsowanie
            var date = "9/10/2019 10:00:00 PM";
            var parsedDate = DateTime.ParseExact(date, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            Console.WriteLine(parsedDate);
            Console.WriteLine();

            //przykład parsowania do utc
            var date2 = "9/10/2019 10:00:00 PM +2:00";
            var parsedDate2 = DateTime.Parse(date2, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            Console.WriteLine(parsedDate2);
            Console.WriteLine(parsedDate2.Kind);
            Console.WriteLine();

            //do formatu ISO8601
            var date3 = "9/10/2019 10:00:00 PM +2:00";
            var parsedDate3 = DateTimeOffset.Parse(date3, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            parsedDate3 = parsedDate3.ToOffset(TimeSpan.FromHours(10));
            var formattedDate = parsedDate3.ToString("o");
            Console.WriteLine(formattedDate);
            Console.WriteLine();

            //working with utc
            var timeUtc = DateTimeOffset.UtcNow;
            var timeLoc = DateTimeOffset.Now;
            Console.WriteLine(timeUtc.ToLocalTime());
            Console.WriteLine(timeLoc.ToUniversalTime());
            Console.WriteLine();
        }

        public static void DateAndTimeCalcs()
        {
            
            //timespan basics
            var span = new TimeSpan(60, 100, 200);
            Console.WriteLine($"{span.Days} days {span.Hours} hours {span.Minutes} minutes {span.Seconds} seconds");
            Console.WriteLine(span.TotalHours);
            Console.WriteLine(span.TotalMilliseconds);
            Console.WriteLine();

            //kalkulowanie różnic i przypadek .Now
            var start = DateTimeOffset.UtcNow;
            var end = start.AddMinutes(50);
            var endATTENTION = DateTimeOffset.UtcNow.AddMinutes(50); //uwaga zostanie wykonane kilka nanosekund później

            TimeSpan diff1 = start - end;
            TimeSpan diff2 = endATTENTION - start;

            Console.WriteLine(diff1);
            Console.WriteLine(diff2);
            Console.WriteLine(diff1.TotalSeconds);
            Console.WriteLine(diff1.Minutes);
            Console.WriteLine();

        }

        public static Calendar calendar = CultureInfo.InvariantCulture.Calendar;
        public static DateTimeOffset dateForWeekCalc = new DateTimeOffset(2007, 12, 31, 0, 0, 0, TimeSpan.Zero);

        public static void NoOfWeekCalc()
        {
            //using Calendar
            var noOfWeekCalendar = calendar.GetWeekOfYear(dateForWeekCalc.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            Console.WriteLine($"Calendar:\t{noOfWeekCalendar}");

            //iso8601
            var noOfWeekISO8061 = ISOWeek.GetWeekOfYear(dateForWeekCalc.DateTime);
            Console.WriteLine($"ISO8061:\t{noOfWeekISO8061}");

            //iso8601 - obliczone samemu
            //--week starts on Monday and 1st week of the year is the one that contains Thursday
            DayOfWeek day = calendar.GetDayOfWeek(dateForWeekCalc.DateTime);
            var noOfWeekISOself = calendar.GetWeekOfYear(dateForWeekCalc.DateTime, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                noOfWeekISOself = calendar.GetWeekOfYear(dateForWeekCalc.DateTime.AddDays(3),
                                            CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
            Console.WriteLine($"ISOself:\t{noOfWeekISOself}");

            Console.WriteLine();
        }

        public static DateTimeOffset AddingToDate (DateTimeOffset current, int months)
        {
            //żeby nie przeskoczył na następny dzień
            var newContractDate = current.AddMonths(months).AddTicks(-1);

            //tak żeby do końca miesiąca (bo może być przestępny)
            return new DateTimeOffset(newContractDate.Year, newContractDate.Month,
                                    DateTime.DaysInMonth(newContractDate.Year, newContractDate.Month), 23, 59, 59, current.Offset);
        }  
    }
}

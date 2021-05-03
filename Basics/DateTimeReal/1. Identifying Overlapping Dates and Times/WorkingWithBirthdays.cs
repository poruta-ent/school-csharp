using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateReal
{
    public static class WorkingWithBirthdays
    {

        public static int GetSpeakerAge(Speaker speaker)
        {
            var today = DateTime.UtcNow;
            var age = today.Year - speaker.BirthDay.Year;
            
            if (speaker.BirthDay > today.Date.AddYears(-age))
            {
                age = age - 1;
            }

            return age;
        }

        public static int GetDaysUntilNextBirthday(Speaker speaker)
        {
            var today = DateTime.UtcNow.Date;
            var birthday = new DateTime(today.Year, speaker.BirthDay.Month, 1).AddDays(speaker.BirthDay.Day - 1);

            if (today > birthday)
            {
                birthday = new DateTime(today.Year + 1, speaker.BirthDay.Month, 1).AddDays(speaker.BirthDay.Day - 1); 
            }

            return (int)(birthday - today).TotalDays;
        }

        public static void Display()
        {
            var speaker = new Speaker().GetSpeaker();
            Console.WriteLine(GetSpeakerAge(speaker));

            var daysToBirthday = GetDaysUntilNextBirthday(speaker);
            if (daysToBirthday == 0)
            {
                Console.WriteLine("HB!");
            }
            else
            {
                var dayOrDays = "days";
                if (daysToBirthday == 1)
                {
                    dayOrDays = "day";
                }
                Console.WriteLine($"Don't forget to buy a cake in {daysToBirthday} {dayOrDays}");
            }
        }

    }
}

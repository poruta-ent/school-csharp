using System;
using System.Collections.Generic;
using Shared;

using static System.Console;

namespace DateReal
{
    public static class IdentifyOverlappingDates
    {
        public static List<Session> GetOverlappingSessions(Speaker speaker, Session currentSession)
        {
            var start = currentSession.ScheduledAt;
            var end = currentSession.ScheduledAt.Add(currentSession.Length);

            var overlappingSessions = new List<Session>();

            foreach (var session in speaker.Sessions)
            {
                if (session.Id == currentSession.Id) continue;

                if ((session.ScheduledAt > start) && (session.ScheduledAt < end))
                {
                    overlappingSessions.Add(session);
                }
                if ((session.ScheduledAt.Add(session.Length) > start) && (session.ScheduledAt.Add(session.Length) < end))
                {
                    overlappingSessions.Add(session);
                }
            }
            return overlappingSessions;
        }

        public static void PrintWarning(string message)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(message);

            Console.ResetColor();
        }
                
        public static void Display()
        {
            var speaker = new Speaker().GetSpeaker();

            WriteLine($"Sessions for: {speaker.Name}");
            WriteLine("-----------------------------------------");

            foreach (var session in speaker.Sessions)
            {
                WriteLine(session.Title);
                WriteLine($"Starts at:\t {session.ScheduledAt}");
                WriteLine($"Ends at:\t {session.ScheduledAt.Add(session.Length)}");

                var overlappingSessions = GetOverlappingSessions(speaker, session);
                foreach (var overlappingSession in overlappingSessions)
                {
                    PrintWarning($"OVELAPPING SESSION: {overlappingSession.Title}");
                }

                WriteLine("");
            }
        }
    }
}

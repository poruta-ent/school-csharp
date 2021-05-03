using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace DateReal
{
    public static class RelativeTimeHowLongAgo
    {
        public static bool DoesSpeakerHaveOtherSessions (Speaker speaker, Session currentSession, DateComparison when)
        {
            return speaker.Sessions.Any(
                s => s.Id != currentSession.Id &&
                s.ScheduledAt.CompareTo(currentSession.ScheduledAt) == (int)when
                );
        }

        public static TimeSpan GetTimeUntilNextSession (Speaker speaker, Session currentSession)
        {
            var nextSession = speaker.Sessions.OrderBy(s => s.ScheduledAt)
                                .FirstOrDefault(s => s.Id != currentSession.Id && 
                                                    s.ScheduledAt >= currentSession.ScheduledAt.Add(currentSession.Length));
            
            if (nextSession == null)
            {
                return TimeSpan.MinValue;
            }

            return nextSession.ScheduledAt - currentSession.ScheduledAt.Add(currentSession.Length);
        }

        public static TimeSpan TimeSinceSubmission(Session session)
        {
            return session.SubmittedAt - DateTimeOffset.UtcNow.ToOffset(session.SubmittedAt.Offset);
        }


        public static void Display()
        {
            var speaker = new Speaker().GetSpeaker();

            Console.WriteLine($"Sessions for: {speaker.Name}");
            Console.WriteLine("-----------------------------");

            foreach (var session in speaker.Sessions)
            {
                Console.WriteLine($"{session.Title}");
                Console.WriteLine($"Starts: {session.ScheduledAt}");
                Console.WriteLine($"Ends: {session.ScheduledAt.Add(session.Length)}");

                Console.WriteLine($"Days since submission: {Math.Round(Math.Abs(TimeSinceSubmission(session).TotalDays),1)}");
                Console.WriteLine($"Earlier sessions: {DoesSpeakerHaveOtherSessions(speaker, session, DateComparison.Earlier)}");
                Console.WriteLine($"Later sessions: {DoesSpeakerHaveOtherSessions(speaker, session, DateComparison.Later)}");

                var timeUntilNextSession = GetTimeUntilNextSession(speaker, session);
                Console.WriteLine($"Time to next session: {timeUntilNextSession}");

                if (timeUntilNextSession != TimeSpan.MinValue &&
                        session.ScheduledAt.Add(session.Length).DayOfYear != 
                        session.ScheduledAt.Add(session.Length).Add(timeUntilNextSession).DayOfYear)
                {
                    Console.WriteLine("---------NO MORE SESSION TODAY-----------");
                }
                Console.WriteLine();
            }
        }

    }

    public enum DateComparison
    {
        Earlier = -1,
        TheSame = 0,
        Later = 1
    }
}

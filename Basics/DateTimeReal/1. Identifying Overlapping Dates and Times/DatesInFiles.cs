using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DateReal
{
    public static class DatesInFiles
    {
        public static void SaveSessionsToFile()
        {
            var speaker = new Speaker().GetSpeaker();

            var userOffset = TimeSpan.FromHours(-7);
            var csv = "Title,Speaker,Length,ScheduledAt" + Environment.NewLine;

            foreach (var session in speaker.Sessions)
            {
                csv += $"{session.Title},{speaker.Name},{session.Length},{session.ScheduledAt.ToOffset(userOffset):O}{Environment.NewLine}";
            }

            File.WriteAllText($"{speaker.Name}.csv",csv);
        }
    }
}

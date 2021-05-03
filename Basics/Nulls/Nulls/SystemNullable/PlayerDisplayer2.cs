using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public static class PlayerDisplayer2
    {
        public static void DisplayPlayerDetails(PlayerCharacter2 player)
        {

            //przykłady sprawdzania nulla
            int days_a = player.DaysSinceLastLogin.GetValueOrDefault(-1);
            int days_b = player.DaysSinceLastLogin.HasValue ? player.DaysSinceLastLogin.Value : -1;
            int days_c = player.DaysSinceLastLogin ?? -1;

            //dodatkowe sprawdzenie czy obiekt istnieje
            int days_d = player?.DaysSinceLastLogin ?? -1;


            //arrays
            PlayerCharacter2[] players = new PlayerCharacter2[3]
            {
                new PlayerCharacter2 { Name = "XYZ" },
                new PlayerCharacter2(),
                null
            };

            string p0 = players?[0]?.Name;
            string p1 = players?[1]?.Name;
            string p2 = players?[2]?.Name;


            if (string.IsNullOrEmpty(player.Name))
            {
                Console.WriteLine($"Player John Doe info:");
            }
            else
            {
                Console.WriteLine($"Player {player.Name} info:");
            }

            if (player.BirthDate == null)
            {
                Console.WriteLine($"Birthdate: n/a");
            }
            else
            {
                Console.WriteLine($"Birthdate: {player.BirthDate}");
            }
            
            if (!player.DaysSinceLastLogin.HasValue)
            {
                Console.WriteLine($"Days since last login: player has not logged yet");
            }
            else
            {
                Console.WriteLine($"Days since last login: {player.DaysSinceLastLogin.Value}"); //.Value zamienia na int
            }

            if (player.IsNoob == null)
            {
                Console.WriteLine("Player newbity status is unknown.");
            }
            else if (player.IsNoob == true)
            {
                Console.WriteLine("Player is a newbie.");
            }
            else
            {
                Console.WriteLine("Player is experienced.");
            }


        }
    }
}

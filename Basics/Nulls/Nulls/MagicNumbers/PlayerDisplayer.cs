using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public static class PlayerDisplayer
    {
        public static void DisplayPlayerDetails(PlayerCharacter player)
        {
            Console.WriteLine($"Player {player.Name} info:");
            
            if (player.BirthDate == DateTime.MinValue)
            {
                Console.WriteLine($"Birthdate: n/a");
            }
            else
            {
                Console.WriteLine($"Birthdate: {player.BirthDate}");
            }

            if (player.DaysSinceLastLogin == -1)
            {
                Console.WriteLine($"Days since last login: player has not logged yet");
            }
            else
            {
                Console.WriteLine($"Days since last login: {player.DaysSinceLastLogin}");
            }
        }
    }
}

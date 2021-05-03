using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorNulls
{
    public static class PlayerDisplayer
    {
        public static void Write(PlayerCharacter? player)
        {
            if (player is null)
            {
                Console.WriteLine("No player specified.");
                return;
            }

            Console.WriteLine(player.Name);

            int days = player.DateSinceLastLogin ?? -1;
            Console.WriteLine($"{days} days since last login.");

            if (player.BirthDate == null)
            {
                Console.WriteLine("No DoB specified!");
            }
            else
            {
                Console.WriteLine(player.BirthDate);
            }


        }
    }
}

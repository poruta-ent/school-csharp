using System;

namespace RefactorNulls
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerCharacter?[] players =
            {
                new PlayerCharacter("Olek"),
                new PlayerCharacter("Romek"),
                new PlayerCharacter(null),
                null
            };

            PlayerDisplayer.Write(players[0]);
            PlayerDisplayer.Write(players[1]);
            PlayerDisplayer.Write(players[2]);
            PlayerDisplayer.Write(players[3]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{ 
    public class PlayerCharacter4
    {
        private readonly SpecialDefence _specialDefence;

        public PlayerCharacter4(SpecialDefence specialDefense)
        {
            _specialDefence = specialDefense;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;

        public void Hit(int damage) //muszę obsłużyć nulla
        {
            int damageReduction = _specialDefence.CalculationDamageReduction(20);
            int totalDamage = damage - damageReduction;
            Health -= totalDamage;

            Console.WriteLine($"Damage {damage} was reduced by {damageReduction} so the total taken is: {totalDamage}");
        }
    }

    public static class SetGame2
    {
      
        public static List<PlayerCharacter4> GetPlayersNullPattern()
        {
            return new List<PlayerCharacter4>()
            {
                new PlayerCharacter4(new DiamondSkinDefence2()) { Name = "Suchy" },
                new PlayerCharacter4(new IronBoneDefence2()) { Name = "Haku" },
                new PlayerCharacter4(SpecialDefence.Null ) { Name = "Bolo" }
            };
        }

        public static void RunGame()
        {
            //var players = GetPlayersWithoutNullPattern();
            var players = GetPlayersNullPattern();
            foreach (var player in players)
            {
                //player.HitWithoutNullPattern(20);
                player.Hit(20);
            }
        }
    }
}

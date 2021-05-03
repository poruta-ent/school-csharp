using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public class PlayerCharacter3
    {
        private readonly ISpecialDefence _specialDefence;

        public PlayerCharacter3(ISpecialDefence specialDefense)
        {
            _specialDefence = specialDefense;
        }

        public string Name { get; set; }
        public int Health { get; set; } = 100;

        public void HitWithoutNullPattern(int damage) //muszę obsłużyć nulla
        {
            int damageReduction = 0;

            if (_specialDefence!=null)
            {
                damageReduction = _specialDefence.CalculateDamageReduction(damage);
            }
            int totalDamage = damage - damageReduction;
            Health -= totalDamage;

            Console.WriteLine($"Damage {damage} was reduced by {damageReduction} so the total taken is: {totalDamage}");
        }

        public void HitNullPattern(int damage)
        {
            
            int totalDamage = damage - _specialDefence.CalculateDamageReduction(damage);
            Health -= totalDamage;

            Console.WriteLine($"Damage {damage} was reduced by {_specialDefence.CalculateDamageReduction(damage)} so the total taken is: {totalDamage}");
        }

    }

    public static class SetGame
    {
        public static List<PlayerCharacter3> GetPlayersWithoutNullPattern()
        {
            return new List<PlayerCharacter3>()
            {
                new PlayerCharacter3(new DiamondSkinDefence()) { Name = "Suchy" },
                new PlayerCharacter3(new IronBoneDefence()) { Name = "Haku" },
                new PlayerCharacter3(null) { Name = "Bolo" }
            };
        }

        public static List<PlayerCharacter3> GetPlayersNullPattern()
        {
            return new List<PlayerCharacter3>()
            {
                new PlayerCharacter3(new DiamondSkinDefence()) { Name = "Suchy" },
                new PlayerCharacter3(new IronBoneDefence()) { Name = "Haku" },
                new PlayerCharacter3(new NullDefence()) { Name = "Bolo" }
            };
        }

        public static void RunGame()
        {
            //var players = GetPlayersWithoutNullPattern();
            var players = GetPlayersNullPattern();
            foreach (var player in players)
            {
                //player.HitWithoutNullPattern(20);
                player.HitNullPattern(20);
            }
        }
    }
}

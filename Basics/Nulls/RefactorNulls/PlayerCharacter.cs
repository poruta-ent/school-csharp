using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorNulls
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? DateSinceLastLogin { get; set; }
        public bool? IsNoob { get; set; }

        public PlayerCharacter(string name)
        {
            Name = name;
        }
    }
}

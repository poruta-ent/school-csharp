using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public class PlayerCharacter
    {
        public string Name { get; set; }
        public int DaysSinceLastLogin { get; set; }
        public DateTime BirthDate { get; set; }

        public PlayerCharacter()
        {
            DaysSinceLastLogin = -1;
            BirthDate = DateTime.MinValue;
        }
    }
}

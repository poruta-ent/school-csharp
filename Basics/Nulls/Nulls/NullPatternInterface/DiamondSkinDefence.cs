using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public class DiamondSkinDefence : ISpecialDefence
    {
        public int CalculateDamageReduction(int totalDamage)
        {
            return 5;
        }
    }
}

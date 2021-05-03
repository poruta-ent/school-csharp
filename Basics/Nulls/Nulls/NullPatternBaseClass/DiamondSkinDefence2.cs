using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public class DiamondSkinDefence2 : SpecialDefence
    {
        public override int CalculationDamageReduction(int damage)
        {
            return 5;
        }
    }
}

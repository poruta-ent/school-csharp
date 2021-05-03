using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public class IronBoneDefence2 : SpecialDefence
    {
        public override int CalculationDamageReduction(int damage)
        {
            return 1;
        }
    }
}

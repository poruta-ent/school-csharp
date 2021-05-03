using System;
using System.Collections.Generic;
using System.Text;

namespace Nulls
{
    public abstract class SpecialDefence
    {
        public abstract int CalculationDamageReduction(int damage);

        //tworzę singletona
        public static SpecialDefence Null { get; } = new NoDefence();

        private class NoDefence : SpecialDefence
        {
            public override int CalculationDamageReduction(int damage)
            {
                return 0;
            }
        }
    }
}

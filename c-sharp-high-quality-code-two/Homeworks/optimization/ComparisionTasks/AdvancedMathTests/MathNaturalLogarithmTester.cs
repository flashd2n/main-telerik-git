using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMathTests
{
    public static class MathNaturalLogarithmTester
    {
        public static void MathNaturalLogarithmFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;
                float floatResult = (float)Math.Log(floatNumber);
            }
        }

        public static void MathNaturalLogarithmDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;
                double doubleResult = Math.Log(doubleNumber);
            }
        }

        public static void MathNaturalLogarithmDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;
                double currentDecimalNumber = (double)decimalNumber;
                decimal decimalResult = (decimal)Math.Log(currentDecimalNumber);
            }
        }
    }
}

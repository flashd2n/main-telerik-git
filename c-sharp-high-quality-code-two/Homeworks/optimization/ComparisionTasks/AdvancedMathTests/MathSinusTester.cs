using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMathTests
{
    public static class MathSinusTester
    {
        public static void MathSinusFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;
                float floatResult = (float)Math.Sin(floatNumber);
            }
        }

        public static void MathSinusDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;
                double doubleResult = Math.Sin(doubleNumber);
            }
        }

        public static void MathSinusDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;
                double currentDecimalNumber = (double)decimalNumber;
                decimal decimalResult = (decimal)Math.Sin(currentDecimalNumber);
            }
        }
    }
}

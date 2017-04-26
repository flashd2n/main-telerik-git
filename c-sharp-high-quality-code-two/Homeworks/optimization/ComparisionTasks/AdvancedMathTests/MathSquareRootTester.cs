using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMathTests
{
    public static class MathSquareRootTester
    {
        public static void MathSquareRootFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;
                float floatResult = (float)Math.Sqrt(floatNumber);
            }
        }

        public static void MathSquareRootDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;
                double doubleResult = Math.Sqrt(doubleNumber);
            }
        }

        public static void MathSquareRootDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;
                double currentDecimalNumber = (double)decimalNumber;
                decimal decimalResult = (decimal)Math.Sqrt(currentDecimalNumber);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
{

    public static class MultiplyTester
    {
        private const int NUMBER_OF_STEPS = 30;

        public static void MultiplyInteger()
        {
            checked
            {
                int integerNumber = 1;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    integerNumber *= 2;
                }
            }
        }

        public static void MultiplyLong()
        {
            checked
            {
                long longNumber = 1L;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    longNumber *= 2;
                }
            }
        }

        public static void MultiplyFloat()
        {
            checked
            {
                float floatNumber = 1.0f;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    floatNumber *= 2;
                }
            }
        }

        public static void MultiplyDouble()
        {
            checked
            {
                double doubleNumber = 1.0d;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    doubleNumber *= 2;
                }
            }
        }

        public static void MultiplyDecimal()
        {
            checked
            {
                decimal decimalNumber = 1.0m;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    decimalNumber *= 2;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
{

    public static class SubtractTester
    {
        private const int NUMBER_OF_STEPS = 60000;

        public static void SubtractInteger()
        {
            checked
            {
                int integerNumber = 20000000;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    integerNumber -= i;
                }
            }
        }

        public static void SubtractLong()
        {
            checked
            {
                long longNumber = 20000000L;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    longNumber -= i;
                }
            }
        }

        public static void SubtractFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    floatNumber -= i;
                }
            }
        }

        public static void SubtractDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    doubleNumber -= i;
                }
            }
        }

        public static void SubtractDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    decimalNumber -= i;
                }
            }
        }
    }
}

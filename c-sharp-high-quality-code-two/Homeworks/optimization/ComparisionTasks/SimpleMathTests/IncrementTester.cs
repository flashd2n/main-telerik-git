using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
{

    public static class IncrementTester
    {
        private const int NUMBER_OF_STEPS = 20000000;

        public static void IncrementInteger()
        {
            checked
            {
                int integerNumber = 20000000;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    integerNumber++;
                }
            }
        }

        public static void IncrementLong()
        {
            checked
            {
                long longNumber = 20000000L;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    longNumber++;
                }
            }
        }

        public static void IncrementFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    floatNumber++;
                }
            }
        }

        public static void IncrementDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    doubleNumber++;
                }
            }
        }

        public static void IncrementDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    decimalNumber++;
                }
            }
        }
    }
}

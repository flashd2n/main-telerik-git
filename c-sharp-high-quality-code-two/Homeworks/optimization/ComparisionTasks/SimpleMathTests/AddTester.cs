using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
{

    public static class AddTester
    {
        private const int NUMBER_OF_STEPS = 60000;

        public static void AddInteger()
        {
            checked
            {
                int integerNumber = 0;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    integerNumber += i;
                }
            }
        }

        public static void AddLong()
        {
            checked
            {
                long longNumber = 0L;

                for (var i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    longNumber += i;
                }
            }
        }

        public static void AddFloat()
        {
            checked
            {
                float floatNumber = 0.0f;

                for (var i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    floatNumber += i;
                }
            }
        }

        public static void AddDouble()
        {
            checked
            {
                double doubleNumber = 0.0d;

                for (var i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    doubleNumber += i;
                }
            }
        }

        public static void AddDecimal()
        {
            checked
            {
                decimal decimalNumber = 0.0m;

                for (var i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    decimalNumber += i;
                }
            }
        }
    }
}

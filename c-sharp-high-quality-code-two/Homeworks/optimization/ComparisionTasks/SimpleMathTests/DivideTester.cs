using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathTests
{

    public static class DivideTester
    {
        private const int NUMBER_OF_STEPS = 20000000;

        public static void DivideInteger()
        {
            checked
            {
                int integerNumber = 20000000;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    integerNumber /= 2;
                }
            }
        }

        public static void DivideLong()
        {
            checked
            {
                long longNumber = 20000000L;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    longNumber /= 2;
                }
            }
        }

        public static void DivideFloat()
        {
            checked
            {
                float floatNumber = 20000000.0f;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    floatNumber /= 2;
                }
            }
        }

        public static void DivideDouble()
        {
            checked
            {
                double doubleNumber = 20000000.0d;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    doubleNumber /= 2;
                }
            }
        }

        public static void DivideDecimal()
        {
            checked
            {
                decimal decimalNumber = 20000000.0m;

                for (int i = 0; i < NUMBER_OF_STEPS; i++)
                {
                    decimalNumber /= 2;
                }
            }
        }
    }
}

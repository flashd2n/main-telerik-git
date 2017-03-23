using System;

namespace Abstraction
{
    internal static class Validation
    {
        public static void ValidateNonZeroNonNegativeDouble(double number, string parameterName)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"The {parameterName} cannot be zero or negative");
            }
        }
    }
}

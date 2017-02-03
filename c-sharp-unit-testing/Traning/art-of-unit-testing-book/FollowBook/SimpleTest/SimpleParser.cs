using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public static class SimpleParser
    {
        public static int ParseAndSum(string numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            } else if (!numbers.Contains(","))
            {
                return int.Parse(numbers);
            }
            else
            {
                throw new ArgumentException("I can only handle 0 or 1 numbers");
            }
        }
    }
}

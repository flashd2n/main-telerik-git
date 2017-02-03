using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public static class SimpleParserTest
    {
        public static void TestReturnsZeroWhenEmptyString()
        {

            try
            {
                int result = SimpleParser.ParseAndSum(string.Empty);
                if (result != 0)
                {
                    Console.WriteLine("SimpleParser class should have returned 0 when passed an empty string");
                }
                if (result == 0)
                {
                    Console.WriteLine("Test passed");
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }


        }


    }
}

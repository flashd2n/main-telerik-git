using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCombinations
{
    public class Startup
    {
        static void Main()
        {

            GenerateBits(8, "");

        }

        public static void GenerateBits(int n, string output)
        {
            if (n == 0)
            {
                Console.WriteLine(output);
                return;
            }

            GenerateBits(n - 1, output + "0");
            GenerateBits(n - 1, output + "1");

        }
    }
}

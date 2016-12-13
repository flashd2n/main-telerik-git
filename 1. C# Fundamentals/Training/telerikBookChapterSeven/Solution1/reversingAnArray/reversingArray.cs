using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversingAnArray
{
    class reversingArray
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };

            int length = array.Length;

            int[] reversed = new int[length];

            for (int index = 0; index < length; index++)
            {
                reversed[index] = array[length - 1 - index];
            }

            for (int index = 0; index < length; index++)
            {
                Console.Write("{0}{1}", reversed[index], index != length - 1 ? " " : "\n");
            }

        }
    }
}

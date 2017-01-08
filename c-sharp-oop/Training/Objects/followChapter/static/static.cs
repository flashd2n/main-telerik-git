using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @static
{
    class Program
    {
        static void Main(string[] args)
        {            

            for (int i = 5; i < 8; i++)
            {

                Console.WriteLine(Sequence.NextValue(i));
                Console.WriteLine(Sequence.NextValue());
            }


        }
    }

    public class Sequence
    {
        private static int currentValue = 0;

        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }

        public static int NextValue(int value)
        {
            value++;
            return value;
        }
    }
}

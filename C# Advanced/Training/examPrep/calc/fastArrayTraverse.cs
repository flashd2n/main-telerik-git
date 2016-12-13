using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    class fastArrayTraverse
    {
        static void Main(string[] args)
        {

            int[] input = new int[3] { 12, 32, 44 };
            int position = 0;

            for (int i = 0; i < 20; i++)
            {
                position = i % input.Length;
                Console.WriteLine(input[position]);


            }

            Console.WriteLine("==================");

            for (int i = 20; i >= 0; i--)
            {

                position = i % input.Length;

                if (position < 0)
                {
                    position += input.Length;
                }

                Console.WriteLine(input[position]);

            }


        }
    }
}

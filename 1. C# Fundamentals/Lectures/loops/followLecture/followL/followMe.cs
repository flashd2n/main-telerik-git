using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace followL
{
    class followMe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int currentNumber = 1;

            while (currentNumber <= n)
            {
                sum = sum + currentNumber;
                Console.WriteLine(sum);
                ++currentNumber;
            }
            Console.WriteLine(sum);

        }
    }
}

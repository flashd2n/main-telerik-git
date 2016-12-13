using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primeCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int possibleDivide = 2;
            bool isPrime = true;

            while (isPrime && possibleDivide < n)
            {
                if (n % possibleDivide == 0)
                {
                    Console.WriteLine("not prime ");
                    isPrime = false;
                }

                possibleDivide++;
            }


        }
    }
}

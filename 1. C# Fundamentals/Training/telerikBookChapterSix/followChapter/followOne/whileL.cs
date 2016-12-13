using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace followOne
{
    class fOne
    {
        static void Main(string[] args)
        {
            //int counter = 0;

            //while (counter <= 9)
            //{
            //    Console.WriteLine("Number: {0}", counter);
            //    counter++;
            //}

            int n = int.Parse(Console.ReadLine());

            //int num = 1;
            //int sum = 1;
            //Console.Write("The sum 1");
            //while (num < n)
            //{
            //    num++;
            //    sum += num;
            //    Console.Write(" + " + num);
            //}
            //Console.Write(" = " + sum);

            //int divider = 2;
            //int maxDivider = (int)Math.Sqrt(n);
            //bool prime = true;

            //while (prime && (divider <= maxDivider))
            //{
            //    if (n % divider == 0)
            //    {
            //        prime = false;
            //    }
            //    divider++;
            //}
            //Console.WriteLine(prime);

            decimal factorial = 1;

            while (true)
            {
                if (n <= 1)
                {
                    break;
                }
                factorial *= n;
                n--;

            }
            Console.WriteLine("n! = " + factorial);



        }
    }
}

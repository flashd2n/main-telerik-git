using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnomMethodsLambda
{
    //delegate void Operation(int number);

    class Startup
    {
        static void Main()
        {
            //Operation op = DoubleIt;

            //Operation op = delegate (int number) { Console.WriteLine($"{number} X 2 = {number * 2}"); };

            //Operation op = (int number) => { Console.WriteLine($"{number} X 2 = {number * 2}"); };
            
            Action<int> op = (int number) => { Console.WriteLine($"{number} X 2 = {number * 2}"); };
            
            op(2);

            Func<int, int> DoubleIt = (int number) => { return number * 2; };

            int result = DoubleIt(2);

            Console.WriteLine(result);
        }

        //static void DoubleIt(int number)
        //{
        //    Console.WriteLine($"{number} X 2 = {number * 2}");
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTwo
{
    delegate void Operation(int num);

    class Startup
    {
        static void Main()
        {
            Operation ops = DoubleIt;
            ops += HalfIt;
            ops += HalfIt;
            ops += HalfIt;
            ops += HalfIt;

            ops -= DoubleIt;
            ops -= HalfIt;

            var allOps = ops.GetInvocationList(); // put all current methonds from the chain in the a Delegate[]

            ExecuteOperation(2, ops);

        }

        static void DoubleIt(int number)
        {
            Console.WriteLine($"{number} X 2 = {number * 2}");
        }

        static void HalfIt(int number)
        {
            Console.WriteLine($"{number} / 2 = {number / 2D}");
        }

        static void ExecuteOperation(int number, Operation ops)
        {
            ops(number);
        }
    }

}

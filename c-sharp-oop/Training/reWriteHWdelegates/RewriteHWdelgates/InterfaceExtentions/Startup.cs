using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtentions
{
    class Startup
    {
        static void Main()
        {
            var myList = new List<double>() { 1.1, 2.2, 3.3};
            var sum = myList.CalcSum();
            Console.WriteLine(sum);

            var product = myList.CalcProduct();
            Console.WriteLine(product);

            var average = myList.GetAverage();
            Console.WriteLine(average);

            var min = myList.GetMin();
            Console.WriteLine(min);

            var max = myList.GetMax();
            Console.WriteLine(max);
        }
    }
}

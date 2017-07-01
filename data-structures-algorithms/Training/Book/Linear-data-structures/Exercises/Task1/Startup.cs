using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Startup
    {
        static void Main()
        {
            var numCollection = new List<int>();

            var input = Console.ReadLine();

            var sum = 0;

            while (input != string.Empty)
            {
                var number = int.Parse(input);

                numCollection.Add(number);

                sum += number;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum: {sum} | Average: {sum / numCollection.Count()}");

        }
    }
}

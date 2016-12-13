using System;

namespace taskTwelve
{
    class taskTwelve
    {
        static void Main()
        {
            long input = long.Parse(Console.ReadLine());
            string outputOne = string.Format("{0, 15}", input);
            string outputTwo = string.Format("{0, 15:X}", input);
            string outputThree = string.Format("{0, 15:P}", input);
            string outputFour = string.Format("{0, 15:C}", input);
            string outputFive = string.Format("{0, 15:E}", input);

            Console.WriteLine(outputOne);
            Console.WriteLine(outputTwo);
            Console.WriteLine(outputThree);
            Console.WriteLine(outputFour);
            Console.WriteLine(outputFive);
        }
    }
}

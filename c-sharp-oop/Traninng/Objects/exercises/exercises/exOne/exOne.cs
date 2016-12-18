using System;

namespace exOne
{
    class exOne
    {
        static void Main()
        {
            bool isLeap = DateTime.IsLeapYear(int.Parse(Console.ReadLine()));
            Console.WriteLine(isLeap);
        }
    }
}

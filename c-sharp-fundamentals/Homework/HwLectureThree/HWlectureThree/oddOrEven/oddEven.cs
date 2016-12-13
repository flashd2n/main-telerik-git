using System;

namespace oddOrEven
{
    class oddEven
    {
        static void Main(string[] args)
        {
            int check = int.Parse(Console.ReadLine());
            if ((check % 2) == 0)
            {
                Console.WriteLine("even " + check);
            }
            else
            {
                Console.WriteLine("odd " + check);
            }
        }
    }
}

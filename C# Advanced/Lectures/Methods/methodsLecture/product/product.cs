using System;

namespace product
{
    class product
    {
        static int Product(params int[] numbers)
        {
            int product = 1;

            foreach (int n in numbers)
            {
                product *= n;
            }

            return product;
        }


        static void Main()
        {

            int p1 = Product(1, 2, 3, 4, 5);
            int p2 = Product(12, 312);
            int p3 = Product(32, 312, 31);


        }
    }
}

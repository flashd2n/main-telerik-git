using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numberPages
{
    class numPages
    {
        static void Main(string[] args)
        {
            int totalDigits = int.Parse(Console.ReadLine());
            int totalPages = 0;

            for (int i = 1; i <= totalDigits; i++)
            {
                if (totalPages <=9)
                {
                    totalPages = totalPages + i;
                } else if (totalPages >= 10)
                {
                    ++totalPages;
                    --totalDigits;
                }
                

            }

            Console.WriteLine(totalPages);

        }
    }
}

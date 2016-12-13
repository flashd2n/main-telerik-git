using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            int sum = 0;
            for (int i = 0; i <= 2; i++)
                while (sum < 10)
                    sum++; sum++;


            Console.WriteLine(sum);

        }
    }
}

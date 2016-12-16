using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main()
        {
            string temp = Console.ReadLine();


            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '+')
                {
                    temp = temp.Insert(i, " ");
                    temp = temp.Insert(i + 2, " ");
                    i += 3;
                }
            }
            Console.WriteLine(temp);

        }
    }
}

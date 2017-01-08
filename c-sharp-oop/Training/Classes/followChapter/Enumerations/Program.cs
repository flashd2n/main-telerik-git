using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerations
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Days.Sun);
            Console.WriteLine((int)Days.Sun);
            Console.WriteLine("Some converstion");
            string sunday = Days.Sun.ToString();
            int sundayNum = (int)Days.Sun;
            Console.WriteLine(sunday);
            Console.WriteLine(sundayNum);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEight
{
    class exerEight
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());


            //int levelOne = Math.Max(d , e);
            //int levelTwo = Math.Max(levelOne, c);
            //int levelThree = Math.Max(levelTwo, b);
            //int max = Math.Max(levelThree, a);


            //Console.WriteLine(max);

            Console.WriteLine(Math.Max((Math.Max((Math.Max((Math.Max(d, e)), c)), b)), a));

        }
    }
}

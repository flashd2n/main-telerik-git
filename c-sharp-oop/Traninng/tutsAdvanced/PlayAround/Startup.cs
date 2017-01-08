using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayAround
{
    class Startup
    {
        static void Main()
        {
            //var someClassData = new SomeClass();
            //someClassData.IntData = int.Parse(Console.ReadLine());
            //someClassData.StringData = Console.ReadLine();

            var someClassData = new SomeClass()
            {
                IntData = int.Parse(Console.ReadLine()),
                StringData = Console.ReadLine()
            };


        }
    }
}

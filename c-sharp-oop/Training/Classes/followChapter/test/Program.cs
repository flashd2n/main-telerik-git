using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        public int Number { get; private set; }



        static void Main()
        {
            var testing = new Program();
            testing.Number = 4;
            Console.WriteLine(testing.Number);


        }
    }
}

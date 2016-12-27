using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var testList = new List<string>();
            testList.Add("J");
            testList.Add("j");
            testList.Add("K");
            testList.Add("k");
            testList.Add("H");
            testList.Add("h");
            testList.Sort();
            Console.WriteLine(string.Join(", ", testList));
        }

        

    }
}

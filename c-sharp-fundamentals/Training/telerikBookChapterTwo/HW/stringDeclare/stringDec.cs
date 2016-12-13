using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringDeclare
{
    class stringDec
    {
        static void Main(string[] args)
        {
            string strOne = "Hello";
            string strTwo = "World";
            object concat = strOne + " " + strTwo;
            Console.WriteLine(concat);
        }
    }
}

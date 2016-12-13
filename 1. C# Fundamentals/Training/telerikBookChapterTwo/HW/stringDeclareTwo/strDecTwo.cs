using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stringDeclareTwo
{
    class strDecTwo
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object concat = hello + " " + world;
            string sentence = (string)concat;
            Console.WriteLine(sentence);
        }
    }
}

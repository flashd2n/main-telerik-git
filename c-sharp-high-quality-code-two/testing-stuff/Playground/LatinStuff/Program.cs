using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LatinStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();


            Console.WriteLine(!Regex.IsMatch(input, @"^[a-zA-Z]+$"));

        }
    }
}

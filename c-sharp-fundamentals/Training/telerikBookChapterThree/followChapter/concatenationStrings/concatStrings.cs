using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace concatenationStrings
{
    class concatStrings
    {
        static void Main(string[] args)
        {
            string cSharp = "C#";
            string dotNet = ".NET";
            string cSharpDotNet = cSharp + dotNet;
            string cSharpDotNetFive = cSharp + dotNet + " " + 5;
            Console.WriteLine(cSharpDotNet);
            Console.WriteLine(cSharpDotNetFive);
        }
    }
}

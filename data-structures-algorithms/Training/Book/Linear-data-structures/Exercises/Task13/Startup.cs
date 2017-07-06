using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    public class Startup
    {
        static void Main()
        {

            var dir = new DirectoryInfo(@"B:\");
            

            var dirs = dir.GetDirectories();

            Console.WriteLine(dirs.Count());

            var files = dir.GetFiles();

        }
    }
}

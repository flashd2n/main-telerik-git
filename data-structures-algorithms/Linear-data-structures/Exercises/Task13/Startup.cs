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

            //var dir = new DirectoryInfo(@"B:\");


            //var dirs = dir.GetDirectories();

            //Console.WriteLine(dirs.Count());

            //var files = dir.GetFiles();

            var testDeque = new StaticDeque<int>();

            for (int i = 0; i < 10; i++)
            {
                testDeque.AddBack(i);
            }

            for (int i = 0; i < 5; i++)
            {
                testDeque.RemoveFront();
            }

            for (int i = 10; i < 20; i++)
            {
                testDeque.AddFront(i);
            }

            for (int i = 0; i < 5; i++)
            {
                testDeque.RemoveBack();
            }



        }
    }
}

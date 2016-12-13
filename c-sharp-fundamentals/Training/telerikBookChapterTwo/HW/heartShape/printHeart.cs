using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heartShape
{
    class printHeart
    {
        static void Main(string[] args)
        {
            char builder = 'o';
            string buildingBlock = builder.ToString();
            Console.WriteLine(" " + buildingBlock + buildingBlock + " " + buildingBlock + buildingBlock + " ");
            Console.WriteLine(buildingBlock + buildingBlock + buildingBlock + buildingBlock + buildingBlock + buildingBlock + buildingBlock);
            Console.WriteLine(" " + buildingBlock + buildingBlock + buildingBlock + buildingBlock + buildingBlock + " ");
            Console.WriteLine(" " + " " + buildingBlock + buildingBlock + buildingBlock + " " + " ");
            Console.WriteLine(" " + " " + " " + buildingBlock + " " + " " + " ");

        }
    }
}

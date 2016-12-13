using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trianglePrint
{
    class trianglePr
    {
        static void Main(string[] args)
        {
            char building = '\u00a9';
            string buildiongBlock = building.ToString();
            Console.WriteLine(" " + " " + " " + buildiongBlock + " " + " " + " ");
            Console.WriteLine(" " + " " + buildiongBlock + buildiongBlock + buildiongBlock + " " + " ");
            Console.WriteLine(" " + buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock + " ");
            Console.WriteLine(buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock + buildiongBlock);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exEight
{
    class exerEight
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 0 for integer, 1 for double and 2 for string");
            byte choice = byte.Parse(Console.ReadLine());

            switch (choice)
            {
                case 0:
                    int select = int.Parse(Console.ReadLine());
                    Console.WriteLine(++select);
                    break;
                case 1:
                    double selectD = double.Parse(Console.ReadLine());
                    Console.WriteLine(++selectD);
                    break;
                case 2:
                    string selectS = Console.ReadLine();
                    Console.WriteLine(selectS + "*");
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }



        }
    }
}

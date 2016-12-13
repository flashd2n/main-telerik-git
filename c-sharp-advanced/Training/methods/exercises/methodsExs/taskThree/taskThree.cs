using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskThree
{
    class taskThree
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Console.WriteLine(GetLetter(input));
        }

        static string GetLetter(string number)
        {
            string letter = null;
            switch (number[number.Length - 1])
            {
                case '0':
                    letter = "zero";
                    break;
                case '1':
                    letter = "one";
                    break;
                case '2':
                    letter = "two";
                    break;
                case '3':
                    letter = "three";
                    break;
                case '4':
                    letter = "four";
                    break;
                case '5':
                    letter = "five";
                    break;
                case '6':
                    letter = "six";
                    break;
                case '7':
                    letter = "seven";
                    break;
                case '8':
                    letter = "eight";
                    break;
                case '9':
                    letter = "nine";
                    break;
                default:
                    break;
            }
            return letter;
        }
    }
}

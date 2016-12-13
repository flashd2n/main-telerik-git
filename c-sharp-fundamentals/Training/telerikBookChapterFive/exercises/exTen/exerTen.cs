using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exTen
{
    class exerTen
    {
        static void Main(string[] args)
        {
            int score = int.Parse(Console.ReadLine());

            if (score >=1 && score <= 3)
            {
                score *= 10;
                Console.WriteLine("Your score is {0}", score);
            }
            else if (score >= 4 && score <= 6)
            {
                score *= 100;
                Console.WriteLine("Your score is {0}", score);

            }
            else if (score >= 7 && score <= 9)
            {
                score *= 1000;
                Console.WriteLine("Your score is {0}", score);
            }
            else
            {
                Console.WriteLine("Error - not a valid score.");
            }


        }
    }
}

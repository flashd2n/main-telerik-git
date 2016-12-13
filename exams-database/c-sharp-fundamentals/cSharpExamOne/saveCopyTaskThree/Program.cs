using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hiddenMessage
{
    class hMessage
    {
        static void Main(string[] args)
        {

            string output = null;

            do
            {


                int startingPosition = int.Parse(Console.ReadLine());

            noend:

                int incrementSteps = int.Parse(Console.ReadLine());
                string input = Console.ReadLine();


                if (startingPosition < 0)
                {
                    startingPosition = input.Length - startingPosition;


                }








                for (int i = 0; i < input.Length; i += incrementSteps)
                {
                    int position = startingPosition + i;

                    if (position > input.Length - 1)
                    {
                        break;
                    }

                    char takeChar = input[position];
                    output += takeChar;

                }

                // check next input

                string checkEnd = Console.ReadLine();

                if (checkEnd[0] >= 48 && checkEnd[0] <= 57)
                {
                    startingPosition = Convert.ToInt32(checkEnd, 10);
                    goto noend;
                }
                else
                {
                    Console.WriteLine(output);
                    break;
                }

            } while (true);






        }
    }
}

using System;

namespace jumpJump
{
    class jumpJ
    {
        static void Main()
        {

            string input = Console.ReadLine();
            char iAmHere = input[0];
            int position = 0;

            do
            {
                
                if (iAmHere != '^')
                {
                    int temp = (int)iAmHere - 48;

                    if (temp == 0)
                    {
                        Console.WriteLine("Too drunk to go on after {0}!", position);
                        break;
                    }
           
                    if (temp % 2 == 0)
                    {
                        position = position + temp;

                        if (position > input.Length - 1)
                        {
                            Console.WriteLine("Fell off the dancefloor at {0}!", position);
                            break;
                        }

                        iAmHere = input[position]; // do tuk iamhere = 3, no p == 4
                    }
                    else
                    {
                        position = position - temp;

                        if (position < 0)
                        {
                            Console.WriteLine("Fell off the dancefloor at {0}!", position);
                            break;
                        }
                        iAmHere = input[position];
                    }
                }
                else if (iAmHere == '^')
                {
                    Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", position);
                    break;
                }
            } while (true);           
        }
    }
}

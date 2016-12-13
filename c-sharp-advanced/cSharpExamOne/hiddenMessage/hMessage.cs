using System;

namespace hiddenMessage
{
    class hMessage
    {
        static void Main()
        {

            string output = null;
            int startingPosition = 0;

            do
            {                              
                string checkEnd = Console.ReadLine();

                if ((checkEnd[0] >= 48 && checkEnd[0] <= 57) || (checkEnd[0] == 45 && (checkEnd[1] >= 48 && checkEnd[1] <= 57)))
                {
                    startingPosition = Convert.ToInt32(checkEnd, 10);
                    
                }
                else
                {
                    Console.WriteLine(output);
                    break;
                }

                int incrementSteps = int.Parse(Console.ReadLine());               
                string input = Console.ReadLine();

                if (startingPosition < 0)
                {

                    startingPosition = input.Length + startingPosition;

                    if (incrementSteps >= 0)
                    {
                        for (int i = 0; i < input.Length; i += incrementSteps)
                        {
                            int position = startingPosition + i;

                            if (position > input.Length - 1 || position < 0)
                            {
                                break;
                            }

                            char takeChar = input[position];
                            output += takeChar;

                        }
                    } else
	                {
                        for (int i = 0; i <= 0; i += incrementSteps)
                        {
                            int position = startingPosition + i;

                            if (position > input.Length - 1 || position < 0)
                            {
                                break;
                            }

                            char takeChar = input[position];
                            output += takeChar;

                        }
                    }                    
                }
                else // ako starting pos e polojitelen
                {

                    if (incrementSteps >= 0)
                    {
                        for (int i = 0; i < input.Length; i += incrementSteps)
                        {
                            int position = startingPosition + i;

                            if (position > input.Length - 1 || position < 0)
                            {
                                break;
                            }

                            char takeChar = input[position];
                            output += takeChar;

                        }
                    }
                    else // ako starting e pol, no incr e negative
                    {
                        for (int i = 0; i <= 0; i += incrementSteps) // NOT COOL
                        {
                            int position = startingPosition + i;

                            if (position > input.Length - 1 || position < 0)
                            {
                                break;
                            }

                            char takeChar = input[position];
                            output += takeChar;

                        }
                    }                    
                }
                // check next input
            } while (true);
        }
    }
}

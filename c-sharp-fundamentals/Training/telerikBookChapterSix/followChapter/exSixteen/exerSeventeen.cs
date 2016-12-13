using System;

namespace exSixteen
{
    class exerSeventeen
    {
        static void Main(string[] args)
        {
            //start read string

            string input = Console.ReadLine();
            string stringN = null;
            string stringM = null;


            for (int i = 0; i < input.Length ; i++)
            {
                if (input[i] == 32)
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {

                        stringM += input[j];
                    }
                    break;
                }

                stringN += input[i];

            }

            int inputN = Convert.ToInt32(stringN, 10);
            int inputM = Convert.ToInt32(stringM, 10);

            //finish extract numbers from string to int

            int tempN = inputN;
            int tempM = inputM;
            int remainder = 1;
            int tempSwitch = 1;

            if (inputN < inputM)
            {
                tempSwitch = inputN;
                inputN = inputM;
                inputM = tempSwitch;
            }

            // FIND GCD

            do
            {
                remainder = tempN % tempM;
                tempN = tempM;
                tempM = remainder;

            } while (remainder != 0);

            int gcd = tempN;

            Console.WriteLine("The Greatest Common Divisor of {0} and {1} is: {2}", inputN, inputM, gcd);


            // FIND LCM

            int lcm = (inputN * inputM) / gcd;

            Console.WriteLine("The Least Common Multiple of {0} and {1} is: {2}", inputN, inputM, lcm);

        }
    }
}

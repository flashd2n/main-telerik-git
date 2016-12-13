using System;


namespace lectureIntro
{
    class intro
    {
        static int ConvertToDec(string number, int numeralBase)
        {
            int result = 0;

            foreach (char digit in number)
            {
                result = result * numeralBase + (digit - '0');
            }

            return result;
        }

        static int ConvertFromHExtoDec(string number)
        {
            int result = 0;

            foreach (char digit in number)
            {
                int digitValue;

                if (char.IsDigit(digit))
                {
                    digitValue = digit - '0';
                }
                else
                {
                    digitValue = digit - 'A' + 10;
                }

                result = 16 * result + digitValue;
            }

            return result;
        }

        static void Main()
        {

            string[] tests =
            {
                "1101", "11", "10", "01", "100", "1111"
            };

            string[] test3 =
            {
                "1021", "2", "10", "11", "12", "20", "221"
            };

            string[] testHex =
            {
                "312AB", "FE", "1A", "ABCDEF", "AA", "21", "1A"
            };

            //foreach (string test in testHex)
            //{
            //    Console.WriteLine(ConvertToDec(test, 3));
            //}

            foreach (string test in testHex)
            {
                Console.WriteLine(ConvertFromHExtoDec(test));
            }

        }
    }
}

using System;

namespace exEleven
{
    class exerEleven
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] lastNumber = {null, "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"};
            string[] middleNumber = {null, null, "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"};
            string hundred = "Hundred";

            // Spit the possible numbers into 2 categories (0 - 9; 10 - 20, 21 - 99 , 100 - 999)

            if (n <= 9)
            {
                if (n == 0)
                {
                    Console.WriteLine("You selected Zero");
                }
                else
                {
                    Console.WriteLine("You selected {0}", lastNumber[n]);
                }
            }
            else if (n <= 20) 
            {
                switch (n)
                {
                    case 10:
                        Console.WriteLine("Ten");
                        break;
                    case 11:
                        Console.WriteLine("Eleven");
                        break;
                    case 12:
                        Console.WriteLine("Twelve");
                        break;
                    case 13:
                        Console.WriteLine("Thirteen");
                        break;
                    case 14:
                        Console.WriteLine("Fourteen");
                        break;
                    case 15:
                        Console.WriteLine("Fifteen");
                        break;
                    case 16:
                        Console.WriteLine("Sixteen");
                        break;
                    case 17:
                        Console.WriteLine("Seventeen");
                        break;
                    case 18:
                        Console.WriteLine("Eighteen");
                        break;
                    case 19:
                        Console.WriteLine("Nineteen");
                        break;
                    case 20:
                        Console.WriteLine("Twenty");
                        break;
                    default:
                        Console.WriteLine("Some error");
                        break;
                }
            }
            else if (n <= 99)
            {
                int a = (n / 10) % 10;
                int b = n % 10;

                for (int i = 2; i <= 9; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {

                        if (i == a && j == b)
                        {
                            Console.WriteLine("You selected {0} {1}", middleNumber[i], lastNumber[j]);
                        }
                    }
                }
            }
            else if (n <= 999)
            {
                int a = (n / 100) % 10;
                int b = (n / 10) % 10;
                int c = n % 10;

                for (int i = 1; i <= 9; i++)
                {
                    for (int j = 0; j <= 9; j++)
                    {
                        for (int k = 0; k <= 9; k++)
                        {
                            if (i == a && j == b && k == c)
                            {
                                if (j == 0 && k == 0)
                                {
                                    Console.WriteLine("You selected {0} {1}", lastNumber[i], hundred);
                                }
                                else if (k == 0)
                                {
                                    Console.WriteLine("You selected {0} {1} and {2}", lastNumber[i], hundred, middleNumber[b]);
                                }
                                else
                                {
                                    Console.WriteLine("You selected {0} {1} and {2} {3}", lastNumber[i], hundred, middleNumber[j], lastNumber[k]);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Not a valid input");
            }
        }
    }
}

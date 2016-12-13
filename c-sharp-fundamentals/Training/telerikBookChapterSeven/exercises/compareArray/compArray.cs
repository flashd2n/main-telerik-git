using System;

namespace compareArray
{
    class compArray
    {
        static void Main()
        {
            string arrayOne = Console.ReadLine();
            string arrayTwo = Console.ReadLine();

            bool isEqual = false;

            if (arrayOne.Length < arrayTwo.Length)
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] > arrayTwo[i])
                    {
                        Console.WriteLine(">");
                        break;
                    }
                    else if (arrayOne[i] < arrayTwo[i])
                    {
                        Console.WriteLine("<");
                        break;
                    }

                    if (i == (arrayOne.Length - 1))
                    {
                        Console.WriteLine("<");
                    }
                }
            }
            else if (arrayOne.Length > arrayTwo.Length)
            {
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    if (arrayOne[i] > arrayTwo[i])
                    {
                        Console.WriteLine(">");
                        break;
                    }
                    else if (arrayOne[i] < arrayTwo[i])
                    {
                        Console.WriteLine("<");
                        break;
                    }

                    if (i == (arrayTwo.Length - 1))
                    {
                        Console.WriteLine(">");
                    }
                }
            }
            else
            {
                for (int i = 0; i < arrayOne.Length; i++)
                {
                    if (arrayOne[i] > arrayTwo[i])
                    {
                        Console.WriteLine(">");
                        isEqual = false;
                        break;
                    }
                    else if (arrayOne[i] < arrayTwo[i])
                    {
                        Console.WriteLine("<");
                        isEqual = false;
                        break;
                    }

                    isEqual = true;
                }
            }
            if (isEqual)
            {
                Console.WriteLine("=");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskEight
{
    class Startup
    {
        static void Main()
        {
            int temp = 0;
            int safety = 0;

            var myList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                safety = temp;

                try
                {
                    temp = GetNumber(1 + temp, 100);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Invalid Number");
                }

                if (temp != 0)
                {
                    myList.Add(temp);
                }
                else
                {
                    temp = safety;
                }

            }

            Console.WriteLine(string.Join(", ", myList));
        }

        static int GetNumber(int start, int end)
        {
            
            int number = int.Parse(Console.ReadLine());
            if(number < start || number > end)
            {
                throw new ArgumentOutOfRangeException("The Number is not within the defined parameters");
            }
                       
            return number;
        }
    }
}

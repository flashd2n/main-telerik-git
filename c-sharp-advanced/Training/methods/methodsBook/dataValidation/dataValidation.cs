using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataValidation
{
    class dataValidation
    {


        static void Main()
        {
            Console.WriteLine("What time is it?");
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            if (CheckHours(hours) && CheckMinutes(minutes))
            {
                Console.WriteLine("The time now is {0}:{1}", hours, minutes);
            }
            else
            {
                Console.WriteLine("Incorrect Time!");
            }


        }

        static bool CheckMinutes(int minutes)
        {
            if (minutes >= 0 && minutes <= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool CheckHours(int hours)
        {
            if (hours >= 0 && hours <= 23)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

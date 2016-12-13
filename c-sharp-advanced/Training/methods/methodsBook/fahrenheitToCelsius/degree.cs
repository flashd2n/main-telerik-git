using System;

namespace fahrenheitToCelsius
{
    class degree
    {
        static void Main()
        {
            double fahTemp = double.Parse(Console.ReadLine());
            double celsiusTemp = ConvertTemp(fahTemp);
            Console.WriteLine("Your body temperature in celsius degrees is: " + celsiusTemp);
            CheckIllness(celsiusTemp);
        }

        static void CheckIllness(double celsiusTemp)
        {
            if (celsiusTemp > 37)
            {
                Console.WriteLine("You are ill!");
            }
            else
            {
                return;
            }
        }

        static double ConvertTemp(double fahTemp)
        {
            double result = (fahTemp - 32) * 5 / 9; 
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskSeven
{
    class Startup
    {
        static void Main()
        {
            try
            {
                uint number = uint.Parse(Console.ReadLine());
                double result = Math.Sqrt(number);
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }

            var testit = new testingType();


        }

        class testingType
        {
            public testingType()
            {
                Console.WriteLine(this.GetType().Name);
            }
        }
    }
}

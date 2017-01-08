using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnomTypes
{
    class Startup
    {
        static void Main()
        {

            var myCar = new { Brand = "Citroen", Model = "C3", Year = 2007, Engine = "1.4 TDI" };

            Console.WriteLine(myCar.ToString()/*.IndexOf("Brand")*/);


        }
    }
}

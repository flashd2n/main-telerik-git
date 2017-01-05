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

            var myCar = new { brand = "BMW", model = "M3", year = 2006};
            var myOtherCar = new { brand = "BMW", model = "M5", year = 2006 };
            Console.WriteLine(myCar.Equals(myOtherCar));

            var array = new[]
            {
                new { brand = "BMW", model = "M6", year = 2015},
                new { brand = "AUDI", model = "RS7", year = 2016},
                new { brand = "PORSCHE", model = "Panamera Turbo S", year = 2017}
            };

            foreach (var item in array)
            {
                Console.WriteLine(item.model);
            }

        }
    }
}

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
            var people = new List<Person>()
            {
                new Person {FirstName = "John", LastName = "Doe", Age = 20 },
                new Person {FirstName = "Jane", LastName = "Doe", Age = 30 },
                new Person {FirstName = "Bill", LastName = "Johnson", Age = 15 },
                new Person {FirstName = "Sally", LastName = "Johnson", Age = 17 },
                new Person {FirstName = "Rupert", LastName = "LastName", Age = 55 },
            };

            var result = from p in people
                         where p.LastName == "Doe"
                         select new { FName = p.FirstName, LName = p.LastName };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.FName}, {item.LName}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            //var allNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            //var onlyEvenNumbers = allNumbers.FindAll(x => (x % 2) == 0);

            var allDogs = new List<Dog>()
            {
                new Dog {Name = "Rex", Age = 3 },
                new Dog { Name = "Berg", Age = 9.8},
                new Dog { Name = "Goshko", Age = 3.6}
            };

            var names = allDogs.Select(x => x.Name);

            foreach (var item in names)
            {
                Console.WriteLine(item);
            }

            var newDogs = allDogs.Select(x => new { Age = x.Age, Name = x.Name[0] });

            foreach (var item in newDogs)
            {
                Console.WriteLine(item);
            }

            var sortedDogs = allDogs.OrderByDescending(x => x.Age);

            foreach (var item in sortedDogs)
            {
                Console.Write(item.Name);
                Console.Write(item.Age);
                Console.WriteLine("");
            }

        }
    }
}

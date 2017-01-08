using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTwo
{
    class Startup
    {
        static void Main()
        {
            var people = new List<Person>()
            {
                new Person("gosho", "goshev", 23),
                new Person("gosho", "toshev", 43),
                new Person("tosho", "goshev", 11),
                new Person("penka", "gosheva", 32),
                new Person("goshka", "tosheva", 25)
            };

            var result = from p in people
                         orderby p.LastName
                         group p by p.LastName;

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {item.Count()}");
                foreach (var p in item)
                {
                    Console.WriteLine($"\t{p.FirstName}, {p.LastName}");
                }
            }
        }
    }
}

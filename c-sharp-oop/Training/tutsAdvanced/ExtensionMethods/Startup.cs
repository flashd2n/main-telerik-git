using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Startup
    {
        static void Main()
        {
            var person = new Person("gosho", 45);
            var personTwo = new Person("goshka", 44);

            person.SayHello(personTwo);
        }
    }
}

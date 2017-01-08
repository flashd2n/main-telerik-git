using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    public static class Extentions
    {

        public static void SayHello(this Person person, Person personTwo)
        {
            Console.WriteLine($"{person.Name} says hello to {personTwo.Name}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static
{
    class Program
    {
        static void Main()
        {
            Dog[] array = new Dog[10];

            for (int i = 0; i < 10; i++)
            {
                array[i] = new Dog();
            }

            Console.WriteLine(Dog.dogeCount);
        }
    }

    class Dog
    {
        public static int dogeCount;

        public int age;
        public string name;

        public Dog()
        {
            ++dogeCount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Dog
    {
        private string name;
        private int age;
        private double length;
        private Collar collar;

        static void Main()
        {
            var myDog = new Dog();
            myDog.name = "Berg";
            myDog.age = 9;
            myDog.length = 1.9;
            myDog.collar = new Collar(5);

            Console.WriteLine($"My dog's name is {myDog.name}, he is {myDog.age}, {myDog.length} long and has collar size {myDog.collar}"); // needs to make int size public and add .size to collar to display the value

        }

        public Dog()
        {
            this.name = "default";
            this.age = 1;
            this.length = 1.0;
            this.collar = new Collar(1);
        }

    }

    public class Collar
    {
        private int size;

        public Collar(int sizeCollar)
        {
            this.size = sizeCollar;
        }
    }
}

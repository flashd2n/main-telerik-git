using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReusingConstructors
{
    class Program
    {
        static void Main()
        {
            var myDog = new Dog(/*"Berg", 9, 1.9, new Collar(10)*/);
            Console.WriteLine("======");
            var myDogTwo = new Dog("Berg", 9, 1.9, new Collar(10));
        }
    }

    class Dog
    {
        private string name;
        private int age;
        private double length;
        private Collar collar;

        public Dog() : this ("no-name")
        {
            Console.WriteLine("Constructor 1");
        }

        public Dog(string name) : this (name, 1)
        {
            Console.WriteLine("Constructor 2");
        }

        public Dog(string name, int age) : this (name, age, 1.3)
        {
            Console.WriteLine("Constructor 3");
        }

        public Dog(string name, int age, double length) : this (name, age, length, new Collar(1))
        {
            Console.WriteLine("Constructor 4");
        }

        public Dog(string name, int age, double length, Collar collar) // tozi constructor se izpulnqva zaduljitelno
        {
            this.name = name;
            this.age = age;
            this.length = length;
            this.collar = collar;
            Console.WriteLine("Constructor 5");
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

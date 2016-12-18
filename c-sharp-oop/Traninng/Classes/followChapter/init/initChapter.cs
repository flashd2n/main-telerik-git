using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace init
{
    class initChapter
    {
        static void Main()
        {
            string firstDogName = null;
            Console.WriteLine("Enter first dog name:");
            firstDogName = Console.ReadLine();

            var firstDog = new Dog(firstDogName);

            var secondDog = new Dog();

            Console.WriteLine("Enter second dog name:");
            secondDog.Name = Console.ReadLine();

            var thirdDog = new Dog();

            Dog[] dogs = new Dog[] { firstDog, secondDog, thirdDog};

            foreach (var dog in dogs)
            {
                dog.Bark();
            }

        }
    }

    public class Dog
    {
        //Field declaration
        private string name;
        //Constructor declaration
        public Dog()
        {

        }

        //Another constructor declaration
        public Dog(string name)
        {
            this.name = name;
        }

        //Property declaration

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Method Declaration
        public void Bark()
        {
            Console.WriteLine($"{name ?? "[unnamed dog]"} said: wof wof!");
        }
    }
}

using System;
using CreatingAndUsingObjects;

namespace CallClasses
{
    class CallClasses
    {
        static void Main()
        {
            var testCat = new Cat();
            testCat.Color = "green";
            testCat.Name = "Gosho";

            Console.WriteLine($"My cat is called: {testCat.Name} and it is {testCat.Color}");
            testCat.SayMiau();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Sequence.NextValue());
            }

        }
    }
}

namespace CreatingAndUsingObjects
{
    class Cat
    {
        //Field name
        private string name;
        //Field color
        private string color;

        public string Name
        {
            // Getter of the property "Name"
            get
            {
                return this.name;
            }
            // Setter of the property "Name"
            set
            {
                this.name = value;
            }
        }

        public string Color
        {
            // Getter of Color
            get
            {
                return this.color;
            }
            // Setter of Color
            set
            {
                this.color = value;
            }
        }

        // Default constructor
        public Cat()
        {
            this.name = "Unnamed";
            this.color = "gray";
        }

        // Constructor with parameters
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        // Method SayMiau
        public void SayMiau()
        {
            Console.WriteLine($"Cat {name} said: Miauuuuu!");
        }
    }

    class Sequence
    {
        private static int currentValue = 0;

        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }
}

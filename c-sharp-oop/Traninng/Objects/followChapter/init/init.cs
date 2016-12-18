using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace init
{
    class init
    {
        static void Main()
        {
            var firstCat = new Cat();
            firstCat.Name = "Tony";
            firstCat.SayMiau();

            var secondCat = new Cat("Pepi", "red");
            secondCat.SayMiau();

            Console.WriteLine($"Cat {secondCat.Name} is {secondCat.Color}");
            
        }
    }

    public class Cat
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

}

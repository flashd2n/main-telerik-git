using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisibilityFieldsMethods
{
    public class Dog
    {
        private string name = "Doge";

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        private void Bark()
        {
            Console.WriteLine("wof wof!");
        }

        public void DoSomething()
        {
            this.Bark();
        }

        static void Main()
        {
            var doge = new Dog();
            doge.Bark();
            Console.WriteLine(doge.Name);


        }
    }



}

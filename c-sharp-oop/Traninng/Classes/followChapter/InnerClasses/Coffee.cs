using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerClasses
{
    class Coffee
    {
        public enum CoffeeSize
        {
            Small = 100,
            Normal = 150,
            Doouble = 300
        }

        private CoffeeSize size;

        public Coffee(CoffeeSize size)
        {
            this.size = size;
        }

        public CoffeeSize Size
        {
            get
            {
                return this.size;
            }
        }

    }

    class Startup
    {
        public static void Main()
        {
            var coffee = new Coffee(Coffee.CoffeeSize.Normal);

            //coffee.Size = Coffee.CoffeeSize.Small;

            Console.WriteLine(coffee.Size);

        }
    }
}

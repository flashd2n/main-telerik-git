using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main()
        {
            var shelter = new AnimalShelter(5);
            var dog1 = new Dog();
            var dog2 = new Dog();
            var dog3 = new Dog();

            shelter.Shelter(dog1);
            shelter.Shelter(dog2);
            shelter.Shelter(dog3);

            var releasedDog = shelter.Release(1);

        }
    }
}

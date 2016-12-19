using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisibilityFieldsMethods;

namespace KidOtherAssembly
{
    class Kid
    {

        public void CallTheDog(Dog dog)
        {
            Console.WriteLine($"Come, {dog.Name}");
        }

        public void WagTheDog(Dog dog)
        {
            dog.Bark();
        }

    }
}

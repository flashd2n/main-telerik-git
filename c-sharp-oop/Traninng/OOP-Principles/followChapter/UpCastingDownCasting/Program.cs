using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpCastingDownCasting
{
    class Program
    {
        static void Main()
        {
            //var lionOne = new AfricanLion("pencho", 3);

            //// upcasting
            //object obj = lionOne;

            ////downcasting
            //AfricanLion lionTwo = (AfricanLion)obj;

            //var lion = new Lion();
            //lion.NumberLegs = 4;
            //lion.Species = "some cats";
            //Animal animalOne = lion;

            var animaltwo = new Animal();
            animaltwo.NumberLegs = 3;
            Lion biglion = (Lion)animaltwo;

            //var africanlion = new AfricanLion("pencho", 3);

            
        }
    }
}

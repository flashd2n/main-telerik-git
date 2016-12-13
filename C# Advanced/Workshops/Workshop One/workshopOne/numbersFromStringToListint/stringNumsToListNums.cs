using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace numbersFromStringToListint
{
    class stringNumsToListNums
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine() //4etem ne6to
                .Split(' ') // pravim kolekciq
                .Select(int.Parse) // na vseki element pravim parse
                .ToList(); // vkarvame elementite v list-a



        }
    }
}

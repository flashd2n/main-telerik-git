﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleThreeAndSeven
{
    class Startup
    {
        static void Main()
        {
            var arrayInts = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            var result = arrayInts.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();

            var resultLINQ = from i in arrayInts
                             where i % 3 == 0 && i % 7 == 0
                             select i;

        }
    }
}

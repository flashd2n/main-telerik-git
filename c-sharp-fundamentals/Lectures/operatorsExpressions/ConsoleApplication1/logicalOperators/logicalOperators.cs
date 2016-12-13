using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicalOperators
{
    class logicalOperators
    {
        static void Main(string[] args)
        {
            bool toshoHasMoney = true;
            bool iHaveMoney = false;

            Console.WriteLine(toshoHasMoney || iHaveMoney);

            bool goOut = true;
            bool goOut2 = false;

            Console.WriteLine(goOut && goOut2);

            bool oneIstrue = false;
            bool oneIsFalse = true;

            Console.WriteLine(oneIstrue ^ oneIsFalse);

        }
    }
}

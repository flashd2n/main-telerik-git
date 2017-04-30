using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    public class AwesomeClass
    {
        public AwesomeClass()
        {

        }

        public int SumResult(int a, int b)
        {
            var result = this.Sum(a, b);
            return result;
        }

        private int Sum(int a, int b)
        {
            return a + b;
        }

    }
}

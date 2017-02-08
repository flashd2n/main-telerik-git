using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemCalculator
{
    public class CalculatorEngine
    {
        private int sum;

        public CalculatorEngine()
        {
            this.sum = 0;
        }

        public void Add(int number)
        {
            sum += number;
        }

        public int Equals()
        {
            var result = this.sum;
            this.sum = 0;
            return result;
        }

    }
}

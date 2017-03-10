using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Sum : Expression
    {
        public Money Augend { get; set; }
        public Money Added { get; set; }

        public Sum(Money augend, Money added)
        {
            this.Augend = augend;
            this.Added = added;
        }
        public Money Reduce(Bank bank, string to)
        {
            var amount = Augend.Amount + Added.Amount;
            return new Money(amount, to);
        }
    }
}

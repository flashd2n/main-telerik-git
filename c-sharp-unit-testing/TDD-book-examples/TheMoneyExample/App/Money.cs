using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Money : Expression
    {
        private int amount;
        private string currency;

        public Money(int amount, string currency)
        {
            this.Amount = amount;
            this.Currency = currency;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                this.amount = value;
            }
        }

        protected string Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return this.Amount == money.Amount && this.Currency.Equals(money.Currency);
        }

        public static Money MakeDollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money MakeFranc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public Money times(int multuplier)
        {
            return new Money(this.Amount * multuplier, this.Currency);
        }

        public string GetCurrency()
        {
            return this.Currency;
        }

        public Expression Plus(Money added)
        {
            return new Sum(this, added);
        }
        public Money Reduce(string to)
        {
            return this;
        }
    }
}

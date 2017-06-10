using System;
using ChainOfResponsibility.Before;

namespace ChainOfResponsibility.After
{
    public class SpecialPriceRule : IPriceRule
    {
        public decimal CalcualtePrice(OrderItem item)
        {
            decimal total = 0;

            total += item.Quantity * .4m;

            int setsOfThree = item.Quantity / 3;

            total -= setsOfThree * .2m;

            return total;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku.StartsWith("SPECIAL"))
            {
                return true;
            }

            return false;
        }
    }
}

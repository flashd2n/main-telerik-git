using System.Collections.Generic;

namespace ChainOfResponsibility.Before
{
    public class ShoppingCart
    {
        private readonly ICollection<OrderItem> items;

        public ShoppingCart(ICollection<OrderItem> items)
        {
            this.items = items;
        }

        public decimal TotalAmount()
        {
            decimal total = 0;

            foreach (var item in items)
            {
                if (item.Sku.StartsWith("EACH"))
                {
                    total += item.Quantity * 5m;
                }
                else if (item.Sku.StartsWith("SPECIAL"))
                {
                    total += item.Quantity * .4m;

                    int setsOfThree = item.Quantity / 3;

                    total -= setsOfThree * .2m;
                }
            }

            return total;
        }
    }
}

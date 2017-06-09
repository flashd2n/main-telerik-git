using ChainOfResponsibility.After;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Before
{
    public class ShoppingCart
    {
        private readonly ICollection<OrderItem> items;
        private readonly IPricingCalculator calculator;

        public ShoppingCart(ICollection<OrderItem> items, IPricingCalculator calculator)
        {
            this.items = items;
            this.calculator = calculator;
        }

        public decimal TotalAmount()
        {
            decimal total = 0;


            foreach (var item in items)
            {
                total += this.calculator.CalculatePrice(item);
            }
            
            return total;
        }
    }
}

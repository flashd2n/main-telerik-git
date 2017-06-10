using ChainOfResponsibility.Before;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibility.After
{
    public class PricingCalculator : IPricingCalculator
    {
        private List<IPriceRule> rules;

        public PricingCalculator()
        {
            this.rules = new List<IPriceRule>()
            {
                new EachPriceRule(),
                new SpecialPriceRule()
            };
        }

        // when new rule -> just create the class and add it to the list above and everything works

        public decimal CalculatePrice(OrderItem item)
        {

            return this.rules.First(x => x.IsMatch(item)).CalcualtePrice(item);

        }
    }
}

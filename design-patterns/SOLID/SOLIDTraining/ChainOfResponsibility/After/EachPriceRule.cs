using ChainOfResponsibility.Before;

namespace ChainOfResponsibility.After
{
    public class EachPriceRule : IPriceRule
    {
        public decimal CalcualtePrice(OrderItem item)
        {
            return item.Quantity * 5m;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku.StartsWith("EACH"))
            {
                return true;
            }

            return false;
        }
    }
}

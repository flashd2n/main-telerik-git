using ChainOfResponsibility.Before;

namespace ChainOfResponsibility.After
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}

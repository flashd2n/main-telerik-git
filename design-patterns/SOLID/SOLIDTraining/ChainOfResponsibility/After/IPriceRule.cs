using ChainOfResponsibility.Before;

namespace ChainOfResponsibility.After
{
    public interface IPriceRule
    {
        bool IsMatch(OrderItem item);

        decimal CalcualtePrice(OrderItem item);
    }
}

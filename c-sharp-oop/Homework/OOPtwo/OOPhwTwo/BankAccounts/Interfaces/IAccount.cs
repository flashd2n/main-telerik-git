namespace BankAccounts.Interfaces
{
    public interface IAccount
    {
        Customer AccountCustomer { get; set; }
        decimal Balance { get; set; }
        double MonthlyInterestRate { get; set; }
        double CalculateInterestRate(int numberOfMonths);
    }
}

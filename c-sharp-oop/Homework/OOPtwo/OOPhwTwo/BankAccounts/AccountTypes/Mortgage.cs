using BankAccounts.Interfaces;

namespace BankAccounts.AccountTypes
{
    public class Mortgage : Account, IAccount
    {
        public Mortgage(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate)
        {
        }
        public void DepositFunds(decimal amount)
        {
            this.Balance += amount;
        }

        public override double CalculateInterestRate(int numberOfMonths)
        {
            double result = 0;

            if (this.AccountCustomer.GetType().Name.Equals("Company"))
            {
                if (numberOfMonths <= 12)
                {
                    result = numberOfMonths * (this.MonthlyInterestRate / 2);
                }
                else
                {
                    result = (12 * (this.MonthlyInterestRate / 2)) + ((numberOfMonths - 12) * this.MonthlyInterestRate);
                }
            }

            if (this.AccountCustomer.GetType().Name.Equals("Individual"))
            {
                if (numberOfMonths <= 6)
                {
                    result = 0;
                }
                else
                {
                    result = (numberOfMonths - 6) * this.MonthlyInterestRate;
                }
            }
            return result;
        }

    }
}

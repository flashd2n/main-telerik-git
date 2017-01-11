using BankAccounts.Interfaces;
using BankAccounts.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.AccountTypes
{
    public class Loan : Account, IAccount
    {
        public Loan(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate)
        {
        }
        public void DepositFunds(decimal amount)
        {
            this.Balance += amount;
        }

        public override double CalculateInterestRate(int numberOfMonths)
        {
            double result;
            if (numberOfMonths <= 3 && this.AccountCustomer.GetType().ToString() == "Individual")
            {
                result = 0;
            }
            else if (numberOfMonths <= 2 && this.AccountCustomer.GetType().ToString() == "Company")
            {
                result = 0;
            }
            else
            {
                result = numberOfMonths * this.MonthlyInterestRate;
            }
            return result;
        }

    }
}

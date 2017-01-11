using BankAccounts.Interfaces;
using System;

namespace BankAccounts.AccountTypes
{
    public class Deposit : Account, IAccount, IDeposit, IWithdraw
    {
        public Deposit(Customer customer, decimal balance, double interestRate) : base(customer, balance, interestRate)
        {
        }
        
        public void DepositFunds(decimal amount)
        {
            this.Balance += amount;
        }

        public void WithdrawFunds(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new Exception("Not enough cash, bro!");
            }

            this.Balance -= amount;

        }

        public override double CalculateInterestRate(int numberOfMonths)
        {
            double result;
            if (this.Balance >= 0 && this.Balance < 1000)
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

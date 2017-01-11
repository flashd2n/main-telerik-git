using BankAccounts.Interfaces;
using BankAccounts.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class Account : IAccount
    {
        private Customer accountCustomer;
        private decimal balance;
        private double monthlyInterestRate;

        public Customer AccountCustomer
        {
            get { return this.accountCustomer; }
            set { this.accountCustomer = value; }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
        public double MonthlyInterestRate
        {
            get { return this.monthlyInterestRate; }
            set { this.monthlyInterestRate = value; }
        }

        public Account(Customer customer, decimal balance, double interestRate)
        {
            this.AccountCustomer = customer;
            this.Balance = balance;
            this.MonthlyInterestRate = interestRate;
        }

        public virtual double CalculateInterestRate(int numberOfMonths)
        {
            double result = numberOfMonths * this.MonthlyInterestRate;
            return result;
        }
    }
}

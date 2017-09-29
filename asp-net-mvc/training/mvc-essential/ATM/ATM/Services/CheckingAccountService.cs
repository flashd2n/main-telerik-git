using ATM.Models;
using System;
using System.Linq;

namespace ATM.Services
{
    public class CheckingAccountService
    {
        private ApplicationDbContext dbContext; 

        public CheckingAccountService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCheckingAccount(string firstName, string lastName, string userId, decimal initialBalance)
        {
            var totalAccounts = this.dbContext.CheckingAccounts.Count();
            var checkingAccount = new CheckingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                AccountNumber = String.Format($"{totalAccounts}").PadLeft(10, '0'),
                Balance = 0.00m,
                ApplicationUserId = userId
            };

            this.dbContext.CheckingAccounts.Add(checkingAccount);
            this.dbContext.SaveChanges();
        }

    }
}
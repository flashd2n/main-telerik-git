using BankAccounts.Interfaces;
using BankAccounts.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class Company : Customer, ICustomer
    {
        public Company(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}

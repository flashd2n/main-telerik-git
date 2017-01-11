using BankAccounts.Interfaces;
using BankAccounts.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class Individual : Customer, ICustomer
    {
        public Individual(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}

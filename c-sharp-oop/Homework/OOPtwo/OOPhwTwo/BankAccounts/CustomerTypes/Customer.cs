using BankAccounts.Interfaces;
using BankAccounts.AccountTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class Customer : ICustomer
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int uniqueId;
        private static int count = 1;

        public string FirstName
        {
            get { return this.firstName; }
        }
        public string LastName
        {
            get { return this.lastName; }
        }
        public int UniqueID
        {
            get { return uniqueId; }
        }

        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.uniqueId = count;
            ++count;
        }


    }
}

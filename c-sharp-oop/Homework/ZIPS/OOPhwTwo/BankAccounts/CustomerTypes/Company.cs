using BankAccounts.Interfaces;

namespace BankAccounts
{
    public class Company : Customer, ICustomer
    {
        public Company(string fullName) : base(fullName)
        {
        }
    }
}

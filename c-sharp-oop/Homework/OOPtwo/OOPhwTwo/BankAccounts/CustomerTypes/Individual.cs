using BankAccounts.Interfaces;

namespace BankAccounts
{
    public class Individual : Customer, ICustomer
    {
        public Individual(string fullName) : base(fullName)
        {
        }
    }
}

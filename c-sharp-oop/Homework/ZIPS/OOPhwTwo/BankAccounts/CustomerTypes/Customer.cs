using BankAccounts.Interfaces;

namespace BankAccounts
{
    public class Customer : ICustomer
    {
        private readonly string fullName;
        private readonly int uniqueId;
        private static int count = 1;

        public string FullName
        {
            get { return this.fullName; }
        }
        public int UniqueID
        {
            get { return uniqueId; }
        }

        public Customer(string fullName)
        {
            this.fullName = fullName;
            this.uniqueId = count;
            ++count;
        }

    }
}

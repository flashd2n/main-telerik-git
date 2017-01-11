namespace BankAccounts.Interfaces
{
    public interface ICustomer
    {
        string FullName { get; }
        int UniqueID { get; }
    }
}

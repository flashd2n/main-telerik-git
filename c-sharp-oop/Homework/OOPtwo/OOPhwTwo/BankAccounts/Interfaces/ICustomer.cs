using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Interfaces
{
    public interface ICustomer
    {
        string FirstName { get; }
        string LastName { get; }
        int UniqueID { get; }
    }
}

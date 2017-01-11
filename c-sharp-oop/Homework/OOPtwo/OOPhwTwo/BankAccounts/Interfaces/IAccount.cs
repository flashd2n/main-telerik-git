using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts.Interfaces
{
    public interface IAccount
    {
        Customer AccountCustomer { get; set; }
        decimal Balance { get; set; }
        double MonthlyInterestRate { get; set; }
        double CalculateInterestRate(int numberOfMonths);
    }
}

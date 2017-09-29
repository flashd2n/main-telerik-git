using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public CheckingAccount CheckingAccount { get; set; }

        public int CheckingAccountId { get; set; }
    }
}
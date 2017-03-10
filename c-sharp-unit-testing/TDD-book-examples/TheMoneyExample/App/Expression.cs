using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface Expression
    {
        Money Reduce(Bank bank, string to);
    }
}

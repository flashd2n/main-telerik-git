using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Bank
    {

        public Money Reduce(Expression source, string to)
        {
            return source.Reduce(to);
        }
    }
}

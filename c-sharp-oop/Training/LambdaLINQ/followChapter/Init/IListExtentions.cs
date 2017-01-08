using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class IListExtentions
    {
        public static void IncreaseBy<T, K>(this IList<T> input, K increment)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] += (dynamic)increment;
            }


        }
    }
}

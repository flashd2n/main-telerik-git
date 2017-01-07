using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class IEnumerableExtension
    {
        public static string ToString<T>(this IEnumerable<T> input)
        {
            var temp = new StringBuilder();
            temp.Append("[");
            foreach (var item in input)
            {
                temp.Append(item.ToString());
                temp.Append(", ");
            }

            temp.Remove(temp.Length - 2, 2);
            temp.Append("]");
            return temp.ToString();
        }

    }
}

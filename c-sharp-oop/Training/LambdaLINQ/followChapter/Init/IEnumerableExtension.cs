using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class IEnumerableExtension
    {
        public static string ToString<T>(this IEnumerable<T> enumeration)
        {
            var result = new StringBuilder();
            result.Append("[");
            foreach (var item in enumeration)
            {
                result.Append(item.ToString());
                result.Append(", ");
            }
            if (result.Length > 1)
            {
                result.Remove(result.Length - 2, 2);
            }
            result.Append("]");

            return result.ToString();
        }

    }
}

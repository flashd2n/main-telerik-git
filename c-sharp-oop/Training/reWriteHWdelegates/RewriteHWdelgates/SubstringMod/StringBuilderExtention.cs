using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringMod
{
    public static class StringBuilderExtention
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            var result = new StringBuilder();

            for (int i = index; i < (index + length); i++)
            {
                result.Append(input[i]);
            }
            return result;
        }
    }
}

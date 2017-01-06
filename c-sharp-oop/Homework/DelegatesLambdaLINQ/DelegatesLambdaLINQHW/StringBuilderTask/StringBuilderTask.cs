using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderTask
{
    public static class StringBuilderTask
    {
        // Extension method Substring for the class StringBuilder 
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {
            StringBuilder current = new StringBuilder();

            for (int i = index; i < index + length; i++)
            {
                current.Append(sb[i]);
            }

            return current;
        }
    }
}
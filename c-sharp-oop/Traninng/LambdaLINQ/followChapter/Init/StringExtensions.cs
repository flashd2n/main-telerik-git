using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class StringExtensions
    {
        public static int WordCount(this string input)
        {
            var result = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
            return result;
        }


    }
}

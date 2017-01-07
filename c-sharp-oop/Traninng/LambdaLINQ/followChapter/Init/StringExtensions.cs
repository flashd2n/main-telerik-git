using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Init
{
    public static class StringExtensions
    {
        public static int CountWords(this string input)
        {
            var words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int result = words.Length;
            return result;
        }


    }
}

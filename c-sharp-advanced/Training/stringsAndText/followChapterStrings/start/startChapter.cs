using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace start
{
    class startChapter
    {
        static void Main()
        {

            string str1 = "c#";
            string str2 = "C#";

            bool isEqual = str1.Equals(str2, StringComparison.CurrentCultureIgnoreCase);

            Console.WriteLine(isEqual);
            Console.WriteLine("==========");

            string compareone = "Hell";
            string comparetwo = "hell";

            int result = compareone.CompareTo(comparetwo); // -1 if one < two; 0 if one == two; 1 if one > two CAPITAL IS AFTER LOWERCASE

            Console.WriteLine(result);

            Console.WriteLine("==========");

            int resultTwo = string.Compare(compareone, comparetwo, StringComparison.CurrentCultureIgnoreCase); // compares and ignores capitalcasing
            int resultThree = string.Compare(compareone, comparetwo); // same as CompareTo maybe a bit more elegant
            Console.WriteLine(resultTwo);
            Console.WriteLine(resultThree);
            Console.WriteLine("==========");




        }
    }
}

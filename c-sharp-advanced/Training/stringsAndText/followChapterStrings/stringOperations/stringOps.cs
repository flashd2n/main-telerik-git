using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace stringOperations
{
    class stringOps
    {
        static void Main()
        {
            string filePath = @"c:/pics/coolpics.jpg";

            string fileName = filePath.Substring(filePath.IndexOf("coolpics"), 8);
            string fileExt = filePath.Substring(filePath.IndexOf(".") + 1, 3);

            Console.WriteLine(fileName);
            Console.WriteLine(fileExt);

            Console.WriteLine("==========");

            string listofbeers = "Amstel, Heineken, Tuborg, Becks";
            char[] separators = {' ', ',', '.' };
            string[] beers = listofbeers.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("==========");

            string doc = "hello, some@gmail.com!";
            string fixedDoc = doc.Replace("some@gmail.com", "k.kostov.eu@gmail.com");
            Console.WriteLine(fixedDoc);

            Console.WriteLine("==========");

            string personalInfo = "Smith's number: 0898880022\nFranky can be found at 0888445566.\nSteven's mobile number: 0887654321";
            string replacedInfo = Regex.Replace(personalInfo, "(08)[0-9]{8}", "$1********");
            Console.WriteLine(replacedInfo);

            Console.WriteLine("==========");

            string fileData = "   111 $  %    David Allen  ### s   ";
            char[] trimChars = new char[] { ' ', '1', '$', '%', '#', 's' };
            string reduced = fileData.Trim(trimChars);
            // reduced = "David Allen"
        }
    }
}

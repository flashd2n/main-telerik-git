using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sysRng
{
    class passwordGenerator
    {
        private const string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string smallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string digits = "0123456789";
        private const string specialChars = "~!@#$%^&*()_+=`{}[]\\|':;.,/?<>";
        private const string allChars = capitalLetters + smallLetters + digits + specialChars;
        private static Random rnd = new Random(); 

        static void Main()
        {
            var password = new StringBuilder();
            char character;
            // populate two capital letters

            for (int i = 0; i < 2; i++)
            {
                character = GenerateChar(capitalLetters);
                InsertAtRandomPosition(password, character);
            }

            // populate two small letters

            for (int i = 0; i < 2; i++)
            {
                character = GenerateChar(smallLetters);
                InsertAtRandomPosition(password, character);
            }

            // populate one digit

            character = GenerateChar(digits);
            InsertAtRandomPosition(password, character);

            // populate three special chars

            for (int i = 0; i < 3; i++)
            {
                character = GenerateChar(specialChars);
                InsertAtRandomPosition(password, character);
            }

            // populate 0-7 random chars

            int length = rnd.Next(8);
            for (int i = 0; i < length; i++)
            {
                character = GenerateChar(allChars);
                InsertAtRandomPosition(password, character);
            }

            Console.WriteLine(password);

            string end = Console.ReadLine();

            if (end == "end")
            {

            }
            else
            {
                Main();
            }
        }

        private static void InsertAtRandomPosition(StringBuilder password, char character)
        {
            int index = rnd.Next(password.Length + 1);
            password = password.Insert(index, character);
        }

        private static char GenerateChar(string selection)
        {
            int index = rnd.Next(selection.Length);
            char result = selection[index];
            return result;
        }
    }
}

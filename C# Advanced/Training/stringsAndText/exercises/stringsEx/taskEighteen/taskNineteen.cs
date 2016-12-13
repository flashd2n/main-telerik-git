using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace taskEighteen
{
    class taskNineteen
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int cycles = GetCycles(input);
            int index = -1;
            bool isEmail = false;
            var validEmails = new List<string>();

            for (int i = 0; i < cycles; i++)
            {
                index = input.IndexOf("@", index + 1);
                if (index == 0)
                {
                    continue;
                }
                else if (index == input.Length - 1)
                {
                    break;
                }

                string sender = GetSender(input, index);
                string domain = GetDomain(input, index).TrimEnd('.');
                string email = sender + "@" + domain;
                isEmail = CheckEmail(email);

                if (isEmail)
                {
                    validEmails.Add(email);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(string.Join("\n", validEmails));
        }

        static bool CheckEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string GetDomain(string input, int index)
        {
            int count = index + 1;
            string result = null;

            while (input[count] != ' ')
            {
                
                result += input[count];
                ++count;
                if (count == input.Length)
                {
                    break;
                }

            }

            return result;

        }

        static string GetSender(string input, int index)
        {
            int count = index - 1;
            string result = null;

            while (input[count] != ' ')
            {
                
                result = input[count] + result;
                --count;
                if (count == -1)
                {
                    break;
                }

            }

            return result;
        }

        static int GetCycles(string input)
        {
            int result = 0;
            int index = input.IndexOf("@");

            while (index != -1)
            {
                ++result;
                index = input.IndexOf("@", index + 1);
            }
            return result;
        }
    }
}

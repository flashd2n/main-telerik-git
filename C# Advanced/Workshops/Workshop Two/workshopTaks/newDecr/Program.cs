using System;
using System.Text;

namespace newDecr
{
    class Program
    {
        static int lastCypher = 0;

        static void Main()
        {
            string input = Console.ReadLine();
            int lengthCypher = GetLength(input); // works so far
            string messageToDecode = GetMsgToDecode(input, lengthCypher);

            string messageAndCypher = DecodeMsg(messageToDecode);

            string message = GetMessage(messageAndCypher, lengthCypher);

            string cypher = GetCypher(messageAndCypher, message);

            string output = Encrypt(message, cypher);

            Console.WriteLine(output);

        }

        static string Encrypt(string message, string cypher)
        {
            var encryptedMsg = new StringBuilder();
            if (message.Length >= cypher.Length)
            {
                for (int i = 0, j = 0; i < message.Length; i++, j++)
                {
                    if (j == cypher.Length)
                    {
                        j = 0;
                    }
                    char tempCode = (char)(((message[i] - 65) ^ (cypher[j] - 65)) + 65);
                    encryptedMsg.Append(tempCode);

                }
                return encryptedMsg.ToString();
            }
            else
            {
                var chars = message.ToCharArray();
                for (int i = 0, j = 0; i < cypher.Length; i++, j++)
                {

                    if (j == message.Length)
                    {
                        j = 0;
                    }

                    chars[j] = (char)(((chars[j] - 65) ^ (cypher[i] - 65)) + 65);
                }
                encryptedMsg.Append(chars);

                return encryptedMsg.ToString();
            }
        }

        static string GetCypher(string messageAndCypher, string message)
        {
            string cypher = null;
            for (int i = message.Length; i < messageAndCypher.Length; i++)
            {
                cypher += messageAndCypher[i];
            }
            return cypher;
        }

        static string GetMessage(string messageAndCypher, int lengthCypher)
        {
            string message = null;

            for (int i = 0; i < (messageAndCypher.Length - lengthCypher); i++)
            {
                message += messageAndCypher[i];
            }

            return message;
        }

        static string DecodeMsg(string messageToDecode)
        {
            int numChar = 0;
            char symb;

            for (int i = 0; i < messageToDecode.Length; i++)
            {
                if (Char.IsDigit(messageToDecode[i]) == true)
                {
                    numChar = int.Parse(messageToDecode[i].ToString());
                    symb = messageToDecode[i + 1];
                    messageToDecode = messageToDecode.Remove(i, 2);

                    for (int j = 0; j < numChar; j++)
                    {
                        messageToDecode = messageToDecode.Insert(i, symb.ToString());
                    }
                }
            }
            return messageToDecode;
        }

        static string GetMsgToDecode(string input, int lengthCypher)
        {
            string messageToDecode = null;
            for (int i = lastCypher; i >= 0; i--)
            {
                messageToDecode += input[i];
            }

            messageToDecode = ReverseString(messageToDecode);
            return messageToDecode;
        }

        static int GetLength(string input)
        {
            string digits = null;
            int lengthCypher = 0;
            for (int i = (input.Length - 1); i >= 0; i--)
            {
                if (Char.IsDigit(input[i]) == true)
                {
                    digits += input[i];
                    lastCypher = i - 1;
                }
                else
                {
                    break;
                }
            }

            if (digits.Length > 1)
            {
                digits = ReverseString(digits);
                lengthCypher = int.Parse(digits);
            }
            else
            {
                lengthCypher = int.Parse(digits);
            }
            return lengthCypher;
        }

        static string ReverseString(string input)
        {
            var result = new StringBuilder(input.Length);
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }

            return result.ToString();
        }
    }
}

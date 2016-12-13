using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decodeDecrypt
{
    class decodeDecrypt
    {
        static void Main()
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();

            string encryptedMsg = Encrypt(message, cypher);
            string encodeMsg = Encode(encryptedMsg + cypher) + cypher.Length;

            Console.WriteLine(encodeMsg);

        }

        static string Encode(string forEncoding)
        {
            string encoded = null;
            int counter = 1;

            for (int i = 0; i < forEncoding.Length; i++)
            {
                if (i == forEncoding.Length - 1 && counter == 1)
                {
                    encoded += forEncoding[i].ToString();
                    break;
                }
                else if (i == forEncoding.Length - 1 && counter == 2)
                {
                    encoded += forEncoding[i].ToString() + forEncoding[i].ToString();
                    break;
                }

                if (forEncoding[i] == forEncoding[i + 1])
                {

                    ++counter;
                }
                else if (forEncoding[i] != forEncoding[i + 1] && counter > 2)
                {
                    encoded += counter.ToString() + forEncoding[i];
                    counter = 1;
                }
                else if (forEncoding[i] != forEncoding[i + 1] && counter == 1)
                {
                    encoded += forEncoding[i].ToString();
                }
                else if (forEncoding[i] != forEncoding[i + 1] && counter == 2)
                {
                    encoded += forEncoding[i].ToString() + forEncoding[i].ToString();
                }
            }

            return encoded;
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
    }
}

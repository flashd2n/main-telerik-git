using System;
using System.Numerics;

namespace SecretNumeralSystem
{
    class SecretNumeralsystems
    {
        static void Main()
        {
            var keys = new string[] { "vladimir", "vlad", "hristofor", "hristo", "tosho", "pesho", "haralampi", "zoro"};
            var value = new int[] { 7 ,4, 3, 0, 1, 2, 5, 6};
            string input = Console.ReadLine();
            var separator = new string[] {", " };
            var words = input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            BigInteger result = 1;

            for (int i = 0; i < words.Length; i++)
            {
                result *= GetValues(words[i], keys, value);
            }
            Console.WriteLine(result);
        }

        static BigInteger GetValues(string word, string[] keys, int[] value)
        {
            do
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    word = word.Replace(keys[i], value[i].ToString());
                }
            } while (CheckDigits(word));

            BigInteger decValue = ConvertToDecimal(word);

            return decValue;
        }

        static BigInteger ConvertToDecimal(string word)
        {
            byte baseInput = 8;
            string input = word;

            BigInteger inputDec = 0;
            byte hexValue;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 65)
                {
                    hexValue = (byte)(input[i] - 55);
                    inputDec = inputDec * baseInput + hexValue;
                }
                else
                {
                    inputDec = inputDec * baseInput + ((BigInteger)input[i] - 48);
                }
            }

            return inputDec;
        }

        static bool CheckDigits(string word)
        {
            foreach (var c in word)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

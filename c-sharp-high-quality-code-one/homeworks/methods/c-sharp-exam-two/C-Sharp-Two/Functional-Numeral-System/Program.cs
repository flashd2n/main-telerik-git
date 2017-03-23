using System;
using System.Numerics;
using System.Linq;

namespace functionalNumeralSystem
{
    class Program
    {
        static string[] keys = new string[] { "standardml", "ocaml", "ml", "commonlisp", "lisp", "haskell", "scala", "f#", "rust", "clojure", "erlang", "racket", "elm", "mercury", "scheme", "curry" };
        static string[] value = new string[] { "9", "0", "6", "D", "4", "1", "2", "3", "5", "7", "8", "A", "B", "C", "E", "F" };

        static void Main()
        {
            string[] separator = new string[] { ", " };
            var words = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
            BigInteger temp = new BigInteger();
            BigInteger result = new BigInteger();
            result = 1;

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = CovertToClassicHex(words[i]);
            }

            for (int i = 0; i < words.Length; i++)
            {
                temp = ConvertToDec(words[i]);
                result *= temp;
            }
            Console.WriteLine(result);
        }

        static BigInteger ConvertToDec(string word)
        {
            byte baseInput = 16;
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
                    inputDec = inputDec * baseInput + (input[i] - 48);
                }
            }

            return inputDec;
        }

        static string CovertToClassicHex(string word)
        {

            for (int i = 0; i < keys.Count(); i++)
            {
                word = word.Replace(keys[i], value[i]);
            }

            return word;
        }
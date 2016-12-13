using System;
using System.Numerics;

namespace messages
{
    class msgs
    {
        static void Main()
        {
            string firstNumber = Console.ReadLine();
            string whatAction = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            var setChars = new char[3];
            string numberOne = null;
            string numberTwo = null;
            int currentNumber = 0;

            for (int i = 0; i < firstNumber.Length - 1; i = i + 3)
            {
                firstNumber.CopyTo(i, setChars, 0, 3);
                string subString = new string(setChars);
                
                switch (subString)
                {
                    case "cad":
                        currentNumber = 0;
                        break;
                    case "xoz":
                        currentNumber = 1;
                        break;
                    case "nop":
                        currentNumber = 2;
                        break;
                    case "cyk":
                        currentNumber = 3;
                        break;
                    case "min":
                        currentNumber = 4;
                        break;
                    case "mar":
                        currentNumber = 5;
                        break;
                    case "kon":
                        currentNumber = 6;
                        break;
                    case "iva":
                        currentNumber = 7;
                        break;
                    case "ogi":
                        currentNumber = 8;
                        break;
                    case "yan":
                        currentNumber = 9;
                        break;
                    default:
                        Console.WriteLine("switch error");
                        break;
                }
                numberOne += currentNumber;
            }

            for (int i = 0; i < secondNumber.Length - 1; i = i + 3)
            {
                secondNumber.CopyTo(i, setChars, 0, 3);
                string subString = new string(setChars);

                switch (subString)
                {
                    case "cad":
                        currentNumber = 0;
                        break;
                    case "xoz":
                        currentNumber = 1;
                        break;
                    case "nop":
                        currentNumber = 2;
                        break;
                    case "cyk":
                        currentNumber = 3;
                        break;
                    case "min":
                        currentNumber = 4;
                        break;
                    case "mar":
                        currentNumber = 5;
                        break;
                    case "kon":
                        currentNumber = 6;
                        break;
                    case "iva":
                        currentNumber = 7;
                        break;
                    case "ogi":
                        currentNumber = 8;
                        break;
                    case "yan":
                        currentNumber = 9;
                        break;
                    default:
                        Console.WriteLine("switch error");
                        break;
                }
                numberTwo += currentNumber;
            }

            // I have numberOne and numberTwo as strings

            BigInteger finalNumOne = BigInteger.Parse(numberOne);
            BigInteger finalNumTwo = BigInteger.Parse(numberTwo);
            BigInteger finalResultNum = 0;

            if (whatAction == "-")
            {
                finalResultNum = finalNumOne - finalNumTwo;
            }
            else
            {
                finalResultNum = finalNumOne + finalNumTwo;
            }

            // works for now

            string finalString = finalResultNum.ToString();
            string tempStringAnswer = null;
            string finalAnswer = null;

            for (int i = 0; i < finalString.Length; i++)
            {
                switch (finalString[i])
                {
                    case '0':
                        tempStringAnswer = "cad";
                        break;
                    case '1':
                        tempStringAnswer = "xoz";
                        break;
                    case '2':
                        tempStringAnswer = "nop";
                        break;
                    case '3':
                        tempStringAnswer = "cyk";
                        break;
                    case '4':
                        tempStringAnswer = "min";
                        break;
                    case '5':
                        tempStringAnswer = "mar";
                        break;
                    case '6':
                        tempStringAnswer = "kon";
                        break;
                    case '7':
                        tempStringAnswer = "iva";
                        break;
                    case '8':
                        tempStringAnswer = "ogi";
                        break;
                    case '9':
                        tempStringAnswer = "yan";
                        break;
                    default:
                        Console.WriteLine("switch error");
                        break;
                }

                finalAnswer += tempStringAnswer;
            }
            Console.WriteLine(finalAnswer);
        }
    }
}

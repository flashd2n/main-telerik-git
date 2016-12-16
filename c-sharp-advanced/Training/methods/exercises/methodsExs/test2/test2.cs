using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var inputTrasform = input.Split(' ');
            string workInput = string.Join("", inputTrasform);
            string expression = GetExpression(workInput);
            Console.WriteLine(expression);

        }

        static string GetExpression(string input)
        {
            var expression = new List<string>();
            int indexOpenBrackets = input.IndexOf('(');
            int indexCloseBrackets = input.IndexOf(')');
            bool isNegative = false;
            string temp = null;

            if (indexOpenBrackets != 0)
            {
                temp = input.Substring(0, indexOpenBrackets);
                temp = temp.TrimEnd();
                if (temp[temp.Length - 1] == '+')
                {
                    isNegative = false;
                }
                else
                {
                    isNegative = true;
                }
                temp = temp.Remove(temp.Length - 1);

                temp = SpaceOut(temp);

                if (temp[0] == '-')
                {
                    temp = temp.Remove(0, 1);
                    temp = "- " + temp;
                }
                else
                {
                    temp = "+ " + temp;
                }

                expression.Add(temp);
            }

            while (indexOpenBrackets != -1)
            {
                temp = input.Substring(indexOpenBrackets + 1, (indexCloseBrackets - 1) - indexOpenBrackets);
                temp = SpaceOut(temp);
                if (isNegative)
                {
                    temp = ReverseSign(temp);
                }
                else
                {
                    if (temp[0] == '-')
                    {
                        temp = temp.Remove(0, 1);
                        temp = "- " + temp;
                    }
                    else
                    {
                        temp = "+ " + temp;
                    }
                }
                expression.Add(temp);

                for (int i = indexCloseBrackets; i < input.Length; i++)
                {
                    if (input[i] == '+')
                    {
                        isNegative = false;
                        break;
                    }
                    else if (input[i] == '-')
                    {
                        isNegative = true;
                        break;
                    }
                }
                indexOpenBrackets = input.IndexOf('(', indexCloseBrackets + 1);
                indexCloseBrackets = input.IndexOf(')', indexCloseBrackets + 1);
            }
            string result = string.Join(" ", expression);
            return result;
        }

        static string SpaceOut(string temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == 0)
                {
                    continue;
                }
                if (temp[i] == '+')
                {
                    temp = temp.Insert(i, " ");
                    temp = temp.Insert(i + 2, " ");
                    i += 3;
                }

                if (temp[i] == '-')
                {
                    temp = temp.Insert(i, " ");
                    temp = temp.Insert(i + 2, " ");
                    i += 3;
                }
            }
            return temp;

        }

        static string ReverseSign(string temp)
        {
            var elements = temp.Split(' ');

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "+")
                {
                    elements[i] = "-";
                }
                else if (elements[i] == "-")
                {
                    elements[i] = "+";
                }
                if (i == 0)
                {
                    if (elements[i][0] == '-')
                    {
                        elements[i] = elements[i].Remove(0, 1);
                        elements[i] = "+ " + elements[i];
                    }
                    else
                    {
                        elements[i] = "- " + elements[i];
                    }
                }
            }
            var result = string.Join(" ", elements);
            return result;
        }
    }
}

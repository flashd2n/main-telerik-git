using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskTwelve
{
    class taskTwelve
    {
        static void Main()
        {
            string equation = Console.ReadLine();
            var separators = new char[] { '(', ')'};
            var equationElements = equation.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            char[] operands = GetOperands(equationElements);
            string tempOperation = null;

            if (operands.Length == 0)
            {
                Console.WriteLine(equationElements[0]);
            }
            else
            {
                for (int i = 0; i < operands.Length; i++)
                {
                    if (operands[i] == '+')
                    {
                        if (i == 0)
                        {
                            tempOperation = PerformAddition(equationElements[i], equationElements[i + 2]);
                        }
                        else
                        {
                            tempOperation = PerformAddition(tempOperation, equationElements[i + 2]);
                        }
                    }
                    else if (operands[i] == '-')
                    {
                        if (i == 0)
                        {
                            tempOperation = PerformAddition(equationElements[i], equationElements[i + 2]);
                        }
                        else
                        {
                            tempOperation = PerformAddition(tempOperation, equationElements[i + 2]);
                        }
                    }
                }
                Console.WriteLine(tempOperation);


            }
        }

        static string PerformAddition(string operandOne, string operandTwo)
        {
            string fullExpression = operandOne + " + " + operandTwo;
            var expressionElements = fullExpression.Split(' ');
            var indexes = new List<int>();
            var result = new StringBuilder();
            string temp = null;

            for (int i = 0; i < expressionElements.Length; i++)
            {
                if (expressionElements[i] == "+" || expressionElements[i] == "-" || expressionElements[i] == "")
                {
                    continue;
                }

                indexes.Add(i);
                if (CheckX(expressionElements[i]))
                {
                    // has x
                    int powerX = GetPowerX(expressionElements[i]);
                    int countX = GetCountX(expressionElements[i]);

                    for (int j = 0; j < expressionElements.Length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        else if (expressionElements[j] == "+")
                        {
                            continue;
                        }
                        else if (expressionElements[j] == "-")
                        {
                            continue;
                        }
                        else if (expressionElements[j] == "")
                        {
                            continue;
                        }

                        if (CheckX(expressionElements[j]) && GetPowerX(expressionElements[j]) == powerX)
                        {
                            if (expressionElements[j - 1] == "-")
                            {

                                countX -= GetCountX(expressionElements[j]);
                            }
                            else
                            {
                                countX += GetCountX(expressionElements[j]);
                            }
                            
                            indexes.Add(j);
                        }
                    }
                    if (countX == 0 && powerX == 0)
                    {
                        temp = "x";
                    }
                    else if (countX == 1)
                    {
                        temp = "x" + "^" + powerX.ToString();
                    }
                    else if (powerX == 0)
                    {
                        temp = countX.ToString() + "x";
                    }
                    else
                    {
                        temp = countX.ToString() + "x" + "^" + powerX.ToString();
                    }
                    

                    result.Append(temp);
                    CleanExpressionElements(expressionElements, indexes);
                    indexes.Clear();
                    if (i == expressionElements.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        string nextValidOperand = GetNextValidOperand(expressionElements, i);
                        if (nextValidOperand == "")
                        {
                            break;
                        }
                        else
                        {
                            result.Append(" ");
                            result.Append(nextValidOperand);
                            result.Append(" ");
                        }

                    }




                }
                else
                {
                    // number, no x
                    int pureNumber = 0;
                    if (i == 0)
                    {
                        pureNumber = int.Parse(expressionElements[i]);
                    }
                    else
                    {
                        pureNumber = GetPureNumber(expressionElements[i], expressionElements[i - 1]); // get the number and check the sign before it (make negative if necessary)
                    }

                    for (int j = 0; j < expressionElements.Length; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }

                        if (!CheckX(expressionElements[j]) && expressionElements[j] != "+" && expressionElements[j] != "-" && expressionElements[j] != "")
                        {
                            int number = GetPureNumber(expressionElements[j], expressionElements[j - 1]);
                            pureNumber += number;
                            indexes.Add(j);
                        }

                    }
                    temp = Math.Abs(pureNumber).ToString();
                    result.Append(temp);
                    CleanExpressionElements(expressionElements, indexes);
                    indexes.Clear();
                    if (i == expressionElements.Length - 1)
                    {
                        break;
                    }
                    else
                    {
                        string nextValidOperand = GetNextValidOperand(expressionElements, i);
                        if (nextValidOperand == "")
                        {
                            break;
                        }
                        else
                        {
                            result.Append(" ");
                            result.Append(nextValidOperand);
                            result.Append(" ");
                        }

                    }


                }


            }
            return result.ToString();
            
        }

        static int GetPureNumber(string expressionElement, string sign)
        {
            int result = int.Parse(expressionElement);
            if (sign == "-")
            {
                result = result * (-1);
            }
            return result;
        }

        static string GetNextValidOperand(string[] expressionElements, int start)
        {
            string result = "";
            for (int i = start + 1; i < expressionElements.Length; i++)
            {
                if (expressionElements[i] != "")
                {
                    result = expressionElements[i];
                    return result;
                }
            }
            return result;
        }

        static void CleanExpressionElements(string[] expressionElements, List<int> indexes)
        {
            for (int i = 0; i < indexes.Count; i++)
            {
                expressionElements[indexes[i]] = "";

                if (indexes[i] != 0)
                {
                    expressionElements[indexes[i] - 1] = "";
                }
            }
        }

        static int GetCountX(string expressionElement)
        {
            string counterString = null;
            int count = 1;
            if (expressionElement.IndexOf('x') == 0)
            {
                return count;
            }
            else
            {
                for (int i = 0; i < expressionElement.IndexOf('x'); i++)
                {
                    counterString += expressionElement[i];
                }
                count = int.Parse(counterString);

            }
            return count;
        }

        static int GetPowerX(string expressionElement)
        {
            string powerStr = null;
            int power = 0;
            if (expressionElement.IndexOf('x') == (expressionElement.Length - 1))
            {
                return 0;
            }
            else
            {
                for (int i = (expressionElement.IndexOf('x') + 1); i < expressionElement.Length; i++)
                {
                    powerStr += expressionElement[i];
                }
                power = int.Parse(powerStr);

            }
            return power;

        }

        static bool CheckX(string expressionElement)
        {
            if (expressionElement.IndexOf('x') != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static char[] GetOperands(string[] equationElements)
        {
            var temp = new List<string>();
            foreach (var element in equationElements)
            {
                if (element.Length == 3)
                {
                    temp.Add(element.Trim());
                }
            }
            char[] operands = string.Join("", temp).ToCharArray();
            return operands;
        }
    }
}

using System;
using System.Collections.Generic;

namespace taskTwelve2
{
    class taskTwelve2
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string expression = GetExpression(input);
            List<string> elementsExpression = GetElements(expression);
            int highestPower = GetHighestPower(elementsExpression);
            List<int> coefficients = PrepareList(highestPower);
            coefficients = GetCoefficients(coefficients, elementsExpression);
            string result = CalculateResult(coefficients);
            Console.WriteLine(result);
        }

        static string CalculateResult(List<int> coefficients)
        {
            var tempResult = new List<string>();
            int transform = 0;
            string build = null;

            for (int i = (coefficients.Count - 1); i >= 0; i--)
            {
                if (i == 0)
                {
                    if (coefficients[i] == 0)
                    {
                        break;
                    }

                    if (tempResult.Count == 0)
                    {
                        build = coefficients[i].ToString();
                        tempResult.Add(build);
                    }
                    else
                    {
                        if (coefficients[i] > 0)
                        {
                            build = "+ " + coefficients[i];
                            tempResult.Add(build);

                        }
                        else
                        {
                            transform = coefficients[i] * (-1);
                            build = "- " + transform;
                            tempResult.Add(build);
                        }
                    }
                    break;
                }
                else if (i == 1)
                {
                    if (coefficients[i] == 0)
                    {
                        continue;
                    }

                    if (tempResult.Count == 0)
                    {
                        build = coefficients[i] + "x";
                        tempResult.Add(build);
                    }
                    else
                    {
                        if (coefficients[i] > 0)
                        {
                            build = "+ " + coefficients[i] + "x";
                            tempResult.Add(build);
                        }
                        else
                        {
                            transform = coefficients[i] * (-1);
                            build = "- " + transform + "x";
                            tempResult.Add(build);
                        }
                    }
                    continue;
                }

                if (coefficients[i] == 0)
                {
                    continue;
                }
                else if (coefficients[i] < 0)
                {
                    if (tempResult.Count == 0)
                    {
                        build = coefficients[i] + "x^" + i;
                        tempResult.Add(build);
                    }
                    else
                    {
                        transform = coefficients[i] * (-1);
                        build = "- " + transform + "x^" + i;
                        tempResult.Add(build);
                    }
                }
                else if (coefficients[i] > 0)
                {
                    if (tempResult.Count == 0)
                    {
                        build = coefficients[i] + "x^" + i;
                        tempResult.Add(build);
                    }
                    else
                    {
                        build = "+ " + coefficients[i] + "x^" + i;
                        tempResult.Add(build);
                    }
                }


            }

            string result = string.Join(" ", tempResult);
            return result;

        }

        static List<int> GetCoefficients(List<int> coefficients, List<string> elementsExpression)
        {
            int coef = 0;
            int power = 0;
             
            for (int i = 0; i < elementsExpression.Count; i++)
            {
                coef = GetCoef(elementsExpression[i]);

                if (CheckX(elementsExpression[i]))
                {
                    power = GetPowerX(elementsExpression[i]);
                }
                else
                {
                    power = 0;
                }
                coefficients[power] += coef; 


            }

            return coefficients;

        }

        static int GetCoef(string expressionElement)
        {
            string counterString = null;
            int count = 1;
            if (expressionElement.IndexOf('x') == 0)
            {
                return count;
            }
            else if (expressionElement.IndexOf('x') != -1)
            {
                for (int i = 0; i < expressionElement.IndexOf('x'); i++)
                {
                    counterString += expressionElement[i];
                }

                if (counterString == "-")
                {
                    counterString = "-1";
                }

                count = int.Parse(counterString);
            }
            else
            {
                count = int.Parse(expressionElement);
            }

            return count;
        }



        static List<int> PrepareList(int highestPower)
        {
            var coefficients = new List<int>();
            for (int i = 0; i <= highestPower; i++)
            {
                coefficients.Add(0);
            }

            return coefficients;
        }

        static int GetHighestPower(List<string> elementsExpression)
        {
            int highestPower = int.MinValue;
            int powerX = 1;

            for (int i = 0; i < elementsExpression.Count; i++)
            {
                if (CheckX(elementsExpression[i]))
                {
                    powerX = GetPowerX(elementsExpression[i]);

                    if (powerX > highestPower)
                    {
                        highestPower = powerX;
                    }
                }
            }
            return highestPower;
        }

        static int GetPowerX(string expressionElement)
        {
            string powerStr = null;
            int power = 1;
            if (expressionElement.IndexOf('x') == (expressionElement.Length - 1))
            {
                return power;
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

        static List<string> GetElements(string expression)
        {
            var split = expression.Split(' ');
            var elements = new List<string>();

            for (int i = 0; i < split.Length; i += 2)
            {
                if (split[i] == "+")
                {
                    elements.Add(split[i + 1]);
                }
                else if (split[i] == "-")
                {
                    elements.Add("-" + split[i + 1]);
                }
            }

            return elements;
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
                temp = temp.Remove(temp.Length - 2, 2);

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

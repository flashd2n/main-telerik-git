using System;
using System.Collections.Generic;
using System.Linq;

namespace Harry_Potter_4D
{
    class Startup
    {
        static void Main()
        {
            var dimentions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var tesseract = new int[dimentions[0], dimentions[1], dimentions[2], dimentions[3]];
            var harryPostion = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numberOfBas = int.Parse(Console.ReadLine());
            var basiliscs = new string[numberOfBas];
            var basPositions = new int[numberOfBas, 4];
            for (int i = 0; i < numberOfBas; i++)
            {
                var input = Console.ReadLine().Split(' ');
                basiliscs[i] = input[0];
                for (int j = 0; j < 4; j++)
                {
                    basPositions[i, j] = int.Parse(input[j + 1]);
                }
            }


            int harryCounter = 0;
            string instructions = Console.ReadLine();
            bool isHarryAlive = true;

            while (instructions != "END")
            {
                var splitInstructions = instructions.Split(' ');
                string unit = splitInstructions[0];
                int dimention = GetDimention(splitInstructions);
                int step = int.Parse(splitInstructions[2]);

                if (unit == "@")
                {
                    harryPostion[dimention] = GetPosition(tesseract, step, harryPostion[dimention], dimention);
                    
                    ++harryCounter;

                    string basiliskKiller = CheckHarryMovement(harryPostion, basPositions, basiliscs);

                    if (basiliskKiller != "alive")
                    {
                        Console.WriteLine("{0}: \"Step {1} was the worst you ever made.\"\n{0}: \"You will regret until the rest of your life... All 3 seconds of it!\"", basiliskKiller, harryCounter);
                        isHarryAlive = false;
                        break;
                    }
                }
                else
                {
                    int indexBasilisk = Array.IndexOf(basiliscs, unit);

                    basPositions[indexBasilisk, dimention] = GetPosition(tesseract, step, basPositions[indexBasilisk, dimention], dimention);

                    if ((basPositions[indexBasilisk, 0] == harryPostion[0]) && (basPositions[indexBasilisk, 1] == harryPostion[1]) && (basPositions[indexBasilisk, 2] == harryPostion[2]) && (basPositions[indexBasilisk, 3] == harryPostion[3]))
                    {
                        Console.WriteLine("{0}: \"You thought you could escape, didn't you?\" - {1}", unit, harryCounter);
                        isHarryAlive = false;
                        break;
                    }
                }

                instructions = Console.ReadLine();
            }

            if (isHarryAlive)
            {
                Console.WriteLine("@: \"I am the chosen one!\" - {0}", harryCounter);
            }

        }

        static int GetPosition(int[,,,] tesseract, int step, int currentPosition, int dimention)
        {
            currentPosition = currentPosition + step;
            if (currentPosition < 0)
            {
                currentPosition = 0;
            }
            else if (currentPosition >= tesseract.GetLength(dimention))
            {
                currentPosition = tesseract.GetLength(dimention) - 1;
            }
            return currentPosition;
        }

        static string CheckHarryMovement(int[] harryPostion, int[,] basPositions, string[] basiliscs)
        {
            string result = "alive";
            var tempList = new List<string>();
            for (int i = 0; i < basPositions.GetLength(0); i++)
            {

                if ((harryPostion[0] == basPositions[i, 0]) && (harryPostion[1] == basPositions[i, 1]) && (harryPostion[2] == basPositions[i, 2]) && (harryPostion[3] == basPositions[i, 3]))
                {
                    tempList.Add(basiliscs[i]);
                }
            }

            if (tempList.Count == 0)
            {
                return result;
            }

            tempList.Sort();
            result = tempList[0];
            return result;
        }

        static int GetDimention(string[] splitInstructions)
        {
            int result;

            if (splitInstructions[1] == "A")
            {
                result = 0;
            }
            else if (splitInstructions[1] == "B")
            {
                result = 1;
            }
            else if (splitInstructions[1] == "C")
            {
                result = 2;
            }
            else
            {
                result = 3;
            }
            return result;
        }
    }
}

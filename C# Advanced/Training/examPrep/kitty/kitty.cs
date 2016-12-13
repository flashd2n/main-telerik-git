using System;
using System.Linq;

namespace kitty
{
    class kitty
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var soulFoodDeadlock = input.ToCharArray();

            var path = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int souls = 0;
            int food = 0;
            int deadlocks = 0;
            int counterSteps = 0;
            int position = 0;
            bool isAlive = true;

            do
            {
                if (soulFoodDeadlock[position] == '@')
                {
                    ++souls;
                    soulFoodDeadlock[position] = '0';
                }
                else if (soulFoodDeadlock[position] == '*')
                {
                    ++food;
                    soulFoodDeadlock[position] = '0';
                }
                else if (soulFoodDeadlock[position] == 'x')
                {
                    if (position % 2 == 0 && souls != 0)
                    {
                        --souls;
                        ++deadlocks;
                        soulFoodDeadlock[position] = '@';
                    }
                    else if (position % 2 == 0 && souls == 0)
                    {
                        isAlive = false;
                        break;
                    }
                    else if (position % 2 == 1 && food != 0)
                    {
                        --food;
                        ++deadlocks;
                        soulFoodDeadlock[position] = '*';
                    }
                    else if (position % 2 == 1 && food == 0)
                    {
                        isAlive = false;
                        break;
                    }
                }

                if (counterSteps == path.Count)
                {
                    break;
                }


                if (path[counterSteps] > 0)
                {
                    position = (position + path[counterSteps]) % soulFoodDeadlock.Length;
                }
                else
                {
                    position = (position + path[counterSteps]) % soulFoodDeadlock.Length;
                    if (position < 0)
                    {
                        position += soulFoodDeadlock.Length;
                    }
                }

                ++counterSteps;

            } while (counterSteps <= path.Count);

            if (isAlive)
            {
                Console.WriteLine("{0}{1}", "Coder souls collected: ", souls);
                Console.WriteLine("{0}{1}", "Food collected: ", food);
                Console.WriteLine("{0}{1}", "Deadlocks: ", deadlocks);
            }
            else
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("{0}{1}", "Jumps before deadlock: ", counterSteps);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvoidRoads
{
    class Startup
    {
        static void Main()
        {
            var one = 2;
            var two = 2;
            var bads = new string[] { "0 0 1 0", "1 2 2 2", "1 1 2 1" };

            Console.WriteLine(numWays(one, two, bads));
        }

        public static long numWays(int width, int height, string[] bad)
        {
            var badPairs = new List<Pair>();

            for (int i = 0; i < bad.Length; i++)
            {
                var input = bad[i].Split(' ').Select(int.Parse).ToArray();
                var pointOne = new Point(input[1], input[0]);
                var pointTwo = new Point(input[3], input[2]);
                var pair = new Pair(pointOne, pointTwo);
                badPairs.Add(pair);
            }

            var dp = new long[height + 1, width + 1];
            dp[0, 0] = 1;

            for (int i = 0; i <= height; i++)
            {
                for (int j = 0; j <= width; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    var fromUp = i == 0 ? 0 : dp[i - 1, j];
                    var fromLeft = j == 0 ? 0 : dp[i, j - 1];

                    // dali [i, j] + [i - 1, j] se sudurja v bad?
                    var pairA = new Pair(new Point(i, j), new Point(i - 1, j));

                    if (BadContainsPair(badPairs, pairA))
                    {
                        fromUp = 0;
                    }

                    // dali [i, j] + [i, j - 1] se sudurja v bad?
                    var pairB = new Pair(new Point(i, j), new Point(i, j - 1));
                    if (BadContainsPair(badPairs, pairB))
                    {
                        fromLeft = 0;
                    }


                    dp[i, j] = fromUp + fromLeft;
                }
            }


            return dp[height, width];
        }

        private static bool BadContainsPair(List<Pair> badPairs, Pair testPair)
        {
            foreach (var pair in badPairs)
            {
                if (pair.Equals(testPair))
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Pair
    {
        public Pair(Point one, Point two)
        {
            this.One = one;
            this.Two = two;
        }

        public Point One { get; set; }
        public Point Two { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Pair;

            if (this.One.Equals(other.One) && this.Two.Equals(other.Two))
            {
                return true;
            }

            if (this.One.Equals(other.Two) && this.Two.Equals(other.One))
            {
                return true;
            }

            return false;
        }
    }

    class Point
    {
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as Point;
            return this.X == other.X && this.Y == other.Y;
        }
    }
}

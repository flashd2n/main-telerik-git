namespace AvoidRoads
{
    class AvoidRoads
    {

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

            public override int GetHashCode()
            {
                return this.One.GetHashCode() + this.Two.GetHashCode();
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

            public override int GetHashCode()
            {
                return this.X.GetHashCode() + this.Y.GetHashCode();
            }
        }

        public long numWays(int width, int height, string[] bad)
        {
            var badPairs = new System.Collections.Generic.HashSet<Pair>();

            for (int i = 0; i < bad.Length; i++)
            {
                var input = bad[i].Split(' ');
                var pointOne = new Point(int.Parse(input[1]), int.Parse(input[0]));
                var pointTwo = new Point(int.Parse(input[3]), int.Parse(input[2]));
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

                    var pairA = new Pair(new Point(i, j), new Point(i - 1, j));

                    if (badPairs.Contains(pairA))
                    {
                        fromUp = 0;
                    }

                    var pairB = new Pair(new Point(i, j), new Point(i, j - 1));

                    if (badPairs.Contains(pairB))
                    {
                        fromUp = 0;
                    }

                    dp[i, j] = fromUp + fromLeft;
                }
            }


            return dp[height, width];
        }
    }
}

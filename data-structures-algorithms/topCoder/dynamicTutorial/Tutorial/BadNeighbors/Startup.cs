namespace BadNeighbors
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = new int[] { 94, 40, 49, 65, 21, 21, 106, 80, 92, 81, 679, 4, 61, 6, 237, 12, 72, 74, 29, 95, 265, 35, 47, 1, 61, 397, 52, 72, 37, 51, 1, 81, 45, 435, 7, 36, 57, 86, 81, 72 };
            var result = maxDonations(input);
            System.Console.WriteLine(result);
        }

        public static int maxDonations(int[] donations)
        {
            var dp = new int[donations.Length];

            var usesFirst = new bool[donations.Length];
            usesFirst[0] = true;

            for (int i = 0; i < donations.Length; i++)
            {
                dp[i] = donations[i];

                for (int j = 0; j < i; j++)
                {
                    if (i - 1 == j)
                    {
                        continue;
                    }

                    if (i == donations.Length - 1)
                    {
                        if (j == 0)
                        {
                            continue;
                        }

                        if (dp[j] + donations[i] > dp[i])
                        {
                            // is it using zero element?
                            if (usesFirst[j] == true)
                            {
                                var temp = dp[j] + donations[i];

                                if (temp - donations[0] > dp[i])
                                {
                                    dp[i] = temp - donations[0];
                                }
                            }
                            else
                            {
                                dp[i] = dp[j] + donations[i];
                            }
                        }
                        continue;
                    }

                    if (dp[j] + donations[i] > dp[i])
                    {

                        dp[i] = dp[j] + donations[i];

                        if (usesFirst[j] == true)
                        {
                            usesFirst[i] = true;
                        }
                        else
                        {
                            usesFirst[i] = false;
                        }
                    }

                }
            }

            System.Array.Sort(dp);

            return dp[dp.Length - 1];
        }
    }
}

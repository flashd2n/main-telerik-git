using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadNeighbors
{
    public class BadNeighbors
    {
        public int maxDonations(int[] donations)
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

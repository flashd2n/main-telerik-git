namespace ZigZag
{
    public class ZigZag
    {
        public int longestZigZag(int[] sequence)
        {
            var dp = new int[sequence.Length];
            var sign = new int[sequence.Length];

            dp[0] = 1;
            sign[0] = 0;

            for (int i = 1; i < sequence.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        continue;
                    }

                    if (sign[j] < 0 && (sequence[i] - sequence[j]) < 0 && (dp[j] + 1) > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        sign[i] = 1;
                        continue;
                    }

                    if (sign[j] > 0 && (sequence[i] - sequence[j]) > 0 && (dp[j] + 1) > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        sign[i] = -1;
                        continue;
                    }

                    if (sign[j] == 0)
                    {
                        dp[i] = dp[j] + 1;
                        sign[i] = sequence[i] > sequence[j] ? -1 : 1;
                        continue;
                    }

                }
            }

            System.Array.Sort(dp);

            return dp[dp.Length - 1];
        }
    }
}

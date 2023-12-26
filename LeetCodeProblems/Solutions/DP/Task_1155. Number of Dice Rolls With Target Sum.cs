namespace Solutions.DP
{
    internal class Task_1155
    {
        public int NumRollsToTarget(int n, int k, int target)
        {
            var dp = new int[n + 1][];
            for (var i = 0; i <= n; i++)
            {
                dp[i] = new int[target + 1];
                Array.Fill(dp[i], 0);
            }

            for (int i = 0; i <= k && i <= target; i++)
            {
                dp[1][i] = 1;
            }

            int mod = 1000000007;
            for (var i = 2; i <= n; i++)
            {
                for (var j = 1; j <= target; j++)
                {
                    dp[i][j] = 0;
                    if (i > j) continue;
                    for (var ind = 1; ind <= k; ind++)
                    {
                        if (j - ind > 0)
                        {
                            int x = dp[i - 1][j - ind] % mod;
                            dp[i][j] += x;
                            dp[i][j] %= mod;
                        }
                    }
                }
            }

            return dp[n][target] % mod;
        }
    }
}

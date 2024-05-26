﻿namespace Solutions.DP
{
    // #Dynamic Programming

    internal class Task_0552
    {
        public int CheckRecord(int n)
        {
            const int MOD = 1000000007;
            
            // dp[length][absent][late]
            int[,,] dp = new int[n + 1, 2, 3];

            // Base case: one valid sequence of length 0
            dp[0, 0, 0] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        // Ending with 'P'
                        dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j, k]) % MOD;

                        // Ending with 'A'
                        if (j > 0)
                        {
                            dp[i, j, 0] = (dp[i, j, 0] + dp[i - 1, j - 1, k]) % MOD;
                        }

                        // Ending with 'L'
                        if (k > 0)
                        {
                            dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j, k - 1]) % MOD;
                        }
                    }
                }
            }

            int result = 0;
            for (int j = 0; j <= 1; j++)
            {
                for (int k = 0; k <= 2; k++)
                {
                    result = (result + dp[n, j, k]) % MOD;
                }
            }

            return result;
        }
    }
}

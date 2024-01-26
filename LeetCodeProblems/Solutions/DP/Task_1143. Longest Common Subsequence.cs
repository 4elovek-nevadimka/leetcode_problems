namespace Solutions.DP
{
    internal class Task_1143
    {
        // #String #Dynamic Programming

        public int LongestCommonSubsequence(string text1, string text2)
        {
            return Solution2(text1, text2);
        }

        private int Solution1(string text1, string text2)
        {
            int n = text1.Length, m = text2.Length;
            var dp = new int[n][];

            for (var i = 0; i < n; i++)
            {
                dp[i] = new int[m];
                for (var j = 0; j < m; j++)
                {
                    if (text1[i] == text2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            dp[i][j] = 1;
                        }
                        else
                        {
                            dp[i][j] = dp[i - 1][j - 1] + 1;
                        }
                    }
                    else
                    {
                        if (i == 0 && j > 0)
                        {
                            dp[i][j] = dp[i][j - 1];
                        }
                        else if (j == 0 && i > 0)
                        {
                            dp[i][j] = dp[i - 1][j];
                        }
                        else if (j == 0 && i == 0)
                        {
                            dp[i][j] = 0;
                        }
                        else
                        {
                            dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                        }
                    }
                }
            }

            return dp[n - 1][m - 1];
        }

        // the same, but looks more clear
        private int Solution2(string text1, string text2)
        {
            int n = text1.Length, m = text2.Length;
            var dp = new int[n + 1][];
            // init
            for (var i = 0; i <= n; i++)
            {
                dp[i] = new int[m + 1];
            }
            // fill
            for (var i = 1; i <= n; i++)
            {
                for (var j = 1; j <= m; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                    }
                }
            }

            return dp[n][m];
        }
    }
}

namespace Solutions.DP
{
    internal class Task_1531
    {
        // #String #Dynamic Programming

        public void Run()
        {
            Console.WriteLine(GetLengthOfOptimalCompression("aaabcccd", 2));
        }

        public int GetLengthOfOptimalCompression(string s, int k)
        {
            var n = s.Length;
            var dp = new int[n + 1, k + 1];

            for (var i = n; i >= 0; i--)
            {
                for (var j = 0; j <= k; j++)
                {
                    if (i == n)
                    {
                        dp[n, j] = 0;
                    }
                    else
                    {
                        if (j > 0)
                        {
                            dp[i, j] = dp[i + 1, j - 1];
                        }
                        else
                        {
                            dp[i, j] = 999;
                        }

                        var remove = j;
                        var repeatCounter = 0;

                        for (var l = i; l < n && remove >= 0; l++)
                        {
                            if (s[l] == s[i])
                            {
                                repeatCounter++;
                                if (repeatCounter == 1)
                                {
                                    dp[i, j] = Math.Min(dp[i, j], 1 + dp[l + 1, remove]);
                                }
                                else if (repeatCounter < 10)
                                {
                                    dp[i, j] = Math.Min(dp[i, j], 2 + dp[l + 1, remove]);
                                }
                                else if (repeatCounter < 100)
                                {
                                    dp[i, j] = Math.Min(dp[i, j], 3 + dp[l + 1, remove]);
                                }
                                else
                                {
                                    dp[i, j] = Math.Min(dp[i, j], 4 + dp[l + 1, remove]);
                                }
                            }
                            else
                            {
                                remove--;
                            }
                        }
                    }
                }
            }

            return dp[0, k];
        }
    }
}

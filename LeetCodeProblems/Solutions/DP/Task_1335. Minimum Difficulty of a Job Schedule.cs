namespace Solutions.DP
{
    internal class Task_1335
    {
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            var n = jobDifficulty.Length;
            if (n < d) return -1;

            var dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue / 2);
            dp[n] = 0;

            for (var day = 1; day <= d; day++)
            {
                for (var i = 0; i <= n - day; i++)
                {
                    var maxDifficulty = 0;
                    dp[i] = int.MaxValue / 2;

                    for (int j = i; j <= n - day; j++)
                    {
                        maxDifficulty = Math.Max(maxDifficulty, jobDifficulty[j]);
                        dp[i] = Math.Min(dp[i], maxDifficulty + dp[j + 1]);
                    }
                }
            }
            return dp[0];
        }
    }
}

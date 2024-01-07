namespace Solutions.DP
{
    internal class Task_0446
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            var total = 0;
            var n = nums.Length;
            var dp = new Dictionary<int, int>[n];

            for (var i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<int, int>();
                for (var j = 0; j < i; j++)
                {
                    long longDiff = (long)nums[i] - nums[j];
                    if (longDiff > int.MaxValue || longDiff < int.MinValue)
                    {
                        continue;
                    }
                    int diff = (int)longDiff;
                    dp[i][diff] = dp[i].GetValueOrDefault(diff) + 1;
                    if (dp[j].ContainsKey(diff))
                    {
                        dp[i][diff] += dp[j][diff];
                        total += dp[j][diff];
                    }
                }
            }
            return total;
        }
    }
}

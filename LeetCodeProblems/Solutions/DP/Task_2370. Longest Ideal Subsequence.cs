namespace Solutions.DP
{
    internal class Task_2370
    {
        // #Hash Table #String #Dynamic Programming

        public int LongestIdealString(string s, int k)
        {
            var n = s.Length;
            var dp = new int[26];
            var longestIdealString = 0;

            for (var i = 0; i < n; i++)
            {
                var curr = s[i];
                var idx = curr - 'a';
                var longest = 0;

                for (var prev = 0; prev < 26; prev++)
                {
                    if (Math.Abs(curr - 'a' - prev) <= k)
                    {
                        longest = Math.Max(longest, dp[prev]);
                    }
                }

                dp[idx] = longest + 1;
                longestIdealString = Math.Max(longestIdealString, dp[idx]);
            }

            return longestIdealString;
        }
    }
}

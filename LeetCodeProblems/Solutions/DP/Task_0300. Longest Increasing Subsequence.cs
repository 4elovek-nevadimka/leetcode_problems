namespace Solutions.DP
{
    internal class Task_0300
    {
        // #Array #Binary Search #Dynamic Programming

        public int LengthOfLIS(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            var n = nums.Length;
            var longestRow = 0;

            var dp = new int[n];
            Array.Fill(dp, 1);
            for (var i = n - 1; i >= 0; i--)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                longestRow = Math.Max(longestRow, dp[i]);
            }

            return longestRow;
        }

        private int Solution2(int[] nums)
        {
            int c = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[c])
                {
                    nums[++c] = nums[i];
                    continue;
                }

                var idx = Array.BinarySearch(nums, 0, c, nums[i]);
                if (idx < 0)
                {
                    nums[~idx] = nums[i];
                }
            }
            return c + 1;
        }
    }
}

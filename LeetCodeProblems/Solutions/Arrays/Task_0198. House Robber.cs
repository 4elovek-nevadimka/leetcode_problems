namespace Solutions.Arrays
{
    internal class Task_0198
    {
        // #Array #Dynamic Programming

        public void Run()
        {
            // var nums = new[] { 2, 7, 9, 3, 1 };
            var nums = new[] { 2, 1, 2, 1, 3, 4, 2 };
            Console.Write(Rob(nums));
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            var dp = new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);
                // Console.WriteLine($"{i}: {dp[i]}");
            }
            return dp[nums.Length - 1];
        }
    }
}

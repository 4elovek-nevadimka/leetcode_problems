namespace Solutions.Arrays
{
    internal class Task_0368
    {
        // #Array #Math #Dynamic Programming #Sorting

        public void Run()
        {
            var nums = new[] { 1, 3, 5, 7, 9, 11, 30 };
            var result = LargestDivisibleSubset(nums);
            Console.WriteLine(String.Join(',', result));
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            Array.Sort(nums);
            var n = nums.Length;
            int maxSize = 1, maxIndex = 0;
            int[] dp = new int[n], prev = new int[n];

            for (int i = 0; i < n; i++)
            {
                dp[i] = 1;
                prev[i] = -1;

                for (int j = i - 1; j >= 0; j--)
                {
                    if (nums[i] % nums[j] == 0 && dp[j] + 1 > dp[i])
                    {
                        dp[i] = dp[j] + 1;
                        prev[i] = j;

                        if (dp[i] > maxSize)
                        {
                            maxSize = dp[i];
                            maxIndex = i;
                        }
                    }
                }
            }

            var result = new List<int>();
            while (maxIndex != -1)
            {
                result.Add(nums[maxIndex]);
                maxIndex = prev[maxIndex];
            }

            return result;
        }
    }
}

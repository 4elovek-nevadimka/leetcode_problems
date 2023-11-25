namespace Solutions
{
    internal class Task_1685
    {
        public void Run()
        {
            // var nums = new[] { 2, 3, 5 };
            var nums = new[] { 1, 4, 6, 8, 10 };
            var result = GetSumAbsoluteDifferences(nums);

            Array.ForEach(result, Console.WriteLine);
        }

        public int[] GetSumAbsoluteDifferences(int[] nums)
        {
            var n = nums.Length;

            var preSums = new int[n];
            preSums[0] = 0;
            for (var i = 1; i < n; i++)
            {
                preSums[i] = preSums[i - 1] + (nums[i] - nums[i - 1]) * i;
            }

            var postSums = new int[n];
            postSums[n - 1] = 0;
            for (var i = n - 2; i >= 0; i--)
            {
                postSums[i] = postSums[i + 1] + (nums[i + 1] - nums[i]) * (n - i - 1);
            }

            var result = new int[n];
            for (var i = 0; i < n; i++)
            {
                result[i] = preSums[i] + postSums[i];
            }

            return result;
        }
    }
}

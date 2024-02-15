namespace Solutions.Arrays
{
    internal class Task_2971
    {
        // #Array #Greedy #Sorting #Prefix Sum

        public void Run()
        {
            // var nums = new[] { 1, 12, 1, 2, 5, 50, 3 };
            var nums = new[] { 1, 11, 1, 2, 5, 14, 3 };
            Console.WriteLine(LargestPerimeter(nums));
        }

        public long LargestPerimeter(int[] nums)
        {
            return Solution2(nums);
        }

        private long Solution1(int[] nums)
        {
            Array.Sort(nums);
            var n = nums.Length;
            var prefixSums = new long[n];
            prefixSums[0] = nums[0];

            for (var i = 1; i < n; i++)
                prefixSums[i] = prefixSums[i - 1] + nums[i];

            for (var i = n - 2; i > 0; i--)
                if (prefixSums[i] > nums[i + 1])
                    return prefixSums[i + 1];

            return -1;
        }

        private long Solution2(int[] nums)
        {
            Array.Sort(nums);
            long sum = nums[0], answer = -1;

            for (var i = 1; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum - nums[i] > nums[i] && i > 1)
                    answer = sum;
            }

            return answer;
        }
    }
}

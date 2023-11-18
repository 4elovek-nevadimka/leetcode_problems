namespace Solutions
{
    internal class Task_1838
    {
        public void Run()
        {
            var nums = new[] { 1, 2, 4 };
            // var nums = new[] { 1, 4, 8, 13 };
            var k = 5;

            Console.WriteLine(MaxFrequency(nums, k));
        }

        public int MaxFrequency(int[] nums, int k)
        {
            return Solution1(nums, k);
        }

        private int Solution1(int[] nums, int k)
        {
            Array.Sort(nums);
            
            int left = 0, maxFrequency = 0;
            long sum = 0;

            for (var right = 0; right < nums.Length; right++)
            {
                sum += nums[right];
                while ((long)(nums[right] * (right - left + 1)) - sum > k)
                {
                    sum -= nums[left];
                    left++;
                }
                maxFrequency = Math.Max(maxFrequency, right - left + 1);
            }
            return maxFrequency;
        }
    }
}

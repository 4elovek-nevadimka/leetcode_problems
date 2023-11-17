namespace Solutions
{
    internal class Task_1877
    {
        public void Run()
        {
            var nums = new[] { 3, 5, 2, 3 };
            // var nums = new[] { 3, 5, 4, 2, 4, 6 };
            
            Console.WriteLine(MinPairSum(nums));
        }

        public int MinPairSum(int[] nums)
        {
            return Solution2(nums);
        }

        // sort
        public int Solution1(int[] nums)
        {
            Array.Sort(nums);
            var max = 0;
            var half = nums.Length / 2;
            for (var i = 0; i < half; i++)
            {
                var sum = nums[i] + nums[^(i + 1)];
                if (sum > max)
                    max = sum;
            }
            return max;
        }

        // freq
        public int Solution2(int[] nums)
        {
            int sum = 0, min = 0, max = 0;
            var frequencyArr = new int[100001];

            foreach (var num in nums)
            {
                frequencyArr[num]++;
                min = Math.Min(min, num);
                max = Math.Max(max, num);
            }

            int left = min, right = max;
            while (left <= right)
            {
                if (frequencyArr[left] == 0)
                    left++;
                else if (frequencyArr[right] == 0)
                    right--;
                else
                {
                    sum = Math.Max(sum, left + right);
                    frequencyArr[left]--;
                    frequencyArr[right]--;
                }
            }
            return sum;
        }
    }
}

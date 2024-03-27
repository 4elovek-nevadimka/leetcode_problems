namespace Solutions.Arrays
{
    internal class Task_0041
    {
        // #Array

        public void Run()
        {
            Console.WriteLine(FirstMissingPositive([1, 2, 0]));
            Console.WriteLine(FirstMissingPositive([3, 4, -1, 1]));
            Console.WriteLine(FirstMissingPositive([7, 8, 9, 11, 12]));
        }

        public int FirstMissingPositive(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            var n = nums.Length;
            for (var i = 0; i < n; i++)
                if (nums[i] <= 0 || nums[i] > n)
                    nums[i] = n + 1;

            for (var i = 0; i < n; i++)
            {
                var index = Math.Abs(nums[i]);
                if (index <= n)
                    if (nums[index - 1] > 0)
                        nums[index - 1] = -nums[index - 1];
            }

            for (var i = 0; i < n; i++)
                if (nums[i] > 0)
                    return i + 1;

            return n + 1;
        }

        private int Solution2(int[] nums)
        {
            int index = 0, n = nums.Length;
            while (index < n)
                if (nums[index] <= 0 || nums[index] >= n 
                    || nums[index] == index + 1 || nums[index] == nums[nums[index] - 1])
                    index++;
                else
                    (nums[index], nums[nums[index] - 1]) = (nums[nums[index] - 1], nums[index]);

            for (var i = 0; i < n; i++)
                if (nums[i] != i + 1)
                    return i + 1;

            return n + 1;
        }
    }
}

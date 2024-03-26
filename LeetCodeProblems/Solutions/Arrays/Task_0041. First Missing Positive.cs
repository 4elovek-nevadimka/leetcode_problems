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
    }
}

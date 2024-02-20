namespace Solutions.Arrays
{
    internal class Task_0268
    {
        // #Array #Hash Table #Math #Binary Search #Bit Manipulation #Sorting

        public int MissingNumber(int[] nums)
        {
            return Solution1(nums);
        }

        private int Solution1(int[] nums)
        {
            var n = nums.Length;
            return n * (n + 1) / 2 - nums.Sum();
        }

        private int Solution2(int[] nums)
        {
            var n = nums.Length;
            var xor = 0 ^ nums[0];
            for (var i = 1; i < n; i++)
                xor ^= nums[i] ^ i;
            return xor ^ n;
        }
    }
}

namespace Solutions.Arrays
{
    internal class Task_0995
    {
        // #Array #Bit Manipulation #Queue #Sliding Window #Prefix Sum

        public int MinKBitFlips(int[] nums, int k)
        {
            int currentFlips = 0, totalFlips = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (i >= k && nums[i - k] == 2)
                    currentFlips--;

                if ((currentFlips % 2) == nums[i])
                {
                    if (i + k > nums.Length)
                        return -1;

                    nums[i] = 2;
                    currentFlips++;
                    totalFlips++;
                }
            }

            return totalFlips;
        }
    }
}

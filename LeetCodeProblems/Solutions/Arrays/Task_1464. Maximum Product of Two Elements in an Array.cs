namespace Solutions.Arrays
{
    internal class Task_1464
    {
        // #Array #Sorting #Heap(Priority Queue)
        public int MaxProduct(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            Array.Sort(nums);
            return (nums[^1] - 1) * (nums[^2] - 1);
        }

        private int Solution2(int[] nums)
        {
            int maxA = 0, maxB = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= maxA)
                {
                    maxB = maxA;
                    maxA = nums[i];
                }
                else
                {
                    if (nums[i] > maxB)
                    {
                        maxB = nums[i];
                    }
                }

            }
            return (maxA - 1) * (maxB - 1);
        }
    }
}

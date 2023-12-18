namespace Solutions.Arrays
{
    internal class Task_1913
    {
        // #Array #Sorting

        public int MaxProductDifference(int[] nums)
        {
            return Solution2(nums);
        }

        private int Solution1(int[] nums)
        {
            Array.Sort(nums);
            return nums[^1] * nums[^2] - nums[0] * nums[1];
        }

        private int Solution2(int[] nums)
        {
            int maxA = 0, maxB = 0, minA = 10_000, minB = 10_000;
            for (var i = 0; i < nums.Length; i++)
            {
                // max values
                if (nums[i] > maxA)
                {
                    maxB = maxA; maxA = nums[i];
                }
                else if (nums[i] > maxB)
                {
                    maxB = nums[i];
                }

                // min values
                if (nums[i] < minA)
                {
                    minB = minA; minA = nums[i];
                }
                else if (nums[i] < minB)
                {
                    minB = nums[i];
                }

            }
            return maxA * maxB - minA * minB;
        }
    }
}

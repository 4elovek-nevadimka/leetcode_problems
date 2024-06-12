namespace Solutions.Arrays
{
    internal class Task_0075
    {
        // #Array #Two Pointers #Sorting

        public void SortColors(int[] nums)
        {
            
        }

        private void Solution1(int[] nums)
        {
            int zeros = 0, ones = 0;
            foreach (var num in nums)
                if (num == 0)
                    zeros++;
                else if (num == 1)
                    ones++;

            int index = 0;
            for (var i = 0; i < zeros; i++)
                nums[index++] = 0;

            for (var i = 0; i < ones; i++)
                nums[index++] = 1;

            while (index < nums.Length)
                nums[index++] = 2;
        }

        private void Solution2(int[] nums)
        {
            int left = 0, mid = 0, right = nums.Length - 1;
            while (mid <= right)
            {
                if (nums[mid] == 0)
                {
                    (nums[left], nums[mid]) = (nums[mid], nums[left]);
                    mid++;
                    left++;
                }
                else if (nums[mid] == 2)
                {
                    (nums[right], nums[mid]) = (nums[mid], nums[right]);
                    right--;
                }
                else
                    mid++;
            }
        }
    }
}

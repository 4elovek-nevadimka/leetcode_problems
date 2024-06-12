namespace Solutions.Arrays
{
    internal class Task_0075
    {
        // #Array #Two Pointers #Sorting

        public void SortColors(int[] nums)
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
    }
}

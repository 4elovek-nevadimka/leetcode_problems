namespace Solutions.Arrays
{
    internal class Task_2134
    {
        // #Array #Sliding Window

        public void Run()
        {
            MinSwaps([0, 1, 0, 1, 1, 0, 0]);
        }

        public int MinSwaps(int[] nums)
        {
            if (nums.Length == 1)
                return 0;

            var windowSize = 0;
            foreach (var num in nums)
                if (num == 1) windowSize++;

            var windowValue = 0;
            for (var i = 0; i < windowSize; i++)
                if (nums[i] == 1) windowValue++;

            int left = 1, right = left + windowSize - 1;
            var minSwaps = windowSize - windowValue;
            while (left < nums.Length)
            {
                if (right == nums.Length)
                    right = 0;

                if ((nums[left - 1] == 1) && (nums[right] == 0))
                    windowValue--;
                else if ((nums[left - 1] == 0) && (nums[right] == 1))
                    windowValue++;

                minSwaps = Math.Min(minSwaps, windowSize - windowValue);
                left++;
                right++;
            }

            return minSwaps;
        }
    }
}

namespace Solutions.Arrays
{
    internal class Task_2962
    {
        // #Array #Sliding Window

        public long CountSubarrays(int[] nums, int k)
        {
            var maxNum = 0;
            foreach (var num in nums)
                maxNum = Math.Max(maxNum, num);

            long result = 0;
            int left = 0, maxLength = 0;
            for (var right = 0; right < nums.Length; right++)
            {
                if (nums[right] == maxNum)
                    maxLength++;

                while (k == maxLength)
                    if (nums[left++] == maxNum)
                        maxLength--;

                result += left;
            }

            return result;   
        }
    }
}

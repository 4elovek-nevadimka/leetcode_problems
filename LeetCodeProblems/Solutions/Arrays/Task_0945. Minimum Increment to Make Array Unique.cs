namespace Solutions.Arrays
{
    internal class Task_0945
    {
        // #Array #Greedy #Sorting #Counting

        public int MinIncrementForUnique(int[] nums)
        {
            Array.Sort(nums);
            var count = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                {
                    var diff = nums[i - 1] - nums[i] + 1;
                    nums[i] += diff;
                    count += diff;
                }
            }

            return count;
        }
    }
}

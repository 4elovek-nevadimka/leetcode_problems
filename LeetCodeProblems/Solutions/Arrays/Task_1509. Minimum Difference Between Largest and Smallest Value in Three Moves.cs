namespace Solutions.Arrays
{
    internal class Task_1509
    {
        // #Array #Greedy #Sorting
        public int MinDifference(int[] nums)
        {
            if (nums.Length <= 4)
                return 0;

            Array.Sort(nums);

            var min1 = 
                Math.Min(nums[^1] - nums[3], nums[^2] - nums[2]);
            var min2 = 
                Math.Min(nums[^3] - nums[1], nums[^4] - nums[0]);

            return Math.Min(min1, min2);
        }
    }
}

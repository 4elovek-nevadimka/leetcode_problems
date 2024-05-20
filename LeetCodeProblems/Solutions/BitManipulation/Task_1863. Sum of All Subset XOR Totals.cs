namespace Solutions.BitManipulation
{
    internal class Task_1863
    {
        // #Array #Math #Backtracking #Bit Manipulation #Combinatorics #Enumeration

        public int SubsetXORSum(int[] nums)
        {
            return SubsetXORSumHelper(nums, 0, 0);
        }

        private int SubsetXORSumHelper(int[] nums, int index, int curXOR)
        {
            if (index == nums.Length)
                return curXOR;

            return SubsetXORSumHelper(nums, index + 1, curXOR) +
                SubsetXORSumHelper(nums, index + 1, curXOR ^ nums[index]);
        }
    }
}

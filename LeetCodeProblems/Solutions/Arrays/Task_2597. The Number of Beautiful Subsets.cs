namespace Solutions.Arrays
{
    internal class Task_2597
    {
        // #Array #Dynamic Programming #Backtracking #Sorting

        public int BeautifulSubsets(int[] nums, int k)
        {
            Array.Sort(nums);
            var count = new Dictionary<int, int>();
            return BeautifulSubsetsHelper(nums, k, 0, count);
        }

        private int BeautifulSubsetsHelper(int[] nums, int k, int start, Dictionary<int, int> count)
        {
            var subsets = 0;

            for (var i = start; i < nums.Length; ++i)
            {
                if (count.ContainsKey(nums[i] - k) && count[nums[i] - k] > 0)
                    continue;

                count[nums[i]] = count.ContainsKey(nums[i]) ? count[nums[i]] + 1 : 1;
                subsets += 1 + BeautifulSubsetsHelper(nums, k, i + 1, count);
                count[nums[i]]--;

                if (count[nums[i]] == 0)
                    count.Remove(nums[i]);
            }

            return subsets;
        }
    }
}

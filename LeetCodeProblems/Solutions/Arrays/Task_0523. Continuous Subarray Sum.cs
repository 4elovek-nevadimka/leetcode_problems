namespace Solutions.Arrays
{
    internal class Task_0523
    {
        // #Array #Hash Table #Math #Prefix Sum

        public bool CheckSubarraySum(int[] nums, int k)
        {
            var remainderMap = new Dictionary<int, int> { [0] = -1 };
            var cumulativeSum = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                cumulativeSum += nums[i];
                var remainder = cumulativeSum % k;

                if (remainder < 0)
                    remainder += k;

                if (remainderMap.ContainsKey(remainder))
                {
                    if (i - remainderMap[remainder] > 1)
                        return true;
                }
                else
                {
                    remainderMap[remainder] = i;
                }
            }

            return false;
        }
    }
}

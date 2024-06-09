namespace Solutions.Arrays
{
    internal class Task_0974
    {
        // #Array #Hash Table #Prefix Sum

        public int SubarraysDivByK(int[] nums, int k)
        {
            var remainderMap = new Dictionary<int, int> { [0] = -1 };
            int cumulativeSum = 0, count = 0;

            foreach (var num in nums)
            {
                cumulativeSum += num;
                var remainder = cumulativeSum % k;

                if (remainder < 0)
                    remainder += k;

                if (remainderMap.ContainsKey(remainder))
                {
                    count += remainderMap[remainder];
                    remainderMap[remainder]++;
                }
                else
                {
                    remainderMap[remainder] = 1;
                }
            }

            return count;
        }
    }
}

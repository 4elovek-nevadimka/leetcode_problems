namespace Solutions.Arrays
{
    internal class Task_1248
    {
        // #Array #Hash Table #Math #Sliding Window

        public int NumberOfSubarrays(int[] nums, int k)
        {
            var frequencyDic = new Dictionary<int, int> { [0] = 1 };

            int prefixSum = 0, result = 0;
            foreach (var num in nums)
            {
                if (num % 2 == 1)
                    prefixSum++;

                if (frequencyDic.ContainsKey(prefixSum - k))
                    result += frequencyDic[prefixSum - k];

                if (frequencyDic.TryGetValue(prefixSum, out int value))
                    frequencyDic[prefixSum] = ++value;
                else
                    frequencyDic[prefixSum] = 1;
            }

            return result;
        }
    }
}

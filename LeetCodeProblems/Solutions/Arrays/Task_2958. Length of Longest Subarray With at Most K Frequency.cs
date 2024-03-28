namespace Solutions.Arrays
{
    internal class Task_2958
    {
        // #Array #Hash Table #Sliding Window

        public void Run()
        {
            Console.WriteLine(MaxSubarrayLength([1, 2, 3, 1, 2, 3, 1, 2], 2));
        }

        public int MaxSubarrayLength(int[] nums, int k)
        {
            int left = 0, maxLength = 0;
            var kHash = new HashSet<int>();
            var freqDic = new Dictionary<int, int>();

            for (var right = 0; right < nums.Length; right++)
            {
                var num = nums[right];
                if (freqDic.TryGetValue(num, out int value))
                    freqDic[num] = ++value;
                else
                    freqDic[num] = 1;

                if (freqDic[num] > k)
                    kHash.Add(num);

                while (kHash.Count > 0 && left <= right)
                {
                    num = nums[left];
                    freqDic[num]--;
                    if (freqDic[num] <= k)
                        kHash.Remove(num);
                    
                    left++;
                }
                maxLength = Math.Max(maxLength, right - left + 1);
            }

            return maxLength;
        }
    }
}

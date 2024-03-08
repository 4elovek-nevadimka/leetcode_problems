namespace Solutions.Arrays
{
    internal class Task_3005
    {
        // #Array #Hash Table #Counting

        public int MaxFrequencyElements(int[] nums)
        {
            return Solution1(nums);
        }

        private int Solution1(int[] nums)
        {
            var maxFreq = 0;
            var freq = new Dictionary<int, int>(100);
            foreach (var num in nums)
            {
                freq.TryGetValue(num, out int value);
                freq[num] = ++value;
                maxFreq = Math.Max(maxFreq, value);
            }

            return freq.Count(x => x.Value == maxFreq) * maxFreq;
        }
        private int Solution2(int[] nums)
        {
            var maxFreq = 0;
            var freq = new Dictionary<int, int>(100);
            foreach (var num in nums)
            {
                if (!freq.ContainsKey(num))
                    freq[num] = 1;
                else
                    freq[num]++;
                maxFreq = Math.Max(maxFreq, freq[num]);
            }

            var maxFreqCount = 0;
            foreach (var key in freq.Keys)
                if (freq[key] == maxFreq)
                    maxFreqCount++;

            return maxFreq * maxFreqCount;
        }
    }
}

namespace Solutions.Arrays
{
    internal class Task_0992
    {
        // #Array #Hash Table #Sliding Window #Counting

        public int SubarraysWithKDistinct(int[] nums, int k)
        {
            return Foo(nums, k) - Foo(nums, k - 1);
        }

        private int Foo(int[] nums, int k)
        {
            int left = 0, total = 0;
            var freqDic = new Dictionary<int, int>();

            for (var right = 0; right < nums.Length; right++)
            {
                var num = nums[right];
                if (freqDic.TryGetValue(num, out int value))
                    freqDic[num] = ++value;
                else
                    freqDic[num] = 1;

                while (freqDic.Count > k)
                {
                    num = nums[left];
                    freqDic[num]--;
                    if (freqDic[num] == 0)
                        freqDic.Remove(num);

                    left++;
                }
                total += right - left + 1;
            }

            return total;
        }
    }
}

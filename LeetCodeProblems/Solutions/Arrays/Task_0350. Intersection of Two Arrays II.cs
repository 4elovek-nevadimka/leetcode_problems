namespace Solutions.Arrays
{
    internal class Task_0350
    {
        // #Array #Hash Table #Two Pointers #Binary Search #Sorting

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var freqDic = new Dictionary<int, int>();
            foreach (var num in nums1)
                if (freqDic.TryGetValue(num, out int value))
                    freqDic[num] = ++value;
                else
                    freqDic[num] = 1;

            var result = new List<int>(freqDic.Count);
            foreach (var num in nums2)
                if (freqDic.TryGetValue(num, out int value) && value > 0)
                {
                    result.Add(num);
                    freqDic[num] = --value;
                }

            return [.. result];
        }
    }
}

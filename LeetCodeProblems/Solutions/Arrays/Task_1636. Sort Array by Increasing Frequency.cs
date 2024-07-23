namespace Solutions.Arrays
{
    internal class Task_1636
    {
        // #Array #Hash Table #Sorting

        public void Run()
        {
            var arr = FrequencySort([1, 1, 2, 2, 2, 3]);
            Array.ForEach(arr, Console.Write);
        }

        public int[] FrequencySort(int[] nums)
        {
            var freqDic = new Dictionary<int, int>();
            foreach (var num in nums)
                if (freqDic.TryGetValue(num, out int val))
                    freqDic[num] = ++val;
                else
                    freqDic[num] = 1;

            var freqArr = new Dictionary<int, List<int>>();
            foreach (var key in freqDic.Keys)
                if (freqArr.TryGetValue(freqDic[key], out var val))
                    val.Add(key);
                else {
                    val = [key];
                    freqArr[freqDic[key]] = val;
                }

            var result = new List<int>();
            for (var i = 1; i <= 100; i++)
                if (freqArr.TryGetValue(i, out var list))
                {
                    list.Sort((a, b) => b.CompareTo(a));
                    foreach (var num in list)
                        result.AddRange(Enumerable.Repeat(num, i));
                }

            return [.. result];
        }
    }
}

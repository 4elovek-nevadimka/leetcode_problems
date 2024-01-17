namespace Solutions.Arrays
{
    internal class Task_1207
    {
        public bool UniqueOccurrences(int[] arr)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;
            }

            var hash = new HashSet<int>();
            foreach (var num in dic.Keys)
            {
                if (!hash.Add(dic[num]))
                    return false;
            }

            return true;
        }
    }
}

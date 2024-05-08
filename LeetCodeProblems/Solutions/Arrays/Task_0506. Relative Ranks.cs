namespace Solutions.Arrays
{
    internal class Task_0506
    {
        // #Array #Sorting #Heap(Priority Queue)

        public string[] FindRelativeRanks(int[] score)
        {
            var n = score.Length;
            var sortedArr = new int[n];
            score.CopyTo(sortedArr, 0);

            Array.Sort(sortedArr, (a, b) => b.CompareTo(a));
            var dic = new Dictionary<int, int>();
            for (var i = 0; i < n; i++)
                dic[sortedArr[i]] = i;

            var result = new List<string>(n);
            foreach (var rank in score)
            {
                switch (dic[rank])
                {
                    case 0:
                        result.Add("Gold Medal");
                        break;
                    case 1:
                        result.Add("Silver Medal");
                        break;
                    case 2:
                        result.Add("Bronze Medal");
                        break;
                    default:
                        result.Add((dic[rank] + 1).ToString());
                        break;
                }
            }

            return [.. result];
        }
    }
}

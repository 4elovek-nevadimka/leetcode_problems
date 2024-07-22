namespace Solutions.Arrays
{
    internal class Task_2418
    {
        // #Array #Hash Table #String #Sorting

        public string[] SortPeople(string[] names, int[] heights)
        {
            var dic = new Dictionary<int, string>();
            for (var i = 0; i < names.Length; i++)
                dic.Add(heights[i], names[i]);

            Array.Sort(heights, (a, b) => a.CompareTo(b));
            for (var i = 0; i < names.Length; i++)
                names[i] = dic[heights[i]];

            return names;
        }
    }
}

namespace Solutions.Arrays
{
    internal class Task_0049
    {
        // #Array #Hash Table #String #Sorting

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dic = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var characters = str.ToArray();
                Array.Sort(characters);
                var sortedStr = new string(characters);

                if (!dic.ContainsKey(sortedStr))
                    dic.Add(sortedStr, new List<string>());
                dic[sortedStr].Add(str);
            }

            var result = new List<IList<string>>();
            foreach (var key in dic.Keys)
                result.Add(dic[key]);

            return result;
        }
    }
}

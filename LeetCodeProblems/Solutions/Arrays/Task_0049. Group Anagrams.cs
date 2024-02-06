namespace Solutions.Arrays
{
    internal class Task_0049
    {
        // #Array #Hash Table #String #Sorting

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            return Solution1(strs);
        }

        // ok solution
        private IList<IList<string>> Solution1(string[] strs)
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

        // super slow solution
        private IList<IList<string>> Solution2(string[] strs)
        {
            var dic = new Dictionary<int[], IList<string>>();
            foreach (var str in strs)
            {
                var alphabet = new int[26];
                for (var i = 0; i < str.Length; i++)
                    alphabet[str[i] - 'a']++;

                var exists = false;
                foreach (var a in dic.Keys)
                {
                    if (a.SequenceEqual(alphabet))
                    {
                        dic[a].Add(str);
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    dic.Add(alphabet, new List<string>());
                    dic[alphabet].Add(str);
                }
            }

            var result = new List<IList<string>>();
            foreach (var key in dic.Keys)
                result.Add(dic[key]);

            return result;
        }
    }
}

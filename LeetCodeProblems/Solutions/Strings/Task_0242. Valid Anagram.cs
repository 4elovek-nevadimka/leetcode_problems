namespace Solutions.Strings
{
    internal class Task_0242
    {
        // #Hash Table #String #Sorting

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            var dic = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!dic.ContainsKey(c))
                {
                    dic.Add(c, 0);
                }
                dic[c]++;
            }
            foreach (var c in t)
            {
                if (dic.ContainsKey(c))
                {
                    if (dic[c] == 1)
                    {
                        dic.Remove(c);
                    }
                    else
                    {
                        dic[c]--;
                    }
                }
                else
                {
                    return false;
                }
            }

            return dic.Count == 0;
        }
    }
}

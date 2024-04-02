namespace Solutions.Strings
{
    internal class Task_0205
    {
        // #Hash Table #String

        public bool IsIsomorphic(string s, string t)
        {
            return Solution1(s, t);
        }

        private bool Solution1(string s, string t)
        {
            var sDic = new Dictionary<char, int>();
            var tDic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                var sContains = sDic.TryGetValue(s[i], out int sValue);
                var tContains = tDic.TryGetValue(t[i], out int tValue);
                if (sContains && tContains)
                {
                    if (sValue == tValue)
                        sDic[s[i]] = tDic[t[i]] = i;
                    else
                        return false;
                }
                else if (!sContains && !tContains)
                {
                    sDic[s[i]] = tDic[t[i]] = i;
                }
                else
                    return false;
            }

            return true;
        }

        private bool Solution2(string s, string t)
        {
            var sDic = new Dictionary<char, int>();
            var tDic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (sDic.GetValueOrDefault(s[i]) != tDic.GetValueOrDefault(t[i]))
                    return false;
                sDic[s[i]] = tDic[t[i]] = i + 1;
            }

            return true;
        }
    }
}

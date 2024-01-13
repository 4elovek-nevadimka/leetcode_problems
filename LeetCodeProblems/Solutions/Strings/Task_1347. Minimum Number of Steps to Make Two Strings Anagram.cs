namespace Solutions.Strings
{
    internal class Task_1347
    {
        public int MinSteps(string s, string t)
        {
            return Solution1(s, t);
        }

        private int Solution1(string s, string t)
        {
            var sArr = new int[26];
            var tArr = new int[26];

            for (var i = 0; i < s.Length; i++)
            {
                sArr[s[i] - 'a']++;
                tArr[t[i] - 'a']++;
            }

            var minStepsCounter = 0;
            for (var i = 0; i < 26; i++)
            {
                if (tArr[i] > sArr[i])
                    minStepsCounter += tArr[i] - sArr[i];
            }

            return minStepsCounter;
        }

        private int Solution2(string s, string t)
        {
            var dicS = GetMapOfString(s);
            var dicT = GetMapOfString(t);

            var minStepsCounter = 0;
            foreach (var c in dicS.Keys)
            {
                if (dicT.ContainsKey(c))
                {
                    var diff = dicS[c] - dicT[c];
                    if (diff > 0)
                        minStepsCounter += diff;
                }
                else
                {
                    minStepsCounter += dicS[c];
                }
            }
            return minStepsCounter;
        }

        private Dictionary<char, int> GetMapOfString(string str)
        {
            var dic = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (!dic.ContainsKey(c))
                    dic.Add(c, 1);
                else
                    dic[c]++;
            }
            return dic;
        }
    }
}

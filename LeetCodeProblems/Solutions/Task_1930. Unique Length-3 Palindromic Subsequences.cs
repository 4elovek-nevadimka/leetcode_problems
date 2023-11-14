namespace Solutions
{
    internal class Task_1930
    {
        public void Run()
        {
            // var s = "aabca";
            var s = "bbcbaba";

            Console.WriteLine(CountPalindromicSubsequence(s));
        }

        public int CountPalindromicSubsequence(string s)
        {
            var dic = new Dictionary<char, List<int>>();
            var palindromicCounter = 0;

            for (var i = 0; i < s.Length; i++)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], new List<int>());
                dic[s[i]].Add(i);
            }

            foreach (var c in dic.Keys)
            {
                // skip
                if (dic[c].Count == 1) continue;
                // add xxx palindrom
                if (dic[c].Count > 2) palindromicCounter++;
                // check others
                int minIndex = dic[c][0], maxIndex = dic[c][^1];
                foreach (var other in dic.Keys)
                {
                    if (c == other) continue;

                    foreach (var index in dic[other])
                    {
                        if (index > minIndex && index < maxIndex)
                        {
                            palindromicCounter++;
                            break;
                        }
                    }
                }
            }

            return palindromicCounter;
        }
    }
}

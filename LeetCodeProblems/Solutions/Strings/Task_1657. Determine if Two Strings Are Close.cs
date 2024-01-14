namespace Solutions.Strings
{
    internal class Task_1657
    {
        // #Hash Table #String #Sorting #Counting

        public bool CloseStrings(string word1, string word2)
        {
            return Solution2(word1, word2);
        }

        private bool Solution1(string word1, string word2)
        {
            // chars frequency
            var dic1 = GetCharFrequency(word1);
            var dic2 = GetCharFrequency(word2);

            // groups of chars frequency
            var dic3 = new Dictionary<int, int>();
            var dic4 = new Dictionary<int, int>();

            foreach (var key in dic1.Keys)
            {
                if (dic2.ContainsKey(key))
                {
                    if (!dic3.ContainsKey(dic1[key]))
                        dic3.Add(dic1[key], 1);
                    else
                        dic3[dic1[key]]++;
                    if (!dic4.ContainsKey(dic2[key]))
                        dic4.Add(dic2[key], 1);
                    else
                        dic4[dic2[key]]++;
                }
                else
                    return false;
            }

            foreach (var key in dic3.Keys)
            {
                if (dic4.ContainsKey(key))
                {
                    if (dic4[key] != dic3[key])
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        private Dictionary<char, int> GetCharFrequency(string word)
        {
            var dic = new Dictionary<char, int>();
            foreach (var c in word)
            {
                if (!dic.ContainsKey(c))
                    dic.Add(c, 1);
                else
                    dic[c]++;
            }
            return dic;
        }

        private bool Solution2(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            var cArr1 = new int[26];
            var cArr2 = new int[26];
            for (var i = 0; i < word1.Length; i++)
            {
                cArr1[word1[i] - 'a']++;
                cArr2[word2[i] - 'a']++;
            }

            for (var i = 0; i < 26; i++)
            {
                if ((cArr1[i] == 0) != (cArr2[i] == 0)) 
                    return false;
            }

            Array.Sort(cArr1);
            Array.Sort(cArr2);

            return cArr1.SequenceEqual(cArr2);
        }
    }
}

namespace Solutions.Strings
{
    internal class Task_1897
    {
        public bool MakeEqual(string[] words)
        {
            return Solution2(words);
        }

        private bool Solution1(string[] words)
        {
            var dic = new Dictionary<char, int>();
            var n = words.Length;

            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    if (!dic.ContainsKey(c))
                    {
                        dic.Add(c, 1);
                    }
                    else
                    {
                        dic[c]++;
                    }
                }
            }

            foreach (var c in dic.Keys)
            {
                if (dic[c] % n != 0)
                {
                    return false;
                }
            }

            return true;
        }

        private bool Solution2(string[] words)
        {
            var n = words.Length;
            if (n == 1)
                return true;

            var totalChars = 0;
            var alphabet = new int[26];
            foreach (var word in words)
            {
                foreach (var c in word)
                {
                    alphabet[c - 'a']++;
                    totalChars++;
                }
            }
            if (totalChars % n != 0)
                return false;
            
            foreach (var a in alphabet)
            {
                if (a % n != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

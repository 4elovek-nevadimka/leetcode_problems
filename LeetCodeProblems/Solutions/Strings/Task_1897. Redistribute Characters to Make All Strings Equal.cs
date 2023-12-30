namespace Solutions.Strings
{
    internal class Task_1897
    {
        public bool MakeEqual(string[] words)
        {
            var dic = new Dictionary<char,  int>();
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
    }
}

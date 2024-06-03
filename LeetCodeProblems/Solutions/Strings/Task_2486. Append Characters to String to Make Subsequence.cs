namespace Solutions.Strings
{
    internal class Task_2486
    {
        // #Two Pointers #String #Greedy

        public int AppendCharacters(string s, string t)
        {
            int left = 0, right = 0;
            while (!(left == s.Length || right == t.Length))
            {
                if (s[left] == t[right])
                    right++;
                left++;
            }

            return t.Length - right;
        }
    }
}

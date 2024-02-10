namespace Solutions.Strings
{
    internal class Task_0647
    {
        // #String #Dynamic Programming

        public int CountSubstrings(string s)
        {
            int count = 0, n = s.Length;

            void ExpandAroundCenter(int left, int right)
            {
                while (left >= 0 && right < n && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                ExpandAroundCenter(i, i);
                ExpandAroundCenter(i, i + 1);
            }

            return count;
        }
    }
}

namespace Solutions.Strings
{
    internal class Task_1704
    {
        public bool HalvesAreAlike(string s)
        {
            s = s.ToLower();
            var n = s.Length;
            int left = 0, right = 0;
            for (var i = 0; i < n / 2; i++)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                    left++;
            }

            for (var i = n - 1; i >= n / 2; i--)
            {
                if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u')
                    right++;
            }

            return left == right;
        }
    }
}

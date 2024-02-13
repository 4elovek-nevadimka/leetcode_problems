using System.Text;

namespace Solutions.Strings
{
    internal class Task_0125
    {
        // #Two Pointers #String

        public bool IsPalindrome(string s)
        {
            return Solution2(s);
        }

        private bool Solution1(string s)
        {
            var lettersOrDigits = new StringBuilder();
            foreach (var c in s)
                if (char.IsLetterOrDigit(c))
                    lettersOrDigits.Append(c);

            var formattedString = lettersOrDigits.ToString().ToLower();

            int l = 0, r = formattedString.Length - 1;
            while (l < r)
            {
                if (formattedString[l++] != formattedString[r--])
                {
                    return false;
                }
            }

            return true;
        }

        private bool Solution2(string s)
        {
            int l = 0, r = s.Length - 1;
            while (l < r)
            {
                if (!char.IsLetterOrDigit(s[l]))
                {
                    l++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[r]))
                {
                    r--;
                    continue;
                }

                if (char.ToLower(s[l++]) != char.ToLower(s[r--]))
                    return false;
            }

            return true;
        }
    }
}

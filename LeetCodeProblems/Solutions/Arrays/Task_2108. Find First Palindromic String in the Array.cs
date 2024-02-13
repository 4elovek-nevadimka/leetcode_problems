namespace Solutions.Arrays
{
    internal class Task_2108
    {
        // #Array #Two Pointers #String

        public string FirstPalindrome(string[] words)
        {
            foreach (var word in words)
            {
                int l = 0, r = word.Length - 1;
                bool notEqual = false;
                while (l < r)
                {
                    if (word[l++] != word[r--])
                    {
                        notEqual = true;
                        break;
                    }
                }
                if (!notEqual)
                    return word;
            }

            return "";
        }
    }
}

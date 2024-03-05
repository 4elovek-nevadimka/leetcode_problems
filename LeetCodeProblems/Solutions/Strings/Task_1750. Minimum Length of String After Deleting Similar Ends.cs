namespace Solutions.Strings
{
    internal class Task_1750
    {
        // #Two Pointers #String

        public void Run()
        {
            Console.WriteLine(MinimumLength("cabaabac"));
        }

        public int MinimumLength(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] == s[right])
                {
                    var c = s[left];
                    while (s[++left] == c)
                        if (left == right)
                            return 0;

                    while (s[--right] == c)
                        if (left == right)
                            return 0;
                }
                else
                    return right - left;
            }
            return 1;
        }
    }
}

namespace Solutions.Strings
{
    internal class Task_1758
    {
        // #String

        public int MinOperations(string s)
        {
            return Solution2(s);
        }

        private int Solution1(string s)
        {
            return Math.Min(FlipCycle(s, '0'), FlipCycle(s, '1'));
        }

        private int FlipCycle(string s, char startWith)
        {
            var flipsCount = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (s[i] != startWith)
                        flipsCount++;
                }
                else
                {
                    if (s[i] == startWith)
                        flipsCount++;
                }
            }
            return flipsCount;
        }

        private int Solution2(string s)
        {
            var flipsCount = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (i % 2 != s[i] - '0') flipsCount++;
            }
            return Math.Min(flipsCount, s.Length - flipsCount);
        }
    }
}

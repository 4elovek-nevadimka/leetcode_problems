namespace Solutions.Arrays
{
    internal class Task_0455
    {
        // #Array #Two Pointers #Greedy #Sorting

        public int FindContentChildren(int[] g, int[] s)
        {
            return Solution1(g, s);
        }

        private int Solution1(int[] g, int[] s)
        {
            if (s.Length == 0)
                return 0;

            Array.Sort(g);
            Array.Sort(s);

            var contentChildren = 0;
            var gCounter = 0;
            var sCounter = 0;
            while (gCounter < g.Length)
            {
                if (g[gCounter] <= s[sCounter])
                {
                    contentChildren++;
                    gCounter++;
                    sCounter++;
                }
                else
                {
                    sCounter++;
                }
                if (sCounter == s.Length)
                    break;
            }
            
            return contentChildren;
        }

        private int Solution2(int[] g, int[] s)
        {
            if (s.Length == 0)
                return 0;

            var maxCookieSize = 0;
            var cookies = new Dictionary<int, int>();
            foreach (var c in s)
            {
                if (!cookies.ContainsKey(c))
                    cookies.Add(c, 1);
                else
                    cookies[c]++;
                maxCookieSize = Math.Max(maxCookieSize, c);
            }

            var contentChildren = 0;
            foreach (var greed in g)
            {
                if (cookies.ContainsKey(greed))
                {
                    contentChildren++;
                    cookies[greed]--;
                    if (cookies[greed] == 0)
                        cookies.Remove(greed);
                }
                else
                {

                }
            }

            return contentChildren;
        }
    }
}

namespace Solutions.Arrays
{
    internal class Task_0997
    {
        // #Array #Hash Table #Graph

        public int FindJudge(int n, int[][] trust)
        {
            if (trust.Length == 0)
                return n == 1 ? 1 : -1;

            var people = new bool[n + 1];
            var candidates = new int[n + 1];
            foreach (var pair in trust)
            {
                people[pair[0]] = true;
                candidates[pair[1]]++;
            }

            for (var i = 1; i <= n; i++)
            {
                if (!people[i])
                {
                    if (candidates[i] == n - 1)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
}

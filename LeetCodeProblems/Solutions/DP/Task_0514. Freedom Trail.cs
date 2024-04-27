namespace Solutions.DP
{
    internal class Task_0514
    {
        // #String #Dynamic Programming #Depth-First Search #Breadth-First Search

        public int FindRotateSteps(string ring, string key)
        {
            int n = ring.Length, m = key.Length;

            var indexMap = new Dictionary<char, List<int>>();
            for (var i = 0; i < n; i++)
            {
                if (!indexMap.ContainsKey(ring[i]))
                    indexMap[ring[i]] = [];

                indexMap[ring[i]].Add(i);
            }

            var dp = new int[m + 1, n];
            for (var i = m - 1; i >= 0; i--)
            {
                for (var j = 0; j < n; j++)
                {
                    dp[i, j] = Int32.MaxValue;

                    foreach (var pos in indexMap[key[i]])
                    {
                        var distance = Math.Min(Math.Abs(j - pos), n - Math.Abs(j - pos));
                        var steps = distance + dp[i + 1, pos];
                        dp[i, j] = Math.Min(dp[i, j], steps);
                    }
                }
            }

            return dp[0, 0] + m;
        }
    }
}

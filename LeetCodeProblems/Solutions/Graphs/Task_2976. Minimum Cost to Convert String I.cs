namespace Solutions.Graphs
{
    internal class Task_2976
    {
        // #Array #String #Graph #Shortest Path
        
        public void Run()
        {
            // MinimumCost("abcd", "acbe", ['a', 'b', 'c', 'c', 'e', 'd'], ['b', 'c', 'b', 'e', 'b', 'e'], [2, 5, 5, 1, 2, 20]);
            MinimumCost("abc", "def", ['a', 'a', 'b', 'b'], ['d', 'e', 'f', 'f'], [5, 10, 15, 20]);
        }

        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            var n = 26;
            var dist = new long[n, n];

            // Initialize distance matrix with infinity
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                    if (i == j)
                        dist[i, j] = 0;
                    else
                        dist[i, j] = Int32.MaxValue;
            }

            // Fill the distance matrix with direct edges
            var m = cost.Length;
            for (var i = 0; i < m; i++)
                dist[original[i] - 'a', changed[i] - 'a'] = 
                    Math.Min(dist[original[i] - 'a', changed[i] - 'a'], cost[i]);

            // Apply Floyd-Warshall Algorithm
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                        if (dist[i, j] > dist[i, k] + dist[k, j])
                            dist[i, j] = dist[i, k] + dist[k, j];
                }
            }

            long result = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i])
                {
                    if (dist[source[i] - 'a', target[i] - 'a'] == Int32.MaxValue)
                        return -1;
                    else
                        result += dist[source[i] - 'a', target[i] - 'a'];
                }
            }

            //Console.WriteLine(dist['b' - 'a', 'c' - 'a']);
            //Console.WriteLine(dist['c' - 'a', 'b' - 'a']);
            //Console.WriteLine(dist['d' - 'a', 'e' - 'a']);

            Console.WriteLine(result);
            return result == int.MaxValue ? -1 : result;
        }
    }
}

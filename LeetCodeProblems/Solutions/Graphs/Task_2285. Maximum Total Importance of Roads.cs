namespace Solutions.Graphs
{
    internal class Task_2285
    {
        // #Greedy #Graph #Sorting #Heap(Priority Queue)

        public void Run()
        {
            Console.WriteLine(
                MaximumImportance(5, [[0, 1], [1, 2], [2, 3], [0, 2], [1, 3], [2, 4]]));
        }

        public long MaximumImportance(int n, int[][] roads)
        {
            return Solution2(n, roads);
        }

        public long Solution1(int n, int[][] roads)
        {
            var freqDic = new Dictionary<int, int>();
            foreach (var road in roads)
            {
                if (!freqDic.ContainsKey(road[0]))
                    freqDic[road[0]] = 1;
                else
                    freqDic[road[0]]++;

                if (!freqDic.ContainsKey(road[1]))
                    freqDic[road[1]] = 1;
                else
                    freqDic[road[1]]++;
            }

            var queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            foreach (var node in freqDic.Keys)
                queue.Enqueue(node, freqDic[node]);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                freqDic[node] = n--;
                Console.WriteLine($"{node} -> {freqDic[node]}");
            }

            long maxImportance = 0;
            foreach (var road in roads)
                maxImportance += (long)freqDic[road[0]] + freqDic[road[1]];

            return maxImportance;
        }

        private long Solution2(int n, int[][] roads)
        {
            int[] freqs = new int[n + 1], nodes = new int[n + 1];

            foreach (var road in roads)
            {
                nodes[road[0]]++;
                nodes[road[1]]++;
            }

            foreach (var node in nodes)
                freqs[node]++;

            for (int i = freqs.Length - 1; i >= 0; i--)
            {
                if (freqs[i] > 0)
                {
                    var temp = freqs[i];
                    freqs[i] = n;
                    n -= temp;
                }
            }

            for (int i = 0; i < freqs.Length; i++)
            {
                var temp = nodes[i];
                nodes[i] = freqs[temp]--;
            }

            long maxImportance = 0;
            for (int i = 0; i < roads.Length; i++)
                maxImportance += nodes[roads[i][0]] + nodes[roads[i][1]];

            return maxImportance;
        }
    }
}

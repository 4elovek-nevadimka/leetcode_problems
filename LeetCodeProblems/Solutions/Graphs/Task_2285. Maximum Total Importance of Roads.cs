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
    }
}

namespace Solutions.Matrix
{
    internal class Task_2392
    {
        // #Array #Graph #Topological Sort #Matrix

        public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions)
        {
            var rowOrder = TopologicalSort(k, rowConditions);
            var colOrder = TopologicalSort(k, colConditions);

            if (rowOrder == null || colOrder == null)
                return [];

            var position = new int[k + 1, 2];
            for (int i = 0; i < k; i++)
            {
                position[rowOrder[i], 0] = i;
                position[colOrder[i], 1] = i;
            }

            var result = new int[k][];
            for (int i = 0; i < k; i++)
                result[i] = new int[k];

            for (int i = 1; i <= k; i++)
                result[position[i, 0]][position[i, 1]] = i;

            return result;
        }

        private int[] TopologicalSort(int k, int[][] conditions)
        {
            var graph = new List<int>[k + 1];
            for (int i = 0; i <= k; i++)
                graph[i] = [];

            var inDegree = new int[k + 1];
            foreach (var condition in conditions)
            {
                int u = condition[0], v = condition[1];
                graph[u].Add(v);
                inDegree[v]++;
            }

            var queue = new Queue<int>();
            for (int i = 1; i <= k; i++)
                if (inDegree[i] == 0)
                    queue.Enqueue(i);

            var result = new List<int>();
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                result.Add(node);

                foreach (var neighbor in graph[node])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            if (result.Count == k)
                return [.. result];

            return null;
        }
    }
}

namespace Solutions.Graphs
{
    internal class Task_1971
    {
        // #Depth-First Search #Breadth-First Search #Union Find #Graph

        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            var graph = new List<int>[n];
            for (var i = 0; i < n; i++)
                graph[i] = [];

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var queue = new Queue<int>();
            var visited = new bool[n];
            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node == destination)
                    return true;

                foreach (var v in graph[node])
                {
                    if (!visited[v])
                    {
                        queue.Enqueue(v);
                        visited[v] = true;
                    }
                }
            }

            return false;
        }
    }
}

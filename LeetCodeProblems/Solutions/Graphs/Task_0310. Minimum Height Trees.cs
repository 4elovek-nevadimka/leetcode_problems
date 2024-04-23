namespace Solutions.Graphs
{
    internal class Task_0310
    {
        // #Depth-First Search #Breadth-First Search #Graph #Topological Sort

        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            if (n == 1) return [0];

            var graph = new Dictionary<int, List<int>>(n);
            for (var i = 0; i < n; i++)
                graph[i] = [];

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var leaves = new List<int>();
            foreach (var node in graph.Keys)
            {
                if (graph[node].Count == 1)
                    leaves.Add(node);
            }

            while (n > 2)
            {
                n -= leaves.Count;
                var tmpLeaves = new List<int>();

                foreach (var leaf in leaves)
                {
                    var node = graph[leaf][0];
                    graph[node].Remove(leaf);
                    if (graph[node].Count == 1)
                        tmpLeaves.Add(node);
                }

                leaves = tmpLeaves;
            }

            return leaves;
        }
    }
}

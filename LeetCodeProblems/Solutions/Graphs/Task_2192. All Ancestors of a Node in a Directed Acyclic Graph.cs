namespace Solutions.Graphs
{
    internal class Task_2192
    {
        // #Depth-First Search #Breadth-First Search #Graph #Topological Sort

        public void Run()
        {
            // GetAncestors(8, [[0, 3], [0, 4], [1, 3], [2, 4], [2, 7], [3, 5], [3, 6], [3, 7], [4, 6]]);
            GetAncestors(9, [[7, 5], [2, 5], [0, 7], [0, 1], [6, 1], [2, 4], [3, 5]]);
        }

        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            var ancestorsArr = new HashSet<int>[n];
            for (var i = 0; i < n; i++)
                ancestorsArr[i] = [];

            foreach (var edge in edges)
            {
                if (ancestorsArr[edge[1]] == null)
                    ancestorsArr[edge[1]] = [edge[0]];
                else
                    ancestorsArr[edge[1]].Add(edge[0]);
            }

            for (var i = 0; i < n; i++)
            {
                var queue = new Queue<int>();
                var visited = new HashSet<int>();
                foreach (var ancestor in ancestorsArr[i])
                    queue.Enqueue(ancestor);

                while (queue.Count > 0)
                {
                    var tmpCount = queue.Count;
                    while (tmpCount > 0)
                    {
                        var node = queue.Dequeue();
                        if (!visited.Contains(node))
                        {
                            visited.Add(node);
                            foreach (var ancestor in ancestorsArr[node])
                                queue.Enqueue(ancestor);
                            ancestorsArr[i].Add(node);
                        }
                        tmpCount--;
                    }
                }
            }

            var result = new List<IList<int>>();
            for (var i = 0; i < n; i++)
                result.Add([.. ancestorsArr[i].OrderBy(x => x)]);

            return result;
        }
    }
}

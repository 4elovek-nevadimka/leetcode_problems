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
            return Solution2(n, edges);
        }

        public IList<IList<int>> Solution1(int n, int[][] edges)
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

        public IList<IList<int>> Solution2(int n, int[][] edges)
        {
            var adjacencyList = new List<int>[n];
            for (var i = 0; i < n; i++)
                adjacencyList[i] = [];

            var indegree = new int[n];
            foreach (var edge in edges)
            {
                adjacencyList[edge[0]].Add(edge[1]);
                indegree[edge[1]]++;
            }

            var nodesWithZeroIndegree = new Queue<int>();
            for (var i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0)
                    nodesWithZeroIndegree.Enqueue(i);
            }

            var topologicalOrder = new List<int>();
            while (nodesWithZeroIndegree.Count > 0)
            {
                int currentNode = nodesWithZeroIndegree.Dequeue();
                topologicalOrder.Add(currentNode);

                foreach (int neighbor in adjacencyList[currentNode])
                {
                    indegree[neighbor]--;
                    if (indegree[neighbor] == 0)
                    {
                        nodesWithZeroIndegree.Enqueue(neighbor);
                    }
                }
            }

            var ancestorsList = new List<IList<int>>();
            var ancestorsSetList = new List<HashSet<int>>();
            for (var i = 0; i < n; i++)
            {
                ancestorsList.Add([]);
                ancestorsSetList.Add([]);
            }

            foreach (var node in topologicalOrder)
            {
                foreach (var neighbor in adjacencyList[node])
                {
                    ancestorsSetList[neighbor].Add(node);
                    ancestorsSetList[neighbor].UnionWith(ancestorsSetList[node]);
                }
            }

            for (int i = 0; i < ancestorsList.Count; i++)
            {
                ((List<int>)ancestorsList[i]).AddRange(ancestorsSetList[i]);
                ((List<int>)ancestorsList[i]).Sort();
            }

            return ancestorsList;
        }
    }
}

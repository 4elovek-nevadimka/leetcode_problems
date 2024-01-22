namespace Solutions.Graphs
{
    internal class Common_Graphs_Simulation
    {
        public void Run()
        {
            Common_Graphs graph = new( new int[][] {
                new[] { 0, 1, 6 }, new[] { 0, 2, 2 }, 
                new[] { 2, 1, 3 }, 
                new[] { 1, 3, 1 }, new[] { 2, 3, 5 }
            });
            Console.WriteLine(graph.ShortestPath(0, 3));
        }
    }

    internal class Common_Graphs
    {
        private readonly Dictionary<int, Dictionary<int, int>> _graph = new();

        public Common_Graphs(int[][] edges)
        {
            foreach (var edge in edges)
            {
                if (!_graph.ContainsKey(edge[0]))
                {
                    _graph.Add(edge[0], new Dictionary<int, int>());
                }
                if (!_graph.ContainsKey(edge[1]))
                {
                    _graph.Add(edge[1], new Dictionary<int, int>());
                }
                _graph[edge[0]].Add(edge[1], edge[2]);
            }
        }

        public int ShortestPath(int node1, int node2)
        {
            if (node1 == node2) return 0;

            var costs = InitCosts(node1);
            var parents = InitParents(node1);

            var visited = new HashSet<int>();

            var lowestCostNode = FindLowestCostNode(costs, visited);
            while (lowestCostNode != -1)
            {
                var cost = costs[lowestCostNode];
                if (_graph.ContainsKey(lowestCostNode))
                {
                    var neighbors = _graph[lowestCostNode];
                    foreach (var n in neighbors.Keys)
                    {
                        var newCost = cost + neighbors[n];
                        if (costs[n] > newCost)
                        {
                            costs[n] = newCost;
                            parents[n] = lowestCostNode;
                        }
                    }
                }
                visited.Add(lowestCostNode);
                lowestCostNode = FindLowestCostNode(costs, visited);
            }
            Console.WriteLine(parents);
            return costs[node2] == int.MaxValue ? -1 : costs[node2];
        }

        private int FindLowestCostNode(Dictionary<int, int> costs, ICollection<int> visited)
        {
            int lowestCost = int.MaxValue, lowestCostNode = -1;
            foreach (var node in costs)
            {
                var cost = node.Value;
                if (cost < lowestCost && !visited.Contains(node.Key))
                {
                    lowestCost = cost;
                    lowestCostNode = node.Key;
                }
            }
            return lowestCostNode;
        }

        private Dictionary<int, int> InitCosts(int node1)
        {
            var costs = new Dictionary<int, int>();
            foreach (var node in _graph.Keys)
            {
                if (node != node1)
                {
                    if (_graph[node1].ContainsKey(node))
                    {
                        // from start node to another
                        costs[node] = _graph[node1][node];
                    }
                    else
                    {
                        // other nodes, can't reach
                        costs[node] = int.MaxValue;
                    }
                }
                else
                {
                    costs[node] = 0;
                }
            }
            return costs;
        }

        private Dictionary<int, int> InitParents(int node1)
        {
            var parents = new Dictionary<int, int>();
            foreach (var node in _graph.Keys)
            {
                if (node != node1)
                {
                    if (_graph[node1].ContainsKey(node))
                    {
                        parents[node] = node1;
                    }
                    else
                    {
                        parents[node] = int.MaxValue;
                    }
                }
            }
            return parents;
        }
    }
}

namespace Solutions.Graphs
{
    public class Graph
    {
        private readonly ICollection<int> _shortestPath = new List<int>();

        private readonly Dictionary<int, Dictionary<int, int>> _graph = new();

        public ICollection<int> ShortestPath => _shortestPath;

        public Graph(int n, int[][] edges)
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

        public void AddEdge(int[] edge)
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

        public int GetShortestPath(int node1, int node2)
        {
            if (node1 == node2) return 0;

            if (!_graph.ContainsKey(node1)
                || !_graph.ContainsKey(node2)) return -1;

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
            CombinePath(parents, node1, node2);
            return costs[node2] == int.MaxValue ? -1 : costs[node2];
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

        private void CombinePath(Dictionary<int, int> parents, int node1, int node2)
        {
            _shortestPath.Clear();
            var child = node2;
            _shortestPath.Add(child);
            while (child != node1)
            {
                var parent = parents[child];
                if (parent == int.MaxValue)
                {
                    // no answer
                    _shortestPath.Clear();
                    break;
                }
                _shortestPath.Add(parent);
                child = parent;
            }
        }
    }
}

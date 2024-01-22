namespace Solutions
{
    internal class Task_2642
    {
        // #Graph #Design #Heap(Priority Queue) #Shortest Path

        public void Run()
        {
            // Input
            // ["Graph", "shortestPath", "shortestPath", "addEdge", "shortestPath"]
            // [[4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]], [3, 2], [0, 3], [[1, 3, 4]], [0, 3]]

            // Output
            // [null, 6, -1, null, 6]

            Graph graph = new(4, new int[][] {
                new[] { 0, 2, 5 }, new[] { 0, 1, 2 }, new[] { 1, 2, 1 }, new[] { 3, 0, 3 } });
            Console.WriteLine("Graph");
            Console.WriteLine($"shortestPath [3, 2]: {graph.ShortestPath(3, 2)}");
            Console.WriteLine($"shortestPath [0, 3]: {graph.ShortestPath(0, 3)}");
            graph.AddEdge(new[] { 1, 3, 4 });
            Console.WriteLine("addEdge");
            Console.WriteLine($"shortestPath [0, 3]: {graph.ShortestPath(0, 3)}");
        }
    }

    public class Graph
    {
        private Dictionary<int, Dictionary<int, int>> _graph = new();

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

        public int ShortestPath(int node1, int node2)
        {

            if (node1 == node2) return 0;

            if (!_graph.ContainsKey(node1)
                || !_graph.ContainsKey(node2)) return -1;

            var costs = new Dictionary<int, int>();
            foreach (var node in _graph.Keys)
            {
                if (node != node1)
                {
                    if (_graph[node1].ContainsKey(node))
                    {
                        costs[node] = _graph[node1][node];
                    }
                    else
                    {
                        costs[node] = int.MaxValue;
                    }
                }
                else
                {
                    costs[node] = 0;
                }
            }

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

            var visited = new List<int>();

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
            return costs[node2] == int.MaxValue ? -1 : costs[node2];
        }

        private int FindLowestCostNode(Dictionary<int, int> costs, List<int> visited)
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
    }
}

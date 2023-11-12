namespace Solutions
{
    internal class Task_0815
    {
        public void Run()
        {
            var routes = new[] { new[] { 1, 2, 7 }, new[] { 3, 6, 7 } };
            // var routes = new[] { new[] { 1, 2, 3 }, new[] { 3, 4, 5 }, new[] { 5, 6, 7 } };
            int source = 1, target = 6;

            Console.WriteLine(NumBusesToDestination(routes, source, target));
        }

        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            var graph = new GraphA();
            foreach (var route in routes)
            {
                for (int i = 0; i < route.Length - 1; i++)
                {
                    graph.AddEdge(route[i], route[i + 1]);
                }
                // from last stop to first
                graph.AddEdge(route[^1], route[0]);
            }

            var visited = graph.Search(source, target);

            return 0;
        }
    }

    internal class GraphA
    {
        private readonly Dictionary<int, List<int>> _graph;

        public GraphA()
        {
            _graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int from, int to)
        {
            if (!_graph.ContainsKey(from))
            {
                _graph[from] = new List<int>();
            }
            _graph[from].Add(to);
        }

        public int Search(int source, int target)
        {
            var queue = new Queue<int>(_graph[source]);
            var visited = new List<int>(new[] { source });
            // Console.Write($"{source} -> ");

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    if (node == target)
                    {
                        // Console.WriteLine($"{node} is a last bus stop");
                        return node;
                    }
                    else
                    {
                        // Console.Write($"{node} -> ");
                        foreach (var neighbor in _graph[node])
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            return -1;
        }
    }
}

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
            return Solution1(routes, source, target);
        }

        public int Solution1(int[][] routes, int source, int target)
        {
            if (source == target) return 0;

            var stopAndRoutes = new Dictionary<int, List<int>>();

            for (var i = 0; i < routes.Length; i++)
            {
                foreach (var busStop in routes[i])
                {
                    if (!stopAndRoutes.ContainsKey(busStop))
                        stopAndRoutes[busStop] = new List<int>();

                    stopAndRoutes[busStop].Add(i);
                }
            }

            var queue = new Queue<int>();
            var visitedStops = new HashSet<int>();
            var visitedRoutes = new HashSet<int>();

            queue.Enqueue(source);
            visitedStops.Add(source);

            var busChanges = 0;
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var currentStop = queue.Dequeue();
                    foreach (var route in stopAndRoutes[currentStop])
                    {
                        if (visitedRoutes.Contains(route))
                            continue;

                        visitedRoutes.Add(route);
                        foreach (var nextStop in routes[route])
                        {
                            if (visitedStops.Contains(nextStop))
                                continue;

                            if (nextStop == target)
                                return busChanges + 1;

                            visitedStops.Add(nextStop);
                            queue.Enqueue(nextStop);
                        }
                    }
                }
                busChanges++;
            }
            return -1;
        }

        /// <summary>Wrong attempt</summary>
        /// <returns></returns>
        public int Solution2(int[][] routes, int source, int target)
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

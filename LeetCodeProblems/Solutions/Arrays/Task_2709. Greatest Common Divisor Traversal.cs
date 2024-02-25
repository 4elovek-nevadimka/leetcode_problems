namespace Solutions.Arrays
{
    internal class Task_2709
    {
        // #Array #Math #Union Find #Number Theory

        public bool CanTraverseAllPairs(int[] nums)
        {
            // Build the graph based on prime factor neighbors
            List<int>[] graph = BuildGraph(nums);

            // Check if all nodes are in the same connected component
            return IsConnected(graph, nums.Length);
        }

        private List<int>[] BuildGraph(int[] nums)
        {
            var graph = new List<int>[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                graph[i] = new List<int>();
            }

            var map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                PrimeFactors(nums[i], i, map, graph);
            }

            return graph;
        }

        private void PrimeFactors(int num, int index, Dictionary<int, int> map, List<int>[] graph)
        {
            for (var i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    AddToGraph(i, index, map, graph);

                    while (num % i == 0)
                        num /= i;
                }
            }

            if (num > 1)
            {
                AddToGraph(num, index, map, graph);
            }
        }

        private void AddToGraph(int factor, int index, Dictionary<int, int> map, List<int>[] graph)
        {
            if (!map.ContainsKey(factor))
                map[factor] = index;
            else
            {
                var node = map[factor];
                graph[index].Add(node);
                graph[node].Add(index);
            }
        }

        private bool IsConnected(List<int>[] graph, int n)
        {
            bool[] visited = new bool[n];

            // Use DFS to check connected components
            void DFS(int node)
            {
                visited[node] = true;

                foreach (var neighbor in graph[node])
                {
                    if (!visited[neighbor])
                    {
                        DFS(neighbor);
                    }
                }
            }

            int components = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    components++;
                    DFS(i);
                }
            }

            // If there is only one connected component, then all indices are reachable
            return components == 1;
        }
    }
}

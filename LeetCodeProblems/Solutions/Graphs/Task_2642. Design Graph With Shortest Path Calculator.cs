namespace Solutions.Graphs
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
            Console.WriteLine($"shortestPath [3, 2]: {graph.GetShortestPath(3, 2)}");
            Console.WriteLine($"shortestPath [0, 3]: {graph.GetShortestPath(0, 3)}");
            graph.AddEdge(new[] { 1, 3, 4 });
            Console.WriteLine("addEdge");
            Console.WriteLine($"shortestPath [0, 3]: {graph.GetShortestPath(0, 3)}");

            Console.WriteLine("Graph #2");
            Graph graph2 = new(4, new int[][] {
                new[] { 0, 1, 6 }, new[] { 0, 2, 2 },
                new[] { 2, 1, 3 },
                new[] { 1, 3, 1 }, new[] { 2, 3, 5 }
            });
            Console.WriteLine($"shortestPathValue [0, 3]: {graph2.GetShortestPath(0, 3)}");
            Console.WriteLine($"shortestPath: {string.Join(" -> ", graph2.ShortestPath)}");
        }
    }
}

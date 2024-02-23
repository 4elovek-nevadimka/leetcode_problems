namespace Solutions.Graphs
{
    internal class Task_0787
    {
        // #Dynamic Programming #Depth-First Search #Breadth-First Search #Graph #Heap(Priority Queue) #Shortest Path

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            var distances = new int[n];
            Array.Fill(distances, int.MaxValue);

            distances[src] = 0;

            for (var i = 0; i <= k; i++)
            {
                var tmpDistances = (int[])distances.Clone();
                foreach (var flight in flights)
                {
                    if (distances[flight[0]] != int.MaxValue)
                    {
                        if (distances[flight[0]] + flight[2] < tmpDistances[flight[1]])
                        {
                            tmpDistances[flight[1]] = distances[flight[0]] + flight[2];
                        }
                    }
                }
                distances = tmpDistances;
            }

            return distances[dst] == int.MaxValue ? -1 : distances[dst];
        }
    }
}

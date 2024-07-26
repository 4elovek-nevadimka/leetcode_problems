namespace Solutions.Graphs
{
    internal class Task_1334
    {
        // #Dynamic Programming #Graph #Shortest Path

        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            int[,] dist = new int[n, n];

            // Initialize distance matrix with infinity
            int inf = Int32.MaxValue / 2; // Avoid overflow
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        dist[i, j] = 0;
                    }
                    else
                    {
                        dist[i, j] = inf;
                    }
                }
            }

            // Fill the distance matrix with direct edges
            foreach (var edge in edges)
            {
                int u = edge[0], v = edge[1], w = edge[2];
                dist[u, v] = w;
                dist[v, u] = w;
            }

            // Apply Floyd-Warshall Algorithm
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, j] > dist[i, k] + dist[k, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                        }
                    }
                }
            }

            int minCount = n;
            int resultCity = -1;

            // Find the city with the minimum number of neighbors within the threshold distance
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j && dist[i, j] <= distanceThreshold)
                    {
                        count++;
                    }
                }

                if (count < minCount || (count == minCount && i > resultCity))
                {
                    minCount = count;
                    resultCity = i;
                }
            }

            return resultCity;
        }
    }
}

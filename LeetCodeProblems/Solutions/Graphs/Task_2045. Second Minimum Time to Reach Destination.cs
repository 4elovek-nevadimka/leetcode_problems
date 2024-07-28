namespace Solutions.Graphs
{
    internal class Task_2045
    {
        // #Breadth-First Search #Graph #Shortest Path

        public int SecondMinimum(int n, int[][] edges, int time, int change)
        {
            var graph = new List<int>[n + 1];
            for (int i = 0; i <= n; i++)
                graph[i] = [];

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            var dist = new int[n + 1][];
            for (int i = 0; i <= n; i++)
                dist[i] = [int.MaxValue, int.MaxValue];

            var pq = new PriorityQueue<(int node, int time), int>();
            pq.Enqueue((1, 0), 0);
            dist[1][0] = 0;

            while (pq.Count > 0)
            {
                var (node, currentTime) = pq.Dequeue();

                foreach (var neighbor in graph[node])
                {
                    int newTime = currentTime;
                    if ((newTime / change) % 2 == 1)
                        newTime += change - (newTime % change);

                    newTime += time;

                    if (newTime < dist[neighbor][0])
                    {
                        dist[neighbor][1] = dist[neighbor][0];
                        dist[neighbor][0] = newTime;
                        pq.Enqueue((neighbor, newTime), newTime);
                    }
                    else if (newTime > dist[neighbor][0] && newTime < dist[neighbor][1])
                    {
                        dist[neighbor][1] = newTime;
                        pq.Enqueue((neighbor, newTime), newTime);
                    }
                }
            }

            return dist[n][1];
        }
    }
}

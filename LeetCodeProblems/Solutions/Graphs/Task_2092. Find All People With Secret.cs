namespace Solutions.Graphs
{
    internal class Task_2092
    {
        // #Depth-First Search #Breadth-First Search #Union Find #Graph #Sorting

        public IList<int> FindAllPeople(int n, int[][] meetings, int firstPerson)
        {
            var graph = new Dictionary<int, List<(int, int)>>();
            for (int i = 0; i < n; i++)
                graph[i] = new List<(int, int)>();

            foreach (int[] meet in meetings)
            {
                graph[meet[0]].Add((meet[1], meet[2]));
                graph[meet[1]].Add((meet[0], meet[2]));
            }

            var queue = new PriorityQueue<(int, int), int>();
            queue.Enqueue((0, firstPerson), 0);
            queue.Enqueue((0, 0), 0);

            var visited = new bool[n];
            var result = new List<int>();
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();
                if (visited[cur.Item2])
                    continue;
                visited[cur.Item2] = true;
                result.Add(cur.Item2);
                int time = cur.Item1;
                foreach (var neigh in graph[cur.Item2])
                {
                    if (!visited[neigh.Item1] && time <= neigh.Item2)
                        queue.Enqueue((neigh.Item2, neigh.Item1), neigh.Item2);
                }
            }
            return result;
        }
    }
}

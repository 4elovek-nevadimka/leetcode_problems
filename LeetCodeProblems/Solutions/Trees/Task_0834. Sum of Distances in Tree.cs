using Solutions.Graphs;

namespace Solutions.Trees
{
    internal class Task_0834
    {
        // #Dynamic Programming #Tree #Depth-First Search #Graph

        private List<int>[] graph;
        private int[] count;
        private int[] sum;
        private int[] ans;

        public int[] SumOfDistancesInTree(int n, int[][] edges)
        {
            graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            count = new int[n];
            sum = new int[n];
            ans = new int[n];

            DFS(0, -1);
            DFS2(0, -1);

            return ans;
        }

        private void DFS(int node, int parent)
        {
            count[node] = 1;
            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue;
                DFS(neighbor, node);
                count[node] += count[neighbor];
                sum[node] += sum[neighbor] + count[neighbor];
            }
        }

        private void DFS2(int node, int parent)
        {
            ans[node] = sum[node];
            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue;
                int tempSum = sum[node];
                int tempCount = count[node];
                int neighborSum = sum[neighbor];
                int neighborCount = count[neighbor];

                sum[node] -= sum[neighbor] + count[neighbor];
                count[node] -= count[neighbor];
                sum[neighbor] += sum[node] + count[node];
                count[neighbor] += count[node];

                DFS2(neighbor, node);

                sum[node] = tempSum;
                count[node] = tempCount;
                sum[neighbor] = neighborSum;
                count[neighbor] = neighborCount;
            }
        }
    }
}

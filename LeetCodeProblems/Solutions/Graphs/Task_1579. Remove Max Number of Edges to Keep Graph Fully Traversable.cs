namespace Solutions.Graphs
{
    internal class Task_1579
    {
        // #Union Find #Graph

        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            var parentAlice = new int[n + 1];
            var parentBob = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                parentAlice[i] = i;
                parentBob[i] = i;
            }

            int removedEdges = 0;
            int aliceEdges = 0;
            int bobEdges = 0;

            foreach (var edge in edges)
            {
                if (edge[0] == 3)
                {
                    bool aliceMerged = Union(parentAlice, edge[1], edge[2]);
                    bool bobMerged = Union(parentBob, edge[1], edge[2]);
                    if (aliceMerged) aliceEdges++;
                    if (bobMerged) bobEdges++;
                    if (!aliceMerged && !bobMerged) removedEdges++;
                }
            }

            foreach (var edge in edges)
            {
                if (edge[0] == 1)
                {
                    if (Union(parentAlice, edge[1], edge[2]))
                    {
                        aliceEdges++;
                    }
                    else
                    {
                        removedEdges++;
                    }
                }
                else if (edge[0] == 2)
                {
                    if (Union(parentBob, edge[1], edge[2]))
                    {
                        bobEdges++;
                    }
                    else
                    {
                        removedEdges++;
                    }
                }
            }

            if (aliceEdges == n - 1 && bobEdges == n - 1)
            {
                return removedEdges;
            }

            return -1;
        }

        private bool Union(int[] parent, int x, int y)
        {
            int rootX = Find(parent, x);
            int rootY = Find(parent, y);
            if (rootX != rootY)
            {
                parent[rootX] = rootY;
                return true;
            }
            return false;
        }

        private int Find(int[] parent, int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent, parent[x]);
            }
            return parent[x];
        }
    }
}

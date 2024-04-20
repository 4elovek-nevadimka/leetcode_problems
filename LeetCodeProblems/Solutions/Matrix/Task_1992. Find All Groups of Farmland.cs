namespace Solutions.Matrix
{
    internal class Task_1992
    {
        // #Array #Depth-First Search #Breadth-First Search #Matrix

        public int[][] FindFarmland(int[][] land)
        {
            var farmland = new List<int[]>();
            int m = land.Length, n = land[0].Length;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (land[i][j] == 1)
                    {
                        var bottomRight = new int[2];
                        DFS(land, i, j, bottomRight);
                        farmland.Add([i, j, bottomRight[0], bottomRight[1]]);
                    }
                }
            }

            return [.. farmland];
        }

        private void DFS(int[][] land, int row, int col, int[] bottomRight)
        {
            if (row < 0 || row >= land.Length
                || col < 0 || col >= land[0].Length || land[row][col] == 0)
            {
                return;
            }

            bottomRight[0] = Math.Max(bottomRight[0], row);
            bottomRight[1] = Math.Max(bottomRight[1], col);

            land[row][col] = 0;

            DFS(land, row - 1, col, bottomRight);
            DFS(land, row + 1, col, bottomRight);
            DFS(land, row, col - 1, bottomRight);
            DFS(land, row, col + 1, bottomRight);
        }
    }
}

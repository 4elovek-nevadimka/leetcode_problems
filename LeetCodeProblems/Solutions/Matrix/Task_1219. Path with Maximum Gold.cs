namespace Solutions.Matrix
{
    internal class Task_1219
    {
        // #Array #Backtracking #Matrix

        public int GetMaximumGold(int[][] grid)
        {
            int maxGold = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    maxGold = Math.Max(maxGold, GetGold(i, j, grid, 0));
                }
            }

            return maxGold;
        }

        private int GetGold(int i, int j, int[][] grid, int gold)
        {
            // out of bounds
            if (i < 0 || j < 0 || i == grid.Length || j == grid[i].Length)
                return gold;

            if (grid[i][j] == 0)
                return gold;


            int tmp = grid[i][j];
            grid[i][j] = 0;

            int localMax = GetGold(i + 1, j, grid, gold + tmp);
            localMax = Math.Max(localMax, GetGold(i - 1, j, grid, gold + tmp));
            localMax = Math.Max(localMax, GetGold(i, j + 1, grid, gold + tmp));
            localMax = Math.Max(localMax, GetGold(i, j - 1, grid, gold + tmp));

            grid[i][j] = tmp;
            return localMax;
        }
    }
}

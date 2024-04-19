namespace Solutions.Matrix
{
    internal class Task_0200
    {
        // #Array #Depth-First Search #Breadth-First Search #Union Find #Matrix

        public int NumIslands(char[][] grid)
        {
            var islandsCount = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFS(grid, i, j);
                        islandsCount++;
                    }
                }
            }

            return islandsCount;
        }

        private void DFS(char[][] grid, int row, int col)
        {
            if (row < 0 || row >= grid.Length 
                || col < 0 || col >= grid[0].Length || grid[row][col] == '0')
            {
                return;
            }
            grid[row][col] = '0';

            DFS(grid, row - 1, col);
            DFS(grid, row + 1, col);
            DFS(grid, row, col - 1);
            DFS(grid, row, col + 1);
        }
    }
}

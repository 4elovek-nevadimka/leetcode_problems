namespace Solutions.Matrix
{
    internal class Task_2482
    {
        // #Array #Matrix #Simulation
        public int[][] OnesMinusZeros(int[][] grid)
        {
            int rowsCount = grid.Length, colsCount = grid[0].Length;
            int[] rowsDiff = new int[rowsCount], colsDiff = new int[colsCount];
            for (var i = 0; i < rowsCount; i++)
            {
                for (var j = 0; j < colsCount; j++)
                {
                    rowsDiff[i] += grid[i][j] == 1 ? 1 : -1;
                    colsDiff[j] += grid[i][j] == 1 ? 1 : -1;
                }
            }

            int[][] diff = new int[rowsCount][];
            for (var i = 0; i < rowsCount; i++)
            {
                diff[i] = new int[colsCount];
                for (var j = 0; j < colsCount; j++)
                {
                    diff[i][j] = rowsDiff[i] + colsDiff[j];
                }
            }

            return diff;
        }
    }
}

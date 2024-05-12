namespace Solutions.Matrix
{
    internal class Task_2373
    {
        // #Array #Matrix

        public int[][] LargestLocal(int[][] grid)
        {
            var n = grid.Length;
            var largestMatrix = new int[n - 2][];
            for (var i = 0; i < n - 2; i++)
            {
                largestMatrix[i] = new int[n - 2];
                for (var j = 0; j < n - 2; j++)
                {
                    var localMax = 0;
                    for (var c = 0; c < 3; c++)
                    {
                        for (var r = 0; r < 3; r++)
                        {
                            localMax = Math.Max(localMax, grid[i + c][j + r]);
                        }
                    }
                    largestMatrix[i][j] = localMax;
                }
            }

            return largestMatrix;
        }
    }
}

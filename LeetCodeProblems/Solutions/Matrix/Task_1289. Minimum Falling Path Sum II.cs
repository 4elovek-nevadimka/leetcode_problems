namespace Solutions.Matrix
{
    internal class Task_1289
    {
        // #Array #Dynamic Programming #Matrix

        public int MinFallingPathSum(int[][] grid)
        {
            int n = grid.Length, m = grid[0].Length;

            var dp = new int[n, m];
            for (var i = 0; i < m; i++)
                dp[0, i] = grid[0][i];

            for (var i = 1; i < n; i++)
            {
                int min1 = Int32.MaxValue, min2 = Int32.MaxValue;
                int minIndex = -1;
                for (var j = 0; j < m; j++)
                {
                    if (dp[i - 1, j] < min1)
                    {
                        (min2, min1) = (min1, dp[i - 1, j]);
                        minIndex = j;
                    }
                    else if (dp[i - 1, j] < min2)
                    {
                        min2 = dp[i - 1, j];
                    }
                }

                for (var j = 0; j < m; j++)
                    dp[i, j] = grid[i][j] + (j == minIndex ? min2 : min1);
            }

            var minSum = Int32.MaxValue;
            for (int j = 0; j < m; j++)
                minSum = Math.Min(minSum, dp[n - 1, j]);

            return minSum;
        }
    }
}

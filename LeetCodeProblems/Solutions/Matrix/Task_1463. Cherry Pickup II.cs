namespace Solutions.Matrix
{
    internal class Task_1463
    {
        public int CherryPickup(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length;
            var dp = new int[rows, cols, cols];

            for (var r = rows - 1; r >= 0; r--)
            {
                for (var c1 = 0; c1 < cols; c1++)
                {
                    for (var c2 = 0; c2 < cols; c2++)
                    {
                        var cherries = grid[r][c1];
                        // not the same column
                        if (c1 != c2)
                        {
                            cherries += grid[r][c2];
                        }
                        // next row
                        if (r != rows - 1)
                        {
                            var maxNext = 0;
                            // all possible moves for robots
                            for (var m1 = c1 - 1; m1 <= c1 + 1; m1++)
                            {
                                for (var m2 = c2 - 1; m2 <= c2 + 1; m2++)
                                {
                                    if (m1 >= 0 && m1 < cols && m2 >= 0 && m2 < cols)
                                    {
                                        maxNext = Math.Max(maxNext, dp[r + 1, m1, m2]);
                                    }
                                }
                            }
                            cherries += maxNext;
                        }
                        dp[r, c1, c2] = cherries;
                    }
                }
            }
            return dp[0, 0, cols - 1];
        }
    }
}

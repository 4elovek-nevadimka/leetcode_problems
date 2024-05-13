namespace Solutions.Matrix
{
    internal class Task_0861
    {
        // #Array #Greedy #Bit Manipulation #Matrix

        public void Run()
        {
            Console.WriteLine(
                new[] { 1, 0, 0 }.Aggregate((acc, y) => (acc << 1) | y));
        }

        public int MatrixScore(int[][] grid)
        {
            int m = grid[0].Length, n = grid.Length;
            for (var r = 0; r < n; r++)
            {
                if (grid[r][0] == 0)
                {
                    // do flip
                    for (var c = 0; c < m; c++)
                        grid[r][c] = grid[r][c] == 1 ? 0 : 1;
                }
            }

            for (var c = 0; c < m; c++)
            {
                var counter = 0;
                for (var r = 0; r < n; r++)
                {
                    if (grid[r][c] == 0)
                        counter++;
                }
                if (counter > n / 2)
                {
                    // do flip
                    for (var r = 0; r < n; r++)
                        grid[r][c] = grid[r][c] == 1 ? 0 : 1;
                }
            }

            var matrixSum = 0;
            for (var r = 0; r < n; r++)
                matrixSum += grid[r].Aggregate((acc, x) => (acc << 1) | x);

            return matrixSum;
        }
    }
}

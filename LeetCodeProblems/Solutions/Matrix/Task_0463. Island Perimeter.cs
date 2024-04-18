namespace Solutions.Matrix
{
    internal class Task_0463
    {
        // #Array #Depth-First Search #Breadth-First Search #Matrix

        public int IslandPerimeter(int[][] grid)
        {
            var perimeter = 0;
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        perimeter += 4;

                        if (i > 0 && grid[i - 1][j] == 1)
                            perimeter -= 2;
                        if (j > 0 && grid[i][j - 1] == 1)
                            perimeter -= 2;
                    }
                }
            }

            return perimeter;
        }
    }
}

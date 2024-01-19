namespace Solutions.DP
{
    internal class Task_0931
    {
        // #Array #Dynamic Programming #Matrix

        public int MinFallingPathSum(int[][] matrix)
        {
            var rowsCount = matrix.Length;
            var colsCount = matrix[0].Length;
            for (var i = 1; i < rowsCount; i++)
            {
                for (var j = 0; j < colsCount; j++)
                {
                    if (j == 0 || j == colsCount - 1)
                    {
                        var minOfTwo = j == 0 ?
                            Math.Min(matrix[i - 1][j], matrix[i - 1][j + 1])
                            :
                            Math.Min(matrix[i - 1][j - 1], matrix[i - 1][j]);
                        matrix[i][j] = matrix[i][j] + minOfTwo;
                    }
                    else
                    {
                        var minOfTwo = 
                            Math.Min(matrix[i - 1][j - 1], matrix[i - 1][j + 1]);
                        matrix[i][j] = 
                            matrix[i][j] + Math.Min(minOfTwo, matrix[i - 1][j]);
                    }
                }
            }
            var minPath = Int32.MaxValue;
            for (var i = 0; i < colsCount; i++)
            {
                minPath = Math.Min(minPath, matrix[rowsCount - 1][i]);
            }

            return minPath;
        }
    }
}

namespace Solutions.Matrix
{
    internal class Task_1380
    {
        // #Array #Matrix

        public void Run()
        {
            LuckyNumbers([[3, 7, 8], [9, 11, 13], [15, 16, 17]]);
            LuckyNumbers([[1, 10, 4, 2], [9, 3, 8, 7], [15, 16, 17, 12]]);
            LuckyNumbers([[7, 8], [1, 2]]);
        }

        public IList<int> LuckyNumbers(int[][] matrix)
        {
            int m = matrix[0].Length, n = matrix.Length;
            var minInRows = new int[n];
            var maxInCols = new int[m];

            for (var i = 0; i < n; i++)
            {
                minInRows[i] = int.MaxValue;
                for (var j = 0; j < m; j++)
                    minInRows[i] = Math.Min(minInRows[i], matrix[i][j]);
            }

            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                    maxInCols[i] = Math.Max(maxInCols[i], matrix[j][i]);

            var result = new List<int>();
            for (var i = 0; i < n; i++)
                for (var j = 0; j < m; j++)
                    if (minInRows[i] == maxInCols[j])
                        result.Add(minInRows[i]);

            return result;
        }
    }
}

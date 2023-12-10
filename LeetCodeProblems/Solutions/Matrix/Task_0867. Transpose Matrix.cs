namespace Solutions.Matrix
{
    internal class Task_0867
    {
        public void Run()
        {
            // var matrix = new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9} };
            var matrix = new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } };
            var result = Transpose(matrix);
        }


        public int[][] Transpose(int[][] matrix)
        {
            var rows = matrix.Length;
            var cols = matrix[0].Length;

            var transposeMatrix = new int[cols][];
            for (var i = 0; i < cols; i++)
            {
                transposeMatrix[i] = new int[rows];
                for (var j = 0; j < rows; j++)
                {
                    transposeMatrix[i][j] = matrix[j][i];
                }
            }

            return transposeMatrix;
        }
    }
}

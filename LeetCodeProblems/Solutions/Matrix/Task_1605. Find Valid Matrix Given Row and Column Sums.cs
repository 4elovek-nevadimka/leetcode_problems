namespace Solutions.Matrix
{
    internal class Task_1605
    {
        // #Array #Greedy #Matrix

        public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
        {
            var result = new int[rowSum.Length][];
            for (int i = 0; i < rowSum.Length; i++)
                result[i] = new int[colSum.Length];

            for (var i = 0; i < rowSum.Length; i++)
                for (var j = 0; j < colSum.Length; j++)
                {
                    var minVal = Math.Min(rowSum[i], colSum[j]);
                    result[i][j] = minVal;
                    rowSum[i] -= minVal;
                    colSum[j] -= minVal;
                }

            return result;
        }
    }
}

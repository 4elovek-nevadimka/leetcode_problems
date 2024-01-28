namespace Solutions.Matrix
{
    internal class Task_1074
    {
        // #Array #Hash Table #Matrix #Prefix Sum

        public int NumSubmatrixSumTarget(int[][] matrix, int target)
        {
            var rowsCount = matrix.Length;
            var colsCount = matrix[0].Length;
            var preSum = new int[rowsCount + 1, colsCount + 1];

            for (var i = 1; i <= rowsCount; i++)
            {
                for (var j = 1; j <= colsCount; j++)
                {
                    preSum[i, j] = matrix[i - 1][j - 1] 
                        + preSum[i - 1, j] + preSum[i, j - 1] - preSum[i - 1, j - 1];
                }
            }

            var result = 0;
            for (var top = 1; top <= rowsCount; top++)
            {
                for (var bottom = top; bottom <= rowsCount; bottom++)
                {
                    var count = new Dictionary<int, int> { [0] = 1 };

                    for (var col = 1; col <= colsCount; col++)
                    {
                        var currentSum = 
                            preSum[bottom, col] - preSum[top - 1, col];

                        if (count.ContainsKey(currentSum - target))
                            result += count[currentSum - target];

                        if (!count.ContainsKey(currentSum))
                            count[currentSum] = 1;
                        else
                            count[currentSum]++;
                    }
                }
            }

            return result;
        }
    }
}

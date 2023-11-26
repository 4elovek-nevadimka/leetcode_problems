namespace Solutions
{
    internal class Task_1727
    {
        public int LargestSubmatrix(int[][] matrix) {
            
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            // Count consecutive 1s in each column
            for (int i = 1; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    if (matrix[i][j] == 1) {
                        matrix[i][j] += matrix[i - 1][j];
                    }
                }
            }

            // Calculate the maximum submatrix area
            int maxArea = 0;
            for (int i = 0; i < rows; i++) {
                // Sort each row in non-increasing order
                Array.Sort(matrix[i], (a, b) => b - a);
                for (int j = 0; j < cols; j++) {
                    maxArea = Math.Max(maxArea, matrix[i][j] * (j + 1));
                }
            }

            return maxArea;
        }
    }
}
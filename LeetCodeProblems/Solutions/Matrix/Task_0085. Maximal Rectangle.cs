namespace Solutions.Matrix
{
    internal class Task_0085
    {
        // #Array #Dynamic Programming #Stack #Matrix #Monotonic Stack

        public int MaximalRectangle(char[][] matrix)
        {
            var maxArea = 0;
            var rows = matrix.Length;
            var cols = matrix[0].Length;
            var heights = new int[cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i][j] == '1')
                        heights[j]++;
                    else
                        heights[j] = 0;
                }

                maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
            }

            return maxArea;
        }

        private int LargestRectangleArea(int[] heights)
        {
            var maxArea = 0;
            var n = heights.Length;
            var stack = new Stack<int>();

            for (var i = 0; i <= n; i++)
            {
                var h = (i == n) ? 0 : heights[i];
                while (stack.Count > 0 && h < heights[stack.Peek()])
                {
                    var height = heights[stack.Pop()];
                    var width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * width);
                }
                stack.Push(i);
            }

            return maxArea;
        }
    }
}

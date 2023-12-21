namespace Solutions.Arrays
{
    internal class Task_1637
    {
        // #2dPlane
        // #Array #Sorting

        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var n = points.Length;
            var xCoordinates = new int[n];
            for (var i = 0; i < n; i++)
            {
                xCoordinates[i] = points[i][0];
            }
            var maxDiff = 0;
            Array.Sort(xCoordinates);
            for (var i = 1; i < n; i++)
            {
                maxDiff = Math.Max(maxDiff, xCoordinates[i] - xCoordinates[i - 1]);
            }
            return maxDiff;
        }
    }
}

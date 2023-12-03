namespace Solutions
{
    internal class Task_1266
    {
        public int MinTimeToVisitAllPoints(int[][] points)
        {
            var minTime = 0;
            for (var i = 1; i < points.Length; i++)
            {
                minTime += Math.Max(
                    Math.Abs(points[i][0] - points[i - 1][0]),
                    Math.Abs(points[i][1] - points[i - 1][1]));
            }

            return minTime;
        }
    }
}

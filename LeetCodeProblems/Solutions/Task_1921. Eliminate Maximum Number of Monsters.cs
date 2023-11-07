namespace Solutions
{
    internal class Task_1921
    {
        public int EliminateMaximum(int[] dist, int[] speed)
        {
            var n = dist.Length;
            var steps = new double[n];

            for (var i = 0; i < n; i++)
            {
                // steps to finish
                steps[i] = (double)dist[i] / speed[i];
            }
            Array.Sort(steps);

            for (var i = 0; i < n; i++)
            {
                if (steps[i] <= i)
                {
                    return i;
                }
            }
            return n;
        }
    }
}

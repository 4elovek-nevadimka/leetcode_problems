namespace Solutions.Arrays
{
    internal class Task_0452
    {
        // #Array #Greedy #Sorting

        public void Run()
        {
            Console.WriteLine(FindMinArrowShots([[10, 16], [2, 8], [1, 6], [7, 12]]));
            Console.WriteLine(FindMinArrowShots([[1, 2], [3, 4], [5, 6], [7, 8]]));
            Console.WriteLine(FindMinArrowShots([[1, 2], [2, 3], [3, 4], [4, 5]]));
            Console.WriteLine(FindMinArrowShots([[100, 200], [150, 250], [180, 220], [210, 230]]));
        }

        public int FindMinArrowShots(int[][] points)
        {
            Array.Sort(points, (a, b) => a[1].CompareTo(b[1]));

            int shots = 1, end = points[0][1];
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i][0] <= end)
                    continue;

                shots++;
                end = points[i][1];
            }
            return shots;
        }
    }
}

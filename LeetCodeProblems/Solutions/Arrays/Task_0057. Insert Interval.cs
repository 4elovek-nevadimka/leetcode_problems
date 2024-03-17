namespace Solutions.Arrays
{
    internal class Task_0057
    {
        // #Array
        
        public void Run()
        {
            var intervals = Insert([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8]);
            // var intervals = Insert([[1, 3], [6, 9]], [2, 5]);
            Array.ForEach(intervals, interval =>
            {
                Console.Write($"[{string.Join(", ", interval)}] ");
            });
        }

        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var i = 0;
            var merged = new List<int[]>();

            while (i < intervals.Length && intervals[i][1] < newInterval[0])
            {
                merged.Add(intervals[i]);
                i++;
            }

            while (i < intervals.Length && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            merged.Add(newInterval);

            while (i < intervals.Length)
            {
                merged.Add(intervals[i]);
                i++;
            }

            return [.. merged];
        }
    }
}

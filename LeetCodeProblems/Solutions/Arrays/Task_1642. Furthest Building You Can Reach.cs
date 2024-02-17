namespace Solutions.Arrays
{
    internal class Task_1642
    {
        // #Array #Greedy #Heap(Priority Queue)

        public void Run()
        {
            var heights = new[] { 4, 2, 7, 6, 9, 14, 12 };
            int bricks = 5, ladders = 1;
            // var heights = new[] { 4, 12, 2, 7, 3, 18, 20, 3, 19 };
            // int bricks = 10, ladders = 2;
            // var heights = new[] { 70000, 901145, 283087, 500166, 489644, 590981, 336788, 1000000, 105846, 278867, 1, 605301, 1, 593249, 1, 861847, 1 };
            // int bricks = 17399, ladders = 4;
            Console.WriteLine(FurthestBuilding(heights, bricks, ladders));
        }

        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            var pQueue = new PriorityQueue<int, int>();
            for (int i = 0; i < heights.Length - 1; i++)
            {
                var diff = heights[i + 1] - heights[i];
                if (diff > 0)
                    pQueue.Enqueue(diff, diff);

                if (pQueue.Count > ladders)
                    bricks -= pQueue.Dequeue();

                if (bricks < 0)
                    return i;
            }

            return heights.Length - 1;
        }
    }
}

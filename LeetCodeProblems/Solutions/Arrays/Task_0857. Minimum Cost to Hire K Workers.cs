namespace Solutions.Arrays
{
    internal class Task_0857
    {
        // #Array #Greedy #Sorting #Heap(Priority Queue)

        public double MincostToHireWorkers(int[] quality, int[] wage, int k)
        {
            var n = quality.Length;
            var workers = new double[n][];

            for (var i = 0; i < n; i++)
                workers[i] = [(double)wage[i] / quality[i], quality[i]];

            Array.Sort(workers, (a, b) => a[0].CompareTo(b[0]));
            var maxHeap = new PriorityQueue<int, int>();
            var minCost = double.MaxValue;
            var qualitySum = 0;

            for (var i = 0; i < n; i++)
            {
                qualitySum += (int)workers[i][1];
                maxHeap.Enqueue((int)workers[i][1], (int)-workers[i][1]);

                if (i + 1 >= k)
                {
                    minCost = minCost == 0 ? 
                        (qualitySum * workers[i][0]) : 
                        Math.Min(minCost, qualitySum * workers[i][0]);
                    qualitySum -= maxHeap.Dequeue();
                }
            }

            return minCost;
        }
    }
}

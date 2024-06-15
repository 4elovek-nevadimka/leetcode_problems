namespace Solutions.Arrays
{
    internal class Task_0502
    {
        // #Array #Greedy #Sorting #Heap(Priority Queue)

        public void Run()
        {
            // Console.WriteLine(FindMaximizedCapital(2, 0, [1, 2, 3], [0, 1, 1]));
            Console.WriteLine(FindMaximizedCapital(11, 11, [1, 2, 3], [11, 12, 13]));
        }

        public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
        {
            int n = profits.Length;
            var projects = new List<(int profit, int capital)>();
            for (int i = 0; i < n; i++)
                projects.Add((profits[i], capital[i]));

            projects.Sort((a, b) => a.capital.CompareTo(b.capital));

            var maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            int currentCapital = w;
            int index = 0;

            for (int i = 0; i < k; i++)
            {
                while (index < n && projects[index].capital <= currentCapital)
                {
                    maxHeap.Enqueue(projects[index].profit, projects[index].profit);
                    index++;
                }

                if (maxHeap.Count == 0)
                    break;

                currentCapital += maxHeap.Dequeue();
            }

            return currentCapital;
        }
    }
}

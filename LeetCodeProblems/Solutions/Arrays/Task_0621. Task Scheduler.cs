namespace Solutions.Arrays
{
    internal class Task_0621
    {
        // #Array #Hash Table #Greedy #Sorting #Heap(Priority Queue) #Counting

        public void Run()
        {
            Console.WriteLine(LeastInterval(['A', 'C', 'A', 'B', 'D', 'B'], 1));
        }

        public int LeastInterval(char[] tasks, int n)
        {
            var tasksFreq = new int[26];
            foreach (var taks in tasks)
                tasksFreq[taks - 'A']++;

            Array.Sort(tasksFreq);

            var maxFreq = tasksFreq[25] - 1;
            var idleStates = maxFreq * n;

            for (var i = 24; i >= 0 && tasksFreq[i] > 0; i--)
            {
                idleStates -= Math.Min(maxFreq, tasksFreq[i]);
            }

            return idleStates > 0 ? idleStates + tasks.Length : tasks.Length;

        }
    }
}
